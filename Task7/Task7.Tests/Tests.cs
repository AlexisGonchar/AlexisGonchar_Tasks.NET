using NUnit.Framework;
using UniversityDAO;
using UniversityORM;
using Report;

namespace Task7.Tests
{
    [TestFixture]
    public class Tests
    {
        private static string connString = "Server=localhost;Database=universitydb;port=3306;User Id=root";
        DaoFactory factory = DaoFactory.GetInstance(connString);

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
            Group group = new Group("ИТ-11", 1);
            groupDao.Update(group, 1);
        }

        [Test]
        public void TestDelete()
        {
            ResultDao resultDao = factory.GetResultDao();
            resultDao.DeleteById(2);
        }

        [Test]
        public void TestInit()
        {
            Initialization.InitializeTables(connString);
        }

        [Test]
        public void TestAverageSpecialtyReport()
        {
            AverageSpecialtyReport report = new AverageSpecialtyReport(factory);
            ExcelWriter<AverageSpecialty>.WriteToExcel(@"D:\", "rep", report.GetHeader(), report.GetData(2)); 
        }
        [Test]
        public void TestAverageExaminatorReport()
        {
            AverageExaminatorReport report = new AverageExaminatorReport(factory);
            ExcelWriter<AverageExaminator>.WriteToExcel(@"D:\", "rep2", report.GetHeader(), report.GetData(1));
        }
    }
}
