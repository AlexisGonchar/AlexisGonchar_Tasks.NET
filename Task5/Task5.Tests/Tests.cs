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
    /// <summary>
    /// Class for testing classes.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Method for creating a binary tree.
        /// </summary>
        /// <returns></returns>
        public BinaryTree<Student> InitTree()
        {
            BinaryTree<Student> tree = new BinaryTree<Student>();
            tree.Add(new Student("Bob", "English", DateTime.Now, 9));
            tree.Add(new Student("John", "Algebra", DateTime.Now, 6));
            tree.Add(new Student("Alex", "Geometry", DateTime.Now, 7));
            tree.Add(new Student("Donald", "Biology", DateTime.Now, 4));
            tree.Add(new Student("Floyd", "Chemistry", DateTime.Now, 20));
            tree.Add(new Student("Roach", "Science", DateTime.Now, 30));
            tree.Add(new Student("Christopher", "Literature", DateTime.Now, 15));
            return tree;
        }

        /// <summary>
        /// Method for testing binary tree with integer.
        /// </summary>
        [Test]
        public void TestAddInt()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            
            tree.Add(6);
            var node = tree.Search(6);

            Assert.AreEqual(node.Data, 6);
        }

        /// <summary>
        /// Method for testing binary tree with double.
        /// </summary>
        [Test]
        public void TestAddDouble()
        {
            BinaryTree<double> tree = new BinaryTree<double>();

            tree.Add(6.5);
            var node = tree.Search(6.5);

            Assert.AreEqual(node.Data, 6.5);
        }

        /// <summary>
        /// Method for testing binary tree with string.
        /// </summary>
        [Test]
        public void TestAddString()
        {
            BinaryTree<string> tree = new BinaryTree<string>();

            tree.Add("Jeronimo");
            var node = tree.Search("Jeronimo");

            Assert.AreEqual(node.Data, "Jeronimo");
        }

        /// <summary>
        /// Method for testing adding data to a binary tree.
        /// </summary>
        [Test]
        public void TestAdd()
        {
            BinaryTree<Student> tree = InitTree();
            Assert.AreEqual(tree.Left.Left.Data.Mark, 4);
        }

        /// <summary>
        /// Method for testing write and read binary tree.
        /// </summary>
        [Test]
        public void TestDeserialize()
        {
            BinaryTree<Student> tree = InitTree();
            tree.Serialize(AppDomain.CurrentDomain.BaseDirectory + "/tree.xml");
            BinaryTree<Student> tree1 = new BinaryTree<Student>();
            tree1.Deserialize(AppDomain.CurrentDomain.BaseDirectory + "/tree.xml");
            Assert.AreEqual(tree1.Left.Left.Data.Mark, 4);
        }

        /// <summary>
        /// Method for testing data search in a binary tree.
        /// </summary>
        [Test]
        public void TestSearch()
        {
            Student st = new Student("JoJo", "WitchCraft", DateTime.Now, 10);
            BinaryTree<Student> tree = InitTree();
            tree.Add(st);
            Student st1 = tree.Search(st).Data;
            Assert.AreEqual(st.CompareTo(st1), 0);
        }

        /// <summary>
        /// Method for testing data deletion from a binary tree.
        /// </summary>
        [Test]
        public void TestRemove()
        {
            Student st = new Student("JoJo", "WitchCraft", DateTime.Now, 10);
            BinaryTree<Student> tree = InitTree();
            tree.Add(st);
            tree.Remove(st);
            Assert.AreEqual(null, tree.Search(st));
        }

        /// <summary>
        /// Method for testing binary tree balancing.
        /// </summary>
        [Test]
        public void TestBalance()
        {
            BinaryTree<Student> tree = new BinaryTree<Student>();
            tree.Add(new Student("Bob", "English", DateTime.Now, 1));
            tree.Add(new Student("John", "Algebra", DateTime.Now, 2));
            tree.Add(new Student("Alex", "Geometry", DateTime.Now, 3));
            tree.Add(new Student("Donald", "Biology", DateTime.Now, 4));
            tree.Add(new Student("Floyd", "Chemistry", DateTime.Now, 5));
            tree.Add(new Student("Roach", "Science", DateTime.Now, 6));
            tree.Add(new Student("Christopher", "Literature", DateTime.Now, 7));

            tree.BalanceTree();

            Assert.AreEqual(tree.Left.Right.Data.Mark, 3);
        }

        /// <summary>
        /// Method for testing binary tree balancing.
        /// </summary>
        [Test]
        public void TestBalance2()
        {
            BinaryTree<Student> tree = new BinaryTree<Student>();
            tree.Add(new Student("Bob", "English", DateTime.Now, 7));
            tree.Add(new Student("John", "Algebra", DateTime.Now, 6));
            tree.Add(new Student("Alex", "Geometry", DateTime.Now, 5));
            tree.Add(new Student("Donald", "Biology", DateTime.Now, 4));
            tree.Add(new Student("Floyd", "Chemistry", DateTime.Now, 3));
            tree.Add(new Student("Roach", "Science", DateTime.Now, 2));
            tree.Add(new Student("Christopher", "Literature", DateTime.Now, 1));

            tree.BalanceTree();

            Assert.AreEqual(tree.Left.Right.Data.Mark, 3);
        }
    }
}
