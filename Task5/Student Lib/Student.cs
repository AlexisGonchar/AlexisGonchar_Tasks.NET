using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    [Serializable]
    public class Student : IComparable
    {
        public string Name { get; set; }
        public string TestName { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }

        public Student()
        {

        }

        public Student(string name, string testName, DateTime date, int mark)
        {
            Name = name;
            TestName = testName;
            Date = date;
            Mark = mark;
        }

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
