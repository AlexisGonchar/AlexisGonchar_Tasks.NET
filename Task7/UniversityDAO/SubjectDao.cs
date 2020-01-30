using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with Subjects table.
    /// </summary>
    public class SubjectDao : Dao<Subject>
    {
        /// <summary>
        /// Initializes a new instance of the SubjectDao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public SubjectDao(string connString) : base(connString)
        {
        }
    }
}
