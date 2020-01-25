using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
    /// <summary>
    /// Class StudentResult.
    /// </summary>
    public class StudentResult
    {
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
        /// Group name.
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// Subject name.
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// Exam type.
        /// </summary>
        public string ExamType { get; set; }
        /// <summary>
        /// Mark for the exam.
        /// </summary>
        public int Mark { get; set; }
        /// <summary>
        /// Date and time when the exam will be held.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
