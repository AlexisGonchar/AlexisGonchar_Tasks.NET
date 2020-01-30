using System.Collections.Generic;
using System.Linq;
using UniversityDAO;
using UniversityORM;

namespace Report
{
    public class AverageSpecialtyReport
    {
        private ExamDao examDao;
        private ResultDao resultDao;
        private GroupDao groupDao;
        private SpecialtyDao specialtyDao;
        public AverageSpecialtyReport(DaoFactory factory)
        {
            examDao = factory.GetExamDao();
            resultDao = factory.GetResultDao();
            groupDao = factory.GetGroupDao();
            specialtyDao = factory.GetSpecialtyDao();
        }

        public List<string> GetHeader()
        {
            return new List<string> { "Специальность", "Средний балл" };
        }

        public List<AverageSpecialty> GetData(int numberOfSession)
        {
            var exams = examDao.ReadAll();
            var results = resultDao.ReadAll();
            var groups = groupDao.ReadAll();
            var specialtyL = specialtyDao.ReadAll();

            List<AverageSpecialty> AverageSpecialtyList = new List<AverageSpecialty>();

            foreach (var val in specialtyL)
            {
                var marks = from specialty in specialtyL
                            join grp in groups on specialty.Id equals grp.IdSpecialty
                            join exam in exams on grp.Id equals exam.IdGroup
                            join result in results on exam.Id equals result.IdExam
                            where val.Id == specialty.Id
                            where exam.NumberOfSession == numberOfSession
                            select result;
                var averageResult = marks.Average(x => x.Mark);
                AverageSpecialtyList.Add(new AverageSpecialty
                {
                    SpecialtyName = val.Name,
                    AverageMark = averageResult
                });
            }

            return AverageSpecialtyList;
        }
    }
}
