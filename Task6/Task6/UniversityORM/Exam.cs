using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityORM
{
    /// <summary>
    /// Exam class.
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Exam identification number.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Date and time when the exam will be held.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Identification number of the subject for which the exam will be conducted.
        /// </summary>
        public int IdSubject { get; set; }
        /// <summary>
        /// Identification number of the group where the exam will be held
        /// </summary>
        public int IdGroup { get; set; }
        /// <summary>
        /// Exam type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the Exam class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="idSubject"></param>
        /// <param name="idGroup"></param>
        /// <param name="type"></param>
        public Exam(int id, DateTime date, int idSubject, int idGroup, string type)
        {
            Id = id;
            Date = date;
            IdSubject = idSubject;
            IdGroup = idGroup;
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the Exam class.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idSubject"></param>
        /// <param name="idGroup"></param>
        /// <param name="type"></param>
        public Exam(DateTime date, int idSubject, int idGroup, string type)
        {
            Date = date;
            IdSubject = idSubject;
            IdGroup = idGroup;
            Type = type;
        }
    }
}
