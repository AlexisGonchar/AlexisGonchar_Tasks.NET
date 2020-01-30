using System;
using System.Collections.Generic;
using System.Linq;
using UniversityORM;
using MySql.Data.MySqlClient;
using DbLinq.MySql;

namespace UniversityDAO
{
    public class GroupDao : Dao<Group>
    {
        public GroupDao(string connString) : base(connString)
        {
        }
    }
}
