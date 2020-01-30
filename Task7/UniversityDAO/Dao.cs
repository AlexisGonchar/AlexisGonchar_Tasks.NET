using System;
using System.Collections.Generic;
using System.Linq;
using DbLinq.MySql;
using MySql.Data.MySqlClient;
using System.Reflection;
using UniversityORM;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with tables.
    /// </summary>
    /// <typeparam name="T">Universal parameter accepting any types.</typeparam>
    public class Dao<T> : IDao<T> where T : class, IEntry
    {
        private MySqlConnection sqlConn;

        /// <summary>
        /// Initializes a new instance of the Dao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public Dao(string connString)
        {
            sqlConn = new MySqlConnection(connString);
        }

        public void Create(T obj)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                dataContext.GetTable<T>().InsertOnSubmit(obj);
                dataContext.SubmitChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                T obj = dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
                dataContext.GetTable<T>().DeleteOnSubmit(obj);
                dataContext.SubmitChanges();
            }
        }

        public T Read(int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                return dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<T> ReadAll()
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                return dataContext.GetTable<T>().ToList();
            }
        }

        public void Update(T obj, int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                T oldObj = dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
                Type type = typeof(T);
                PropertyInfo[] fields = type.GetProperties();
                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite || field.Name == "Id")
                        continue;
                    type.GetProperty(field.Name).SetValue(oldObj, type.GetProperty(field.Name).GetValue(obj));
                }
                dataContext.SubmitChanges();
            }
        }
    }
}
