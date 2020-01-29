using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityORM;
using System.Data.Linq;
using DbLinq.Data.Linq;
using DbLinq.Vendor;
using MySql.Data.MySqlClient;

namespace UniversityDAO
{
    public class GroupDao : IDao<Group>
    {
        private string ConnectionString { get; set; }

        public GroupDao(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool Create(Group obj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Group Read(int id)
        {
            using (DbLinq.MySql.MySqlDataContext dataContext = new DbLinq.MySql.MySqlDataContext(new MySqlConnection(ConnectionString)))
            {
                return dataContext.GetTable<Group>().FirstOrDefault(x => x.Id == id);
            }
            
        }

        public List<Group> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Group obj, int id)
        {
            using (DbLinq.MySql.MySqlDataContext dataContext = new DbLinq.MySql.MySqlDataContext(new MySqlConnection(ConnectionString)))
            {
                Group group = dataContext.GetTable<Group>().FirstOrDefault(x => x.Id == id);
                /// <summary> Properties update. </summary>
                group.Name = obj.Name;
                dataContext.SubmitChanges();
            }
        }
    }
}
