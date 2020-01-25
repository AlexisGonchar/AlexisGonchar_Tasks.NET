using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDAO;
using UniversityORM;
using Microsoft.Office.Interop.Excel;

namespace Report
{
    /// <summary>
    /// Class for createint report.
    /// </summary>
    public class GroupSessionResult
    {
        private static GroupDao groupDao;
        private static SubjectDao subjectDao;
        private static StudentDao studentDao;
        private static ExamDao examDao;
        private static ResultDao resultDao;

        /// <summary>
        /// Initializes a new instance of the GroupSessionResult class.
        /// </summary>
        /// <param name="factory"></param>
        public GroupSessionResult(DaoFactory factory)
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
                "Фамилия", "Имя", "Отчество", "Дата рождения", "Пол",
                "Имя предмета", "Тип экзамена",
                "Дата экзамена", "Отметка"
            };
        }

        /// <summary>
        /// Method for obtaining the necessary data.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="numberOfSession"></param>
        /// <returns></returns>
        public IEnumerable<StudentResult> GetResult(string groupName, int numberOfSession)
        {
            var groups = groupDao.ReadAll();
            var subjects = subjectDao.ReadAll();
            var students = studentDao.ReadAll();
            var exams = examDao.ReadAll();
            var results = resultDao.ReadAll();

            var groupWithId = groups.FirstOrDefault(x => x.Name == groupName);

            var sessionResults = from student in students
                                 join result in results on student.Id equals result.IdStudent
                                 join exam in exams on result.IdExam equals exam.Id
                                 join subject in subjects on exam.IdSubject equals subject.Id
                                 where student.IdGroup == groupWithId.Id & exam.NumberOfSession == numberOfSession
                                 select new StudentResult
                                 {
                                     FirstName = student.FirstName,
                                     MiddleName = student.MiddleName,
                                     LastName = student.LastName,
                                     DateOfBirth = student.DateOfBirth,
                                     Gender = student.Gender,
                                     Date = exam.Date,
                                     SubjectName = subject.Name,
                                     ExamType = exam.Type,
                                     Mark = result.Mark
                                 };

            return sessionResults;
        }

        /// <summary>
        /// Method for writing to a file.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <param name="results"></param>
        public void WriteToExcel(string directory, string fileName, IEnumerable<StudentResult> results)
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
                sheet.Cells[i, 1] = r.Current.LastName;
                sheet.Cells[i, 2] = r.Current.FirstName;
                sheet.Cells[i, 3] = r.Current.MiddleName;
                sheet.Cells[i, 4] = r.Current.DateOfBirth.ToString("MM/dd/yyyy");
                sheet.Cells[i, 5] = r.Current.Gender;
                sheet.Cells[i, 6] = r.Current.SubjectName;
                sheet.Cells[i, 7] = r.Current.ExamType;
                sheet.Cells[i, 8] = r.Current.Date;
                sheet.Cells[i, 9] = r.Current.Mark;
            }

            book.SaveAs(path);
            book.Close();
            excelApp.Quit();
        }
    }
}

