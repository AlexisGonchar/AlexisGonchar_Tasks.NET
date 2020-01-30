using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with Groups table.
    /// </summary>
    public class GroupDao : Dao<Group>
    {
        /// <summary>
        /// Initializes a new instance of the GroupDao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public GroupDao(string connString) : base(connString)
        {

        }
    }
}
