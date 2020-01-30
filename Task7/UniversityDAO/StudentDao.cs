using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with Subjects table.
    /// </summary>
    public class StudentDao : Dao<Student>
    {
        /// <summary>
        /// Initializes a new instance of the StudentDao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public StudentDao(string connString) : base(connString)
        {
        }
    }
}
