using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UniversityDAO;
using UniversityORM;

namespace Task7.Tests
{
    [TestFixture]
    public class Tests
    {
        private static string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
        string connectionString = "Persist Security Info=False;Integrated Security=SSPI;database= universitydb;server= localhost;Connect Timeout=30";
        [Test]
        public void Test()
        {
            GroupDao groupDao = new GroupDao(connString);
            Group group = groupDao.Read(1);
            Assert.AreEqual("ИТ-11", group.Name);
        }

        [Test]
        public void TestUpdate()
        {
            GroupDao groupDao = new GroupDao(connString);
            Group group = new Group { Name = "ИТ-11" };
            groupDao.Update(group, 1);
        }

        [Test]
        public void TestDelete()
        {
            GroupDao groupDao = new GroupDao(connString);
            groupDao.DeleteById(1);
        }
    }
}
