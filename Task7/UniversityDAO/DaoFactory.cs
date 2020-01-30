namespace UniversityDAO
{
    /// <summary>
    /// DaoFactory class.
    /// </summary>
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

        /// <summary>
        /// Gets instance of factory.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DaoFactory GetInstance(string connectionString)
        {
            if (instance == null)
            {
                instance = new DaoFactory();
                connString = connectionString;
            }
            return instance;
        }

        /// <summary>
        /// Gets the DAO exam.
        /// </summary>
        /// <returns></returns>
        public override ExamDao GetExamDao()
        {
            if (examDao == null)
                examDao = new ExamDao(connString);
            return examDao;
        }

        /// <summary>
        /// Gets the DAO group.
        /// </summary>
        /// <returns></returns>
        public override GroupDao GetGroupDao()
        {
            if (groupDao == null)
                groupDao = new GroupDao(connString);
            return groupDao;
        }

        /// <summary>
        /// Gets the DAO result.
        /// </summary>
        /// <returns></returns>
        public override ResultDao GetResultDao()
        {
            if (resultDao == null)
                resultDao = new ResultDao(connString);
            return resultDao;
        }
        /// <summary>
        /// Gets the DAO student.
        /// </summary>
        /// <returns></returns>
        public override StudentDao GetStudentDao()
        {
            if (studentDao == null)
                studentDao = new StudentDao(connString);
            return studentDao;
        }
        /// <summary>
        /// Gets the DAO subject.
        /// </summary>
        /// <returns></returns>
        public override SubjectDao GetSubjectDao()
        {
            if (subjectDao == null)
                subjectDao = new SubjectDao(connString);
            return subjectDao;
        }
        /// <summary>
        /// Gets the DAO specialty.
        /// </summary>
        /// <returns></returns>
        public override SpecialtyDao GetSpecialtyDao()
        {
            if (specialtyDao == null)
                specialtyDao = new SpecialtyDao(connString);
            return specialtyDao;
        }
        /// <summary>
        /// Gets the DAO examinator.
        /// </summary>
        /// <returns></returns>
        public override ExaminatorDao GetExaminatorDao()
        {
            if (examinatorDao == null)
                examinatorDao = new ExaminatorDao(connString);
            return examinatorDao;
        }
    }
}
