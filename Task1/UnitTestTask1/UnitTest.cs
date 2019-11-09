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

        [TestMethod]
        public void TestMethod3()
        {
            int a = 624,
                b = 1364,
                c = 836,
                expGcd = 4,
                actualGcd = NOD.findGcdEuclid(a, b, c);
            Assert.AreEqual(expGcd, actualGcd);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int a = 624,
                b = 1364,
                c = 836,
                e = 12,
                expGcd = 4,
                actualGcd = NOD.findGcdEuclid(a, b, c, e);
            Assert.AreEqual(expGcd, actualGcd);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int a = 624,
                b = 1364,
                c = 836,
                e = 12,
                d = 24,
                expGcd = 4,
                actualGcd = NOD.findGcdEuclid(a, b, c, e, d);
            Assert.AreEqual(expGcd, actualGcd);
        }
    }
}
