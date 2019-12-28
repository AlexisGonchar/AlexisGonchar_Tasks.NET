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

        [Test]
        public void TestAdd()
        {
            BinaryTree<Student> tree = InitTree();
            Assert.AreEqual(tree.Left.Left.Data.Mark, 4);
        }

        [Test]
        public void TestDeserialize()
        {
            BinaryTree<Student> tree = InitTree();
            tree.Serialize(AppDomain.CurrentDomain.BaseDirectory + "/tree.xml");
            BinaryTree<Student> tree1 = new BinaryTree<Student>();
            tree1.Deserialize(AppDomain.CurrentDomain.BaseDirectory + "/tree.xml");
            Assert.AreEqual(tree1.Left.Left.Data.Mark, 4);
        }

        [Test]
        public void TestSearch()
        {
            Student st = new Student("JoJo", "WitchCraft", DateTime.Now, 10);
            BinaryTree<Student> tree = InitTree();
            tree.Add(st);
            Student st1 = tree.Search(st).Data;
            Assert.AreEqual(st.CompareTo(st1), 0);
        }

        [Test]
        public void TestRemove()
        {
            Student st = new Student("JoJo", "WitchCraft", DateTime.Now, 10);
            BinaryTree<Student> tree = InitTree();
            tree.Add(st);
            tree.Remove(st);
            Assert.AreEqual(null, tree.Search(st));
        }
    }
}
