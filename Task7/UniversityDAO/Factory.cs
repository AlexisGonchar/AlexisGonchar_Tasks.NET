namespace UniversityDAO
{
    /// <summary>
    /// Abstract class for DaoFactory.
    /// </summary>
    public abstract class Factory
    {
        /// <summary>
        /// Gets the DAO group.
        /// </summary>
        /// <returns></returns>
        public abstract GroupDao GetGroupDao();
        /// <summary>
        /// Gets the DAO subject.
        /// </summary>
        /// <returns></returns>
        public abstract SubjectDao GetSubjectDao();
        /// <summary>
        /// Gets the DAO student.
        /// </summary>
        /// <returns></returns>
        public abstract StudentDao GetStudentDao();
        /// <summary>
        /// Gets the DAO exam.
        /// </summary>
        /// <returns></returns>
        public abstract ExamDao GetExamDao();
        /// <summary>
        /// Gets the DAO result.
        /// </summary>
        /// <returns></returns>
        public abstract ResultDao GetResultDao();
        /// <summary>
        /// Gets the DAO specialty.
        /// </summary>
        /// <returns></returns>
        public abstract SpecialtyDao GetSpecialtyDao();
        /// <summary>
        /// Gets the DAO examinator.
        /// </summary>
        /// <returns></returns>
        public abstract ExaminatorDao GetExaminatorDao();
    }
}
