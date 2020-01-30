﻿using System.Data.Linq.Mapping;

namespace UniversityORM
{
    [Table(Name = "Specialty")]
    public class Specialty : IEntry
    {
        /// <summary>
        /// Specialty identification number.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }

        public Specialty(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Specialty(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>Boolean true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Specialty specialty = obj as Specialty;
            if (specialty == null)
                return false;
            return Name.Equals(specialty.Name);
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() * 4;
        }
    }
}
