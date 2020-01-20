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
        public string GroupName { get; set; }

        /// <summary>
        /// Initializes a new instance of the Group class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupName"></param>
        public Group(int id, string groupName)
        {
            Id = id;
            GroupName = groupName;
        }

        /// <summary>
        /// Initializes a new instance of the Group class.
        /// </summary>
        /// <param name="groupName"></param>
        public Group(string groupName)
        {
            GroupName = groupName;
        }
    }
}
