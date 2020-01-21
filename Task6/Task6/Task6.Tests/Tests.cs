using System;
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
        [Test]
        public void Test()
        {
            string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
            GroupDao group = new GroupDao(connString);
            group.Create(new Group("ИТП-31"));
        }
    }
}
