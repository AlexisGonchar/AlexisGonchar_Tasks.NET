using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityORM
{
    /// <summary>
    /// Group class
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Group identification number.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Group name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the Group class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupName"></param>
        public Group(int id, string groupName)
        {
            Id = id;
            Name = groupName;
        }

        /// <summary>
        /// Initializes a new instance of the Group class.
        /// </summary>
        /// <param name="groupName"></param>
        public Group(string groupName)
        {
            Name = groupName;
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
            Group group = obj as Group;
            if(group == null)
                return false;
            return Name.Equals(group.Name);
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() * 5;
        }
    }
}
