using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace UniversityDAO
{
    public abstract class Dao<T> : IDao<T>
    {
        private string connString;
        public Dao(string connString)
        {
            this.connString = connString;
        }

        public bool Create(T obj)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                Type type = obj.GetType();
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                string values = "";
                string columns = "";

                MySqlCommand command = new MySqlCommand();

                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite || field.Name == "Id")
                        continue;

                    columns += field.Name + ", ";
                    values += "@" + field.Name + ", ";

                    command.Parameters.AddWithValue("@" + field.Name, field.GetValue(obj));
                }

                values = values.Substring(0, values.Length - 2);
                columns = columns.Substring(0, columns.Length - 2);

                string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";

                command.Connection = conn;
                command.CommandText = query;
                int answer = command.ExecuteNonQuery();

                return (answer > 0) ? true : false;
            }
        }

        public bool DeleteById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                Type type = typeof(T);
                string table = type.Name + "s";

                conn.Open();

                string query = $"DELETE FROM {table} WHERE id=@id";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                int answer = command.ExecuteNonQuery();

                return (answer > 0) ? true : false;
            }
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
