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

        /// <summary>
        /// Creates record in table.
        /// </summary>
        /// <param name="obj">Object for recording.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
        public void Create(T obj)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                dataContext.GetTable<T>().InsertOnSubmit(obj);
                dataContext.SubmitChanges();
            }
        }

        /// <summary>
        /// Delete record in table.
        /// </summary>
        /// <param name="id">Id of the object to be deleted.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
        public void DeleteById(int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                T obj = dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
                dataContext.GetTable<T>().DeleteOnSubmit(obj);
                dataContext.SubmitChanges();
            }
        }

        /// <summary>
        /// Read record in table.
        /// </summary>
        /// <param name="id">Id of the object to be read.</param>
        /// <returns>Table entry.</returns>
        public T Read(int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                return dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Read all records in table.
        /// </summary>
        /// <returns>All table entry as List.</returns>
        public List<T> ReadAll()
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(sqlConn))
            {
                return dataContext.GetTable<T>().ToList();
            }
        }

        /// <summary>
        /// Update record in table.
        /// </summary>
        /// <param name="obj">Object for updating.</param>
        /// <param name="id">Id of the object to be updated.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
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
