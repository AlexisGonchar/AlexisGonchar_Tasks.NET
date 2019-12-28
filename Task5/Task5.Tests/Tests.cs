using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinaryTree;
using StudentLib;

namespace Task5.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestMethod()
        {
            BinaryTree<Student> tree = new BinaryTree<Student>();
            tree.Add(new Student("Bob", "English", DateTime.Now, 9));
            tree.Add(new Student("John", "Algebra", DateTime.Now, 6));
            tree.Add(new Student("Alex", "Geometry", DateTime.Now, 7));
            tree.Add(new Student("Donald", "Biology", DateTime.Now, 4));
            tree.Add(new Student("Floyd", "Chemistry", DateTime.Now, 20));
            tree.Add(new Student("Roach", "Science", DateTime.Now, 30));
            tree.Add(new Student("Christopher", "Literature", DateTime.Now, 15));
            tree.Serialize();
        }
    }
}
