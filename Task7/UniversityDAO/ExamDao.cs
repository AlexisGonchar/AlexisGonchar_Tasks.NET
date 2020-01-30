using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with Exams table.
    /// </summary>
    public class ExamDao : Dao<Exam>
    {
        /// <summary>
        /// Initializes a new instance of the ExamDao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public ExamDao(string connString) : base(connString)
        {
        }
    }
}
