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
    public class Mark
    {
        /// <summary>
        /// Mark identification number.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Exam identification number.
        /// </summary>
        public int IdExam { get; set; }
        /// <summary>
        /// Student identification number.
        /// </summary>
        public int IdStudent { get; set; }
        /// <summary>
        /// Mark for the exam.
        /// </summary>
        public int MarkForExam { get; set; }

        /// <summary>
        /// Initializes a new instance of the Mark class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idExam"></param>
        /// <param name="idStudent"></param>
        /// <param name="markForExam"></param>
        public Mark(int id, int idExam, int idStudent, int markForExam)
        {
            Id = id;
            IdExam = idExam;
            IdStudent = idStudent;
            MarkForExam = markForExam;
        }
    }
}
