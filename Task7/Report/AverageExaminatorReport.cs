using System.Collections.Generic;
using System.Linq;
using UniversityDAO;

namespace Report
{
    /// <summary>
    /// Class for getting data.
    /// </summary>
    public class AverageExaminatorReport
    {
        private ExamDao examDao;
        private ResultDao resultDao;
        private ExaminatorDao examinatorDao;

        /// <summary>
        /// Initializes a new instance of the AverageExaminatorReport class.
        /// </summary>
        /// <param name="factory"></param>
        public AverageExaminatorReport(DaoFactory factory)
        {
            examDao = factory.GetExamDao();
            resultDao = factory.GetResultDao();
            examinatorDao = factory.GetExaminatorDao();
        }

        /// <summary>
        /// Gets header.
        /// </summary>
        /// <returns></returns>
        public List<string> GetHeader()
        {
            return new List<string> { "Экзаменатор", "Средний балл" };
        }

        /// <summary>
        /// Gets data.
        /// </summary>
        /// <param name="numberOfSession"></param>
        /// <returns></returns>
        public List<AverageExaminator> GetData(int numberOfSession)
        {
            var exams = examDao.ReadAll();
            var results = resultDao.ReadAll();
            var examinators = examinatorDao.ReadAll();

            List<AverageExaminator> averageExaminatorList = new List<AverageExaminator>();

            foreach (var val in examinators)
            {
                var marks = from result in results
                            join exam in exams on result.IdExam equals exam.Id
                            join examinator in examinators on exam.IdExaminator equals examinator.Id
                            where exam.NumberOfSession == numberOfSession
                            where examinator.Id == val.Id
                            select result;
                
                var averageResult = marks.Count() != 0 ? marks.Average(x => x.Mark) : 0;
                averageExaminatorList.Add(new AverageExaminator
                {
                    ExaminatorName = val.Name,
                    AverageMark = averageResult
                });
            }

            return averageExaminatorList;
        }
    }
}
