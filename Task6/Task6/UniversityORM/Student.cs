using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityORM
{
    /// <summary>
    /// Student class.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student identification number.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Student first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Student middle name.
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Student last name.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Student gender.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Student date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Identification number of the group that the student belongs to.
        /// </summary>
        public int IdGroup { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="gender"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="idGroups"></param>
        public Student(int id, string firstName, string middleName, string lastName, 
            string gender, DateTime dateOfBirth, int idGroup)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            IdGroup = idGroup;
        }

    }
}
