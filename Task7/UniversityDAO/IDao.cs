﻿using System.Collections.Generic;

namespace UniversityDAO
{
    /// <summary>
    /// Interface defining methods for working with tables.
    /// </summary>
    /// <typeparam name="T">Universal parameter accepting any types.</typeparam>
    public interface IDao<T> 
    {
        /// <summary>
        /// Creates record in table.
        /// </summary>
        /// <param name="obj">Object for recording.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
        void Create(T obj);

        /// <summary>
        /// Update record in table.
        /// </summary>
        /// <param name="obj">Object for updating.</param>
        /// <param name="id">Id of the object to be updated.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
        void Update(T obj, int id);

        /// <summary>
        /// Delete record in table.
        /// </summary>
        /// <param name="id">Id of the object to be deleted.</param>
        /// <returns>true if the operation was successful; otherwise, false.</returns>
        void DeleteById(int id);

        /// <summary>
        /// Read record in table.
        /// </summary>
        /// <param name="id">Id of the object to be read.</param>
        /// <returns>Table entry.</returns>
        T Read(int id);

        /// <summary>
        /// Read all records in table.
        /// </summary>
        /// <returns>All table entry as List.</returns>
        List<T> ReadAll();
    }
}
