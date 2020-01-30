using System.Collections.Generic;
using System.Linq;
using UniversityDAO;

namespace Report
{
    /// <summary>
    /// Class for getting data.
    /// </summary>
    public class AverageSpecialtyReport
    {
        private ExamDao examDao;
        private ResultDao resultDao;
        private GroupDao groupDao;
        private SpecialtyDao specialtyDao;

        /// <summary>
        /// Initializes a new instance of the AverageSpecialtyReport class.
        /// </summary>
        /// <param name="factory"></param>
        public AverageSpecialtyReport(DaoFactory factory)
        {
            examDao = factory.GetExamDao();
            resultDao = factory.GetResultDao();
            groupDao = factory.GetGroupDao();
            specialtyDao = factory.GetSpecialtyDao();
        }

        /// <summary>
        /// Gets header.
        /// </summary>
        /// <returns></returns>
        public List<string> GetHeader()
        {
            return new List<string> { "Специальность", "Средний балл" };
        }

        /// <summary>
        /// Gets data.
        /// </summary>
        /// <param name="numberOfSession"></param>
        /// <returns></returns>
        public List<AverageSpecialty> GetData(int numberOfSession)
        {
            var exams = examDao.ReadAll();
            var results = resultDao.ReadAll();
            var groups = groupDao.ReadAll();
            var specialtyL = specialtyDao.ReadAll();

            List<AverageSpecialty> averageSpecialtyList = new List<AverageSpecialty>();

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
                averageSpecialtyList.Add(new AverageSpecialty
                {
                    SpecialtyName = val.Name,
                    AverageMark = averageResult
                });
            }

            return averageSpecialtyList;
        }
    }
}
