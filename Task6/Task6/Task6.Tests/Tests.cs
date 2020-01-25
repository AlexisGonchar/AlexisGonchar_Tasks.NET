using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UniversityDAO;
using UniversityORM;
using Report;

namespace Task6.Tests
{
    /// <summary>
    /// Class for testing classes.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private static string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
        private static DaoFactory factory = DaoFactory.GetInstance(connString);

        /// <summary>
        /// initialize database.
        /// </summary>
        //[Test]
        public void InitializationTables()
        {
            string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
            Initialization.InitializeTables(connString);
        }

        /// <summary>
        /// Method for testing read method.
        /// </summary>
        [Test]
        public void TestRead()
        {
            GroupDao groupDao = factory.GetGroupDao();
            Group group = groupDao.Read(1);
            Group expectedGroup = new Group("ИТ-11");
            Assert.AreEqual(expectedGroup, group);
        }

        /// <summary>
        /// Method for testing readall method.
        /// </summary>
        [Test]
        public void TestReadAll()
        {
            GroupDao groupDao = factory.GetGroupDao();
            List<Group> groups = groupDao.ReadAll();
            Group group = groups[1];
            Group expectedGroup = new Group("ИТ-12");
            Assert.AreEqual(expectedGroup, group);
        }

        /// <summary>
        /// Method for testing update method.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            GroupDao groupDao = factory.GetGroupDao();
            groupDao.Update(new Group("ИТ-21"), 3);
            Group group = groupDao.Read(3);
            Group expectedGroup = new Group("ИТ-21");
            Assert.AreEqual(expectedGroup, group);
        }

        /// <summary>
        /// Method for testing delete method.
        /// </summary>
        [Test]
        public void TestDelete()
        {
            ResultDao resultDao = factory.GetResultDao();
            var results = resultDao.ReadAll();
            int exCount = results.Count();
            resultDao.DeleteById(3);
            int count = resultDao.ReadAll().Count();
            Assert.AreEqual(exCount - 1, count);
        }

        [Test]
        public void TestExcel1()
        {
            GroupSessionResult sres = new GroupSessionResult(factory);
            var results = sres.GetResult("ИТИ-12", 2);
            sres.WriteToExcel(@"D:\", "rep", results);
        }

        [Test]
        public void TestExcel2()
        {
            SessionResult sres = new SessionResult(factory);
            var results = sres.GetResult(2);
            sres.WriteToExcel(@"D:\", "rep2", results);
        }
    }
}
