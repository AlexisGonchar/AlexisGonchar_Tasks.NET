using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with Results table.
    /// </summary>
    public class ResultDao : Dao<Result>
    {
        /// <summary>
        /// Initializes a new instance of the ResultDao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public ResultDao(string connString) : base(connString)
        {
        }
    }
}
