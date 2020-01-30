using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using UniversityDAO;

namespace Report
{
    /// <summary>
    /// Class for getting data.
    /// </summary>
    public class AverageSubjectReport
    {
        private ExamDao examDao;
        private ResultDao resultDao;
        private SubjectDao subjectDao;
        private int sessionsCount;

        public AverageSubjectReport(DaoFactory factory)
        {
            examDao = factory.GetExamDao();
            resultDao = factory.GetResultDao();
            subjectDao = factory.GetSubjectDao();
        }

        public List<string> GetHeader()
        {
            var exams = examDao.ReadAll();
            sessionsCount = exams.Max(x => x.NumberOfSession);
            List<string> header = new List<string> { "Предмет" };
            for (int i = 1; i <= sessionsCount; i++)
                header.Add("Сессия " + i);
            return header;
        }

        public List<AverageSubject> GetData()
        {
            var exams = examDao.ReadAll();
            var results = resultDao.ReadAll();
            var subjects = subjectDao.ReadAll();

            List<AverageSubject> averageSubjectList = new List<AverageSubject>();

            foreach (var val in subjects)
            {
                averageSubjectList.Add(new AverageSubject
                {
                    SubjectName = val.Name,
                    AverageMarks = new List<double>()
                });
                for (int session = 1; session <= sessionsCount; session++)
                {
                    var marks = from result in results
                                join exam in exams on result.IdExam equals exam.Id
                                where exam.IdSubject == val.Id
                                where exam.NumberOfSession == session
                                select result;

                    var averageResult = marks.Count() != 0 ? marks.Average(x => x.Mark) : 0;
                    averageSubjectList[averageSubjectList.Count() - 1].AverageMarks.Add(averageResult);
                }
            }

            return averageSubjectList;
        }

        /// <summary>
        /// Method for write data to Excel file.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        public void WriteToExcel(string directory, string fileName)
        {
            var header = GetHeader();
            var data = GetData();
            string path = directory + fileName + ".xlsx";
            var excelApp = new Application();
            Workbook book = excelApp.Workbooks.Add();
            Worksheet sheet = book.Sheets[1];

            for (int i = 1; i < header.Count() + 1; i++)
            {
                sheet.Cells[1, i] = header[i - 1];
            }

            int rows = 2;
            int columns = 1;

            foreach (AverageSubject obj in data)
            {
                columns = 1;
                sheet.Cells[rows, columns] = obj.SubjectName;
                foreach (double mark in obj.AverageMarks)
                {
                    columns++;
                    sheet.Cells[rows, columns] = mark;
                }
                rows++;
            }
            book.SaveAs(path);
            book.Close();
            excelApp.Quit();
        }
    }
}
