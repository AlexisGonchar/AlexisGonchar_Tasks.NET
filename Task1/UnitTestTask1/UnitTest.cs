using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NODLibrary;

namespace UnitTestTask1
{
    [TestClass]
    public class UnitTest
    {
        Random rand = new Random();

        private bool CheckResult(int gcd, params int[] numbers)
        {
            foreach(int number in numbers)
            {
                if (number % gcd != 0)
                    return false;
            }
            return true;
        }

        [TestMethod]
        public void TestMethodGcdEuclid()
        {
            double time;
            int a, b, c, d, e, gcd;
            for(int i = 0; i < 100; i++)
            {
                time = 0;
                a = rand.Next(-1000, 1001);
                b = rand.Next(-1000, 1001);
                c = rand.Next(-1000, 1001);
                d = rand.Next(-1000, 1001);
                e = rand.Next(-1000, 1001);

                gcd = NOD.findGcdEuclid(a, b, c, d, e, ref time);

                Assert.IsTrue(CheckResult(gcd, a, b, c, d, e));
            }
        }

        [TestMethod]
        public void TestMethodGcdEuclidTwoNumbers()
        {
            double time;
            int a, b, gcd;
            for (int i = 0; i < 100; i++)
            {
                time = 0;
                a = rand.Next(-1000, 1001);
                b = rand.Next(-1000, 1001);

                gcd = NOD.findGcdEuclid(a, b, ref time);

                Assert.IsTrue(CheckResult(gcd, a, b));
            }
        }

        [TestMethod]
        public void TestMethodGcdStein()
        {
            double time;
            int a, b, gcd;
            for (int i = 0; i < 100; i++)
            {
                time = 0;
                a = rand.Next(-1000, 1001);
                b = rand.Next(-1000, 1001);

                gcd = NOD.findGcdStein(a, b, ref time);

                Assert.IsTrue(CheckResult(gcd, a, b));
            }
        }
    }
}
