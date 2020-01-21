using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityDAO;
using UniversityORM;

namespace Task6.Tests
{
    public static class Initialization
    {
        private static DaoFactory factory;
        private static Random rand;

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
        private static string[] groupNames = { "ИТ-", "ИТИ-", "ИТП-", "ИП-", "ИС-", "ПЭ-", "Э-"};

        public static void InitializeTables(string connString)
        {
            factory = DaoFactory.GetInstance(connString);
            rand = new Random();
            InitialiazeGroups();
            InitialiazeSubjects();
            //InitializeStudents();
            InitializeExams();
        }

        private static void InitialiazeGroups()
        {
            GroupDao groupDao = factory.GetGroupDao();
            foreach (string groupName in groupNames)
            {
                for(int i = 1; i <= 4; i++)
                {
                    for(int j = 1; j <= 3; j++)
                    {
                        string name = groupName + i + j;
                        Group group = new Group(name);
                        groupDao.Create(group);
                    }
                }                
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
            for (int i = 1; i <= groupNames.Length*12; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    string gender = rand.Next(0, 2) == 0 ? "Мужской" : "Жеский";
                    string firstName = "";
                    string middleName = middleNames[rand.Next(0, middleNames.Length)];
                    string lastName = lastNames[rand.Next(0, lastNames.Length)];
                    if(gender == "Мужской")
                    {
                        firstName = manNames[rand.Next(0, manNames.Length)];
                        middleName += "ич";
                    }else
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
            for(int sessions = 0; sessions < 3; sessions++)
            {
                for (int groupId = 1; groupId <= groupNames.Length * 12; groupId++)
                {
                    int subjectStart = rand.Next(1, subjectNames.Length - 5);
                    for (int exNum = 0; exNum <= 4; exNum++)
                    {
                        string type = rand.Next(0, 2) == 0 ? "Зачёт" : "Экзамен";
                        Exam exam = new Exam(from.AddDays(exNum * 4), groupId, subjectStart + exNum, type);
                        examDao.Create(exam);
                    }
                }
                from = from.AddMonths(6);
            }
        }

        private static DateTime GenRandomDate(DateTime from, DateTime to)
        {
            int daysDiff = (to - from).Days;
            return from.AddDays(rand.Next(daysDiff));
        }
    }
}
