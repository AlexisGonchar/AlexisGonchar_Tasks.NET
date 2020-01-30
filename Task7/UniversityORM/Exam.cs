using System;
using System.Data.Linq.Mapping;

namespace UniversityORM
{
    /// <summary>
    /// Exam class.
    /// </summary>
    [Table(Name = "Exams")]
    public class Exam : IEntry
    {
        /// <summary>
        /// Exam identification number.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        /// <summary>
        /// Date and time when the exam will be held.
        /// </summary>
        [Column(Name = "Date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Identification number of the group where the exam will be held
        /// </summary>
        [Column(Name = "IdGroup")]
        public int IdGroup { get; set; }
        /// <summary>
        /// Identification number of the subject for which the exam will be conducted.
        /// </summary>
        [Column(Name = "IdSubject")]
        public int IdSubject { get; set; }
        /// <summary>
        /// Identification number of the examinator.
        /// </summary>
        [Column(Name = "IdExaminator")]
        public int IdExaminator { get; set; }
        /// <summary>
        /// Exam type.
        /// </summary>
        [Column(Name = "Type")]
        public string Type { get; set; }
        /// <summary>
        /// Number of session.
        /// </summary>
        [Column(Name = "NumberOfSession")]
        public int NumberOfSession { get; set; }

        /// <summary>
        /// Initializes a new instance of the Exam class.
        /// </summary>
        public Exam(){}

        /// <summary>
        /// Initializes a new instance of the Exam class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="idSubject"></param>
        /// <param name="idGroup"></param>
        /// <param name="type"></param>
        /// <param name="numberOfSession"></param>
        public Exam(int id, DateTime date, int idGroup, int idSubject, int idExaminator, string type, int numberOfSession)
        {
            Id = id;
            Date = date;
            IdSubject = idSubject;
            IdGroup = idGroup;
            Type = type;
            NumberOfSession = numberOfSession;
            IdExaminator = idExaminator;
        }

        /// <summary>
        /// Initializes a new instance of the Exam class.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idSubject"></param>
        /// <param name="idGroup"></param>
        /// <param name="type"></param>
        /// <param name="numberOfSession"></param>
        public Exam(DateTime date, int idGroup, int idSubject, int idExaminator, string type, int numberOfSession)
        {
            Date = date;
            IdSubject = idSubject;
            IdGroup = idGroup;
            Type = type;
            NumberOfSession = numberOfSession;
            IdExaminator = idExaminator;
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
            Exam exam = obj as Exam;
            if (exam == null)
                return false;
            return (Date.Equals(exam.Date) && IdSubject.Equals(exam.IdSubject) &&
                IdGroup.Equals(exam.IdGroup) && Type.Equals(exam.Type)) &&
                NumberOfSession.Equals(exam.NumberOfSession) &&
                IdExaminator.Equals(exam.IdExaminator);
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Date.GetHashCode() * 4 + IdSubject.GetHashCode() + Type.GetHashCode();
        }
    }
}
