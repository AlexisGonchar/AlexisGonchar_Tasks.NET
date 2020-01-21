using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using UniversityORM;

namespace UniversityDAO
{
    public class GroupDao : Dao<Group>
    {
        public GroupDao(string connString) : base(connString)
        {

        }
    }
}
