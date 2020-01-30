using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with Specialty table.
    /// </summary>
    public class SpecialtyDao : Dao<Specialty>
    {
        /// <summary>
        /// Initializes a new instance of the SpecialtyDao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public SpecialtyDao(string connString) : base(connString)
        {
        }
    }
}
