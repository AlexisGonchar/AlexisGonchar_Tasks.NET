using NUnit.Framework;
using Figures;
using static ExceptionsLib.Exceptions;
using WorkTable;

namespace Task3.Tests
{
    [TestFixture]
    public class FiguresTests
    {
        FiguresFactory factory = new FiguresFactory();

        /// <summary>
        /// Check GetSquare method
        /// </summary>
        /// <param name="expectArea"></param>
        /// <param name="values"></param>
        [TestCase(6, 5, 4, 3)]                     //Triangle
        [TestCase(10.82532f, 5, 5, 5)]
        [TestCase(0.830246f, 1.1f, 1.5427f, 1.7f)]
        [TestCase(0.75f, 1.5f, 1.0f, 1.8028f)]
        [TestCase(20, 5, 4)]                       //Rectangle
        [TestCase(100, 10, 10)]
        [TestCase(39.48f, 8.4f, 4.7f)]
        [TestCase(8.25f, 2.5f, 3.3f)]
        [TestCase(12.56637f, 2)]                   //Circle
        [TestCase(113.09733f, 6)]
        [TestCase(3.14159f, 1)]
        [TestCase(5.72555f, 1.35f)]
        public void CheckArea(double expectArea, params double[] values)
        {
            IFigure figure = factory.CreateFigure(Material.Film, values);

            Assert.AreEqual(expectArea, figure.GetSquare(), 0.00001f);
        }

        /// <summary>
        /// Check GetPerimeter method
        /// </summary>
        /// <param name="expectPerimeter"></param>
        /// <param name="values"></param>
        [TestCase(12, 5, 4, 3)]                     //Triangle
        [TestCase(15, 5, 5, 5)]
        [TestCase(4.3427f, 1.1f, 1.5427f, 1.7f)]
        [TestCase(4.3028f, 1.5f, 1.0f, 1.8028f)]
        [TestCase(18, 5, 4)]                       //Rectangle
        [TestCase(40, 10, 10)]
        [TestCase(26.2f, 8.4f, 4.7f)]
        [TestCase(11.6f, 2.5f, 3.3f)]
        [TestCase(12.56637f, 2)]                   //Circle
        [TestCase(37.69911f, 6)]
        [TestCase(6.28318f, 1)]
        [TestCase(8.48230f, 1.35f)]
        public void CheckPerimeter(double expectPerimeter, params double[] values)
        {
            IFigure figure = factory.CreateFigure(Material.Film, values);

            Assert.AreEqual(expectPerimeter, figure.GetPerimeter(), 0.00001f);
        }
    }
}
