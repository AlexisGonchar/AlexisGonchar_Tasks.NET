using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityDAO
{
    public class DaoFactory : Factory
    {
        private static DaoFactory instance;
        private static GroupDao groupDao;
        private static SubjectDao subjectDao;
        private static StudentDao studentDao;
        private static ExamDao examDao;
        private static ResultDao resultDao;
        private static ExaminatorDao examinatorDao;
        private static SpecialtyDao specialtyDao;
        private static string connString;

        private DaoFactory()
        {

        }

        public static DaoFactory GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new DaoFactory();
                connString = connectionString;
            }
            return instance;
        }

        public override ExamDao GetExamDao()
        {
            if (examDao == null)
                examDao = new ExamDao(connString);
            return examDao;
        }

        public override GroupDao GetGroupDao()
        {
            if (groupDao == null)
                groupDao = new GroupDao(connString);
            return groupDao;
        }

        public override ResultDao GetResultDao()
        {
            if (resultDao == null)
                resultDao = new ResultDao(connString);
            return resultDao;
        }

        public override StudentDao GetStudentDao()
        {
            if (studentDao == null)
                studentDao = new StudentDao(connString);
            return studentDao;
        }

        public override SubjectDao GetSubjectDao()
        {
            if (subjectDao == null)
                subjectDao = new SubjectDao(connString);
            return subjectDao;
        }

        public override SpecialtyDao GetSpecialtyDao()
        {
            if (specialtyDao == null)
                specialtyDao = new SpecialtyDao(connString);
            return specialtyDao;
        }

        public override ExaminatorDao GetExaminatorDao()
        {
            if (examinatorDao == null)
                examinatorDao = new ExaminatorDao(connString);
            return examinatorDao;
        }
    }
}
