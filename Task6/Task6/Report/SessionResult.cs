using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDAO;
using Microsoft.Office.Interop.Excel;
using UniversityORM;

namespace Report
{
    /// <summary>
    /// Class for createint report.
    /// </summary>
    public class SessionResult
    {
        private static GroupDao groupDao;
        private static SubjectDao subjectDao;
        private static StudentDao studentDao;
        private static ExamDao examDao;
        private static ResultDao resultDao;

        /// <summary>
        /// Initializes a new instance of the SessionResult class.
        /// </summary>
        /// <param name="factory"></param>
        public SessionResult(DaoFactory factory)
        {
            groupDao = factory.GetGroupDao();
            subjectDao = factory.GetSubjectDao();
            studentDao = factory.GetStudentDao();
            examDao = factory.GetExamDao();
            resultDao = factory.GetResultDao();
        }

        private List<string> GetHeader()
        {
            return new List<string> {
                "Имя группы", "Средняя оценка", "Минимальная оценка", "Максимальная оценка"
            };
        }

        /// <summary>
        /// Method for obtaining the necessary data.
        /// </summary>
        /// <param name="numberOfSession"></param>
        /// <returns></returns>
        public IEnumerable<SessionResultRow> GetResult(int numberOfSession)
        {
            var groups = groupDao.ReadAll();
            var subjects = subjectDao.ReadAll();
            var students = studentDao.ReadAll();
            var exams = examDao.ReadAll();
            var results = resultDao.ReadAll();

            List<SessionResultRow> sessionResults = new List<SessionResultRow>();
            foreach (Group cgroup in groups)
            {
                var summaryResults = from result in results
                                     join exam in exams on result.IdExam equals exam.Id
                                     where exam.NumberOfSession == numberOfSession & exam.IdGroup == cgroup.Id
                                     select result;
                var averageMark = summaryResults.Average(r => r.Mark);
                var minMark = summaryResults.Min(r => r.Mark);
                var maxMark = summaryResults.Max(r => r.Mark);
                sessionResults.Add(new SessionResultRow
                {
                    GroupName = cgroup.Name,
                    AverageMark = averageMark,
                    MinMark = minMark,
                    MaxMark = maxMark
                });
            }

            return sessionResults;
        }

        /// <summary>
        /// Method for writing to a file.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <param name="results"></param>
        public void WriteToExcel(string directory, string fileName, IEnumerable<SessionResultRow> results)
        {
            var header = GetHeader();
            string path = directory + fileName + ".xlsx";
            var excelApp = new Application();
            Workbook book = excelApp.Workbooks.Add();
            Worksheet sheet = book.Sheets[1];

            for (int i = 1; i < header.Count() + 1; i++)
            {
                sheet.Cells[1, i] = header[i - 1];
            }
            var r = results.GetEnumerator();
            for (int i = 2; i < results.Count(); i++)
            {
                r.MoveNext();
                sheet.Cells[i, 1] = r.Current.GroupName;
                sheet.Cells[i, 2] = r.Current.AverageMark;
                sheet.Cells[i, 3] = r.Current.MinMark;
                sheet.Cells[i, 4] = r.Current.MaxMark;
            }

            book.SaveAs(path);
            book.Close();
            excelApp.Quit();
        }
    }
}
