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
    }
}
