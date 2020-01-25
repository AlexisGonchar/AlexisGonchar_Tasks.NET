using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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
