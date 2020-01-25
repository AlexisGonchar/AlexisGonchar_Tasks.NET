using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityORM
{
    /// <summary>
    /// Mark class.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Mark identification number.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Student identification number.
        /// </summary>
        public int IdStudent { get; set; }
        /// <summary>
        /// Exam identification number.
        /// </summary>
        public int IdExam { get; set; }
        /// <summary>
        /// Mark for the exam.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        /// Initializes a new instance of the Mark class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idExam"></param>
        /// <param name="idStudent"></param>
        /// <param name="markForExam"></param>
        public Result(int id, int idStudent, int idExam, int markForExam)
        {
            Id = id;
            IdExam = idExam;
            IdStudent = idStudent;
            Mark = markForExam;
        }

        /// <summary>
        /// Initializes a new instance of the Mark class.
        /// </summary>
        /// <param name="idExam"></param>
        /// <param name="idStudent"></param>
        /// <param name="markForExam"></param>
        public Result(int idStudent, int idExam, int markForExam)
        {
            IdExam = idExam;
            IdStudent = idStudent;
            Mark = markForExam;
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
            Result result = obj as Result;
            if (result == null)
                return false;
            return (IdExam.Equals(result.IdExam) && IdStudent.Equals(result.IdStudent) &&
                Mark.Equals(result.Mark));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Mark.GetHashCode() * 4 + IdExam.GetHashCode() + IdStudent.GetHashCode();
        }
    }
}
