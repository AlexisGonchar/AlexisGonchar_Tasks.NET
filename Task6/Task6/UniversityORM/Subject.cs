using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityORM
{
    /// <summary>
    /// Subject class.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Subject identification number.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Subject name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the Subject class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectName"></param>
        public Subject(int id, string subjectName)
        {
            Id = id;
            Name = subjectName;
        }

        /// <summary>
        /// Initializes a new instance of the Subject class.
        /// </summary>
        /// <param name="subjectName"></param>
        public Subject(string subjectName)
        {
            Name = subjectName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Subject subject = obj as Subject;
            if (subject == null)
                return false;
            return Name.Equals(subject.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * 4;
        }
    }
}
