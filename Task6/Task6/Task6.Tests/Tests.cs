﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UniversityDAO;
using UniversityORM;

namespace Task6.Tests
{
    [TestFixture]
    public class Tests
    {
        private static string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
        private static DaoFactory factory = DaoFactory.GetInstance(connString);
        //[Test]
        public void TestInsert()
        {
            
            GroupDao groupDao = new GroupDao(connString);
            groupDao.Create(new Group("ИТП-31"));            
        }

        //[Test]
        public void TestDelete()
        {
            string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
            GroupDao groupDao = new GroupDao(connString);
            groupDao.DeleteById(2);
        }

        //[Test]
        public void InitializationTables()
        {
            string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
            Initialization.InitializeTables(connString);
        }

        [Test]
        public void TestRead()
        {
            GroupDao groupDao = factory.GetGroupDao();
            Group group = groupDao.Read(1);
            Assert.AreEqual("ИТ-11", group.Name);
        }

        [Test]
        public void TestReadAll()
        {
            GroupDao groupDao = factory.GetGroupDao();
            List<Group> groups = groupDao.ReadAll();
            Assert.AreEqual("ИТ-12", groups[1].Name);
        }

        [Test]
        public void TestUpdate()
        {
            GroupDao groupDao = factory.GetGroupDao();
            groupDao.Update(new Group("ИТ-21"), 3);
            Group group = groupDao.Read(3);
            Assert.AreEqual("ИТ-21", group.Name);
        }
    }
}
