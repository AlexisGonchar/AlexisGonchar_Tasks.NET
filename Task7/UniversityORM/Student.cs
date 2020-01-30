using System;
using System.Data.Linq.Mapping;

namespace UniversityORM 
{
    /// <summary>
    /// Student class.
    /// </summary>
    [Table(Name = "Students")]
    public class Student : IEntry
    {
        /// <summary>
        /// Student identification number.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        /// <summary>
        /// Student first name.
        /// </summary>
        [Column(Name = "FirstName")]
        public string FirstName { get; set; }
        /// <summary>
        /// Student middle name.
        /// </summary>
        [Column(Name = "MiddleName")]
        public string MiddleName { get; set; }
        /// <summary>
        /// Student last name.
        /// </summary>
        [Column(Name = "LastName")]
        public string LastName { get; set; }
        /// <summary>
        /// Student gender.
        /// </summary>
        [Column(Name = "Gender")]
        public string Gender { get; set; }
        /// <summary>
        /// Student date of birth.
        /// </summary>
        [Column(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Identification number of the group that the student belongs to.
        /// </summary>
        [Column(Name = "IdGroup")]
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
        /// <summary>
        /// Initializes a new instance of the Student class.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="gender"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="idGroup"></param>
        public Student(string firstName, string middleName, string lastName,
            string gender, DateTime dateOfBirth, int idGroup)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            IdGroup = idGroup;
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
            Student student = obj as Student;
            if (student == null)
                return false;
            return (FirstName.Equals(student.FirstName) && LastName.Equals(student.LastName) &&
                MiddleName.Equals(student.MiddleName) && Gender.Equals(student.Gender) &&
                DateOfBirth.Equals(student.DateOfBirth) && IdGroup.Equals(student.IdGroup));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() * 5 + LastName.GetHashCode() + DateOfBirth.GetHashCode();
        }
    }

}
