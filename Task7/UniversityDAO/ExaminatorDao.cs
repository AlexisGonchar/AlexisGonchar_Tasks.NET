using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with Examinator table.
    /// </summary>
    public class ExaminatorDao : Dao<Examinator>
    {
        /// <summary>
        /// Initializes a new instance of the ExaminatorDao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public ExaminatorDao(string connString) : base(connString)
        {
        }
    }
}
