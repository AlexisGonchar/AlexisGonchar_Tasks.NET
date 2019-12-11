using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CheckMaterialTestMethod()
        {
            TrianglePaper triangle = new TrianglePaper(1, 1, 1);
            Assert.IsTrue(triangle is Paper);
        }
    }
}
