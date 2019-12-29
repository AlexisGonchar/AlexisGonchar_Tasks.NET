using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    /// <summary>
    /// A class describing a student.
    /// </summary>
    [Serializable]
    public class Student : IComparable
    {
        /// <summary>
        /// The student name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The test name.
        /// </summary>
        public string TestName { get; set; }
        /// <summary>
        /// Test date.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Test mark.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class.
        /// </summary>
        public Student()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Student class.
        /// </summary>
        /// <param name=Initializes a new instance of the Client class."name">The student name.</param>
        /// <param name="testName">The test name.</param>
        /// <param name="date">Test date.</param>
        /// <param name="mark">Test mark.</param>
        public Student(string name, string testName, DateTime date, int mark)
        {
            Name = name;
            TestName = testName;
            Date = date;
            Mark = mark;
        }

        /// <summary>
        /// Student Object Comparison.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if(obj is Student)
            {
                Student st = (Student)obj;
                if (st.Mark < Mark)
                    return 1;
                else if (st.Mark > Mark)
                    return -1;
                else
                    return 0;
            }else
            {
                throw new InvalidCastException("Unable to cast types.");
            }
        }
    }
}
