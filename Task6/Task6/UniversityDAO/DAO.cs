using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace UniversityDAO
{
    /// <summary>
    /// Class for working with tables.
    /// </summary>
    /// <typeparam name="T">Universal parameter accepting any types.</typeparam>
    public abstract class Dao<T> : IDao<T>
    {
        private string connString;

        /// <summary>
        /// Initializes a new instance of the Dao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public Dao(string connString)
        {
            this.connString = connString;
        }

        /// <summary>
        /// Creates record in table.
        /// </summary>
        /// <param name="obj">Object for recording.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
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

        /// <summary>
        /// Delete record in table.
        /// </summary>
        /// <param name="id">Id of the object to be deleted.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
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

        /// <summary>
        /// Read record in table.
        /// </summary>
        /// <param name="id">Id of the object to be read.</param>
        /// <returns>Table entry.</returns>
        public T Read(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                Type type = typeof(T);
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                string query = $"SELECT * FROM {table} WHERE id=@id";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    object[] par = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        if (reader.FieldCount != fields.Length)
                        {
                            throw new Exception("The number of type parameters and reader do not match.");
                        }
                        
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            par[i] = reader.GetValue(i);
                        }
                    }
                    return GetObject(par);
                }
                else
                {
                    throw new ArgumentException("Id not found.");
                }
            }
        }

        /// <summary>
        /// Read all records in table.
        /// </summary>
        /// <returns>All table entry as List.</returns>
        public List<T> ReadAll()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                Type type = typeof(T);
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                string query = $"SELECT * FROM {table}";

                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataReader reader = command.ExecuteReader();

                List<T> list = new List<T>();
                if (reader.HasRows)
                {
                    object[] par = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        if (reader.FieldCount != fields.Length)
                        {
                            throw new Exception("The number of type parameters and reader do not match.");
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            par[i] = reader.GetValue(i);
                        }
                        list.Add(GetObject(par));
                        Array.Clear(par, 0, reader.FieldCount);
                    }
                    return list;
                }
                else
                {
                    throw new ArgumentException("Id not found.");
                }
            }
        }

        /// <summary>
        /// Update record in table.
        /// </summary>
        /// <param name="obj">Object for updating.</param>
        /// <param name="id">Id of the object to be updated.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
        public bool Update(T obj, int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                Type type = obj.GetType();
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                MySqlCommand command = new MySqlCommand();

                string values = "";

                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite || field.Name == "Id")
                        continue;
                    
                    values += values == "" ? field.Name + "=@" + field.Name : "," + field.Name + "=@" + field.Name;

                    command.Parameters.AddWithValue("@" + field.Name, field.GetValue(obj));
                }

                string query = $"UPDATE {table} SET {values} WHERE id=@id";

                command.Connection = conn;
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);

                int answer = command.ExecuteNonQuery();

                return (answer > 0) ? true : false;
            }
        }

        private T GetObject(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}
