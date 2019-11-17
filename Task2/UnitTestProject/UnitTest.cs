using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestPolynomMultiplication()
        {
            Polynom poly1 = new Polynom(4, 2, 1);
            Polynom poly2 = new Polynom(3, 4, 2, 6);

            Polynom poly3 = poly1 * poly2;

            float[] coffExp = { 12, 22, 19, 32, 14, 6};

            CollectionAssert.AreEqual(coffExp, poly3.Coeff);
        }
    }
}
