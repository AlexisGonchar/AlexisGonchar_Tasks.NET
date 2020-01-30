using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDAO;
using UniversityORM;

namespace Task7.Tests
{
    /// <summary>
    /// Class for generate data in database.
    /// </summary>
    public static class Initialization
    {
        private static DaoFactory factory;
        private static Random rand;

        private static string[] examinatorNames = { "Соболев Д.В.", "Комракова Е.В.", "Курочка К.С.", "Комраков В.В.", "Стефановский И.Л.", "Титова Л.К.", "Асенчик О.Д."};
        private static string[] manNames = { "Алексей", "Кирилл", "Игорь", "Егор", "Владислав",
            "Гордей", "Дмитрий", "Владимир", "Степан", "Константин", "Сергей", "Иван",
            "Евгений", "Александр", "Михаил", "Артём", "Николай" };
        private static string[] womanNames = { "Ирина", "Анастасия", "Ангелина", "Виктория",
            "Евгения", "Ольга", "Надежда", "Любовь", "Карина", "Гертруда", "Кристина", "Диана",
            "Александа", "Мария", "Анна", "Дарья", "Елена", "Наталья", "Милана", "Екатерина",
            "Вероника" };
        private static string[] lastNames = { "Гончар", "Чекан", "Стельченко", "Гумар", "Адамович",
            "Шулякевич", "Данченко", "Федоренко", "Кравченко", "Жмайлик", "Карась", "Шпак", "Сетко",
            "Пайцун", "Довженок", "Мартинович", "Шубенок", "Пархоменко", "Романюк", "Хмеленок" };
        private static string[] middleNames = { "Алексеев", "Михайлов", "Кириллов", "Игорев", "Владиславов",
            "Владимиров", "Дмитрев", "Николаев", "Иванов", "Артёмов", "Александров", "Гордеев", "Степанов",
            "Константинов", "Сергеев", "Евгеньев" };
        private static string[] subjectNames = { "Объектно-ориентированное программирование", "Математика",
            "Физика", "Материаловедение", "Психология", "Философия", "Политология",
            "Безопасность жизнедеятельности человека", "Мировая художественная культура",
            "Основы дизайна", "Основы маркетинга", "Экономика", "Химия" };
        private static string[] groupNames = { "ИТ-", "ИТИ-", "ИТП-", "ИП-", "ПЭ-" };
        private static string[] specialtyNames = { "Информационнные системы и технологии", "Игровой дизайн",
            "Промышленные информационные системы", "Информатика и технологии программирования",
            "Промышленная электроника" };

        private static int countOfCourses = 4;
        private static int countOfSubgroups = 1;
        private static int countOfExams = 2;
        private static int countOfSessions = 2;
        private static int countOfStudents = 5;

        /// <summary>
        /// Method for generate data in database.
        /// </summary>
        /// <param name="connString"></param>
        public static void InitializeTables(string connString)
        {
            factory = DaoFactory.GetInstance(connString);
            rand = new Random();
            InitialiazeSpecialty();
            InitialiazeExaminator();
            InitialiazeGroups();
            InitialiazeSubjects();
            InitializeStudents();
            InitializeExams();
            InitializeResults();
        }

        private static void InitialiazeSpecialty()
        {
            SpecialtyDao specialtyDao = factory.GetSpecialtyDao();
            foreach (string specialtyName in specialtyNames)
            {
                Specialty specialty = new Specialty(specialtyName);
                specialtyDao.Create(specialty);
            }
        }

        private static void InitialiazeExaminator()
        {
            ExaminatorDao examinatorDao = factory.GetExaminatorDao();
            foreach (string examinatorName in examinatorNames)
            {
                Examinator examinator = new Examinator(examinatorName);
                examinatorDao.Create(examinator);
            }
        }

        private static void InitialiazeGroups()
        {
            GroupDao groupDao = factory.GetGroupDao();
            int specialtyId = 1;
            foreach (string groupName in groupNames)
            {
                for (int i = 1; i <= countOfCourses; i++)
                {
                    for (int j = 1; j <= countOfSubgroups; j++)
                    {
                        string name = groupName + i + j;
                        Group group = new Group(name, specialtyId);
                        groupDao.Create(group);
                    }
                }
                specialtyId++;
            }
        }

        private static void InitialiazeSubjects()
        {
            SubjectDao subjectDao = factory.GetSubjectDao();
            foreach (string subjectName in subjectNames)
            {
                Subject subject = new Subject(subjectName);
                subjectDao.Create(subject);
            }
        }

        private static void InitializeStudents()
        {
            StudentDao studentDao = factory.GetStudentDao();
            DateTime from = new DateTime(1990, 1, 1);
            DateTime to = new DateTime(2002, 12, 31);
            for (int i = 1; i <= groupNames.Length * countOfCourses * countOfSubgroups; i++)
            {
                for (int j = 0; j < countOfStudents; j++)
                {
                    string gender = rand.Next(0, 2) == 0 ? "Мужской" : "Женский";
                    string firstName = "";
                    string middleName = middleNames[rand.Next(0, middleNames.Length)];
                    string lastName = lastNames[rand.Next(0, lastNames.Length)];
                    if (gender == "Мужской")
                    {
                        firstName = manNames[rand.Next(0, manNames.Length)];
                        middleName += "ич";
                    }
                    else
                    {
                        firstName = womanNames[rand.Next(0, womanNames.Length)];
                        middleName += "на";
                    }
                    DateTime dateOfBirth = GenRandomDate(from, to);
                    Student student = new Student(firstName, middleName, lastName, gender, dateOfBirth, i);
                    studentDao.Create(student);
                }
            }
        }

        private static void InitializeExams()
        {
            ExamDao examDao = factory.GetExamDao();
            DateTime from = new DateTime(2018, 1, 8);
            int numberOfSession = 1;
            for (int sessions = 0; sessions < countOfSessions; sessions++)
            {
                for (int groupId = 1; groupId <= groupNames.Length * countOfCourses * countOfSubgroups; groupId++)
                {
                    int subjectStart = rand.Next(1, subjectNames.Length - countOfExams);
                    for (int exNum = 0; exNum < countOfExams; exNum++)
                    {
                        string type = rand.Next(0, 2) == 0 ? "Зачёт" : "Экзамен";
                        int examinatorId = rand.Next(1, examinatorNames.Length+1);
                        Exam exam = new Exam(from.AddDays(exNum * 4), groupId, subjectStart + exNum, examinatorId, type, numberOfSession);
                        examDao.Create(exam);
                    }
                }
                from = from.AddMonths(6);
                numberOfSession++;
            }
        }

        private static void InitializeResults()
        {
            ResultDao resultDao = factory.GetResultDao();
            int studentId = 1;
            int groupsCount = groupNames.Length * countOfCourses * countOfSubgroups;
            for (int groupId = 1; groupId <= groupsCount; groupId++)
            {
                for (int student = 0; student < countOfStudents; student++)
                {
                    for (int examId = groupId * countOfExams - (countOfExams - 1); examId <= countOfExams * groupsCount * countOfSessions; examId += countOfExams * groupsCount)
                    {
                        for (int exNum = 0; exNum < countOfExams; exNum++)
                        {
                            int mark = rand.Next(1, 11);
                            Result result = new Result(studentId, examId + exNum, mark);
                            resultDao.Create(result);
                        }
                    }
                    studentId++;
                }
            }
        }

        private static DateTime GenRandomDate(DateTime from, DateTime to)
        {
            int daysDiff = (to - from).Days;
            return from.AddDays(rand.Next(daysDiff));
        }
    }
}
