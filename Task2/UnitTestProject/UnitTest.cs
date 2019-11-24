using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;
using System.Collections;

namespace UnitTestProject
{
    /// <summary>
    /// Tests class
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        const float TOLERANCE = 0.01f;

        Vector3 vec1 = new Vector3(27.2f, -113, 86.1f);
        Vector3 vec2 = new Vector3(2.3f, 66.6f, 0);

        Polynom poly1 = new Polynom(1.7f, 2.5f, 0, 23, 17, 1);
        Polynom poly2 = new Polynom(-9.3f, 16.9f, 17.9f, -41, 6, 19.4f, 1);

        /// <summary>
        /// Vector comparison method
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public bool VectorCheck(Vector3 vec1, Vector3 vec2)
        {
            return Math.Abs(vec1.X - vec2.X) < TOLERANCE &&
                   Math.Abs(vec1.Y - vec2.Y) < TOLERANCE &&
                   Math.Abs(vec1.Z - vec2.Z) < TOLERANCE;
        }

        /// <summary>
        /// Polynomial comparison method
        /// </summary>
        /// <param name="poly1"></param>
        /// <param name="poly2"></param>
        /// <returns></returns>
        public bool PolynomCheck(Polynom poly1, Polynom poly2)
        {
            for(int i = 0; i < poly1.Degree + 1; i++)
                if ((poly1.Coeff[i] - poly2.Coeff[i]) > TOLERANCE)
                    return false;
            return true;
        }

        /// <summary>
        /// Check polynomial addition
        /// </summary>
        [TestMethod]
        public void TestPolynomAddition()
        {
            Assert.IsTrue(PolynomCheck(new Polynom(-7.6f, 19.4f, 17.9f, -18, 23, 20.4f, 1), poly1 + poly2));
        }

        /// <summary>
        /// Check polynomial subtraction
        /// </summary>
        [TestMethod]
        public void TestPolynomSubtraction()
        {
            Assert.IsTrue(PolynomCheck(new Polynom(11, -14.4f, -17.9f, 64, 11, -18.4f, -1), poly1 - poly2));
        }

        /// <summary>
        /// Check polynomial multiplication
        /// </summary>
        [TestMethod]
        public void TestPolynomMultiplication()
        {
            Assert.IsTrue(PolynomCheck(new Polynom(-15.81f, 5.48f, 72.68f, -238.85f, 138.3f, 737.68f, -571.6f, -538.6f, 507.2f, 358.8f, 36.4f, 1), poly1 * poly2));
        }

        /// <summary>
        /// Check vector addition
        /// </summary>
        [TestMethod]
        public void TestVectorAddition()
        {
            Assert.IsTrue(VectorCheck(new Vector3(29.5f, -46.4f, 86.1f), vec1 + vec2));
        }

        /// <summary>
        /// Check vector subtraction
        /// </summary>
        [TestMethod]
        public void TestVectorSubtraction()
        {
            Assert.IsTrue(VectorCheck(new Vector3(24.9f, -179.6f, 86.1f), vec1 - vec2));
        }

        /// <summary>
        /// Check vector multiplication
        /// </summary>
        [TestMethod]
        public void TestVectorMultiplication()
        {
            Assert.IsTrue(VectorCheck(new Vector3(-5734.26f, 198.03f, 2071.42f), vec1 ^ vec2));
        }

        /// <summary>
        /// Check scalar multiplication
        /// </summary>
        [TestMethod]
        public void TestVectorScalarMultiplication()
        {
            Assert.IsTrue(-7463.24f - (vec1 * vec2) < TOLERANCE);
        }
    }
}
