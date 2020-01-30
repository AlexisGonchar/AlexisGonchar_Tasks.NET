using System.Collections.Generic;
using System.Linq;
using UniversityDAO;
using UniversityORM;

namespace Report
{
    public class AverageExaminatorReport
    {
        private ExamDao examDao;
        private ResultDao resultDao;
        private ExaminatorDao examinatorDao;
        public AverageExaminatorReport(DaoFactory factory)
        {
            examDao = factory.GetExamDao();
            resultDao = factory.GetResultDao();
            examinatorDao = factory.GetExaminatorDao();
        }

        public List<string> GetHeader()
        {
            return new List<string> { "Экзаменатор", "Средний балл" };
        }

        public List<AverageExaminator> GetData(int numberOfSession)
        {
            var exams = examDao.ReadAll();
            var results = resultDao.ReadAll();
            var examinators = examinatorDao.ReadAll();

            List<AverageExaminator> AverageExaminatorList = new List<AverageExaminator>();

            foreach (var val in examinators)
            {
                var marks = from result in results
                            join exam in exams on result.IdExam equals exam.Id
                            join examinator in examinators on exam.IdExaminator equals examinator.Id
                            where exam.NumberOfSession == numberOfSession
                            where examinator.Id == val.Id
                            select result;
                
                var averageResult = marks.Count() != 0 ? marks.Average(x => x.Mark) : 0;
                AverageExaminatorList.Add(new AverageExaminator
                {
                    ExaminatorName = val.Name,
                    AverageMark = averageResult
                });
            }

            return AverageExaminatorList;
        }
    }
}
