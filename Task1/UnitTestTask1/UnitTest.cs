using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NODLibrary;

namespace UnitTestTask1
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 30,
                b = 18,
                expGcd = 6,
                actualGcd = NOD.findGcdEuclid(a, b);
            Assert.AreEqual(expGcd, actualGcd);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int a = 1071,
                b = 462,
                expGcd = 21,
                actualGcd = NOD.findGcdEuclid(a, b);
            Assert.AreEqual(expGcd, actualGcd);
        }
    }
}
