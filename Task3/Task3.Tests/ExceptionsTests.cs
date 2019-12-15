using NUnit.Framework;
using Figures;
using static ExceptionsLib.Exceptions;
using WorkTable;
using BoxLib;

namespace Task3.Tests
{
    /// <summary>
    /// Class for exception tests 
    /// </summary>
    [TestFixture]
    public class ExceptionsTests
    {
        FiguresFactory factory = new FiguresFactory();
        Shears shears = new Shears();

        /// <summary>
        /// InvalidPapametersException test
        /// </summary>
        /// <param name="material"></param>
        /// <param name="values"></param>
        [TestCase (Material.Film, -1)]
        [TestCase(Material.Film, 0, 5)]
        [TestCase(Material.Film, -10, 5, -1)]
        [TestCase(Material.Paper, 1, 5, 1)]
        [TestCase(Material.Paper, 0)]
        [TestCase(Material.Paper, 6, -7)]
        public void InvalidParametersTest(Material material, params double[] values)
        {
            TestDelegate func = delegate
            {
                IFigure figure = factory.CreateFigure(material, values);
            };
            Assert.Catch<InvalidParametersException>(func);
        }

        /// <summary>
        /// CutException test
        /// </summary>
        /// <param name="values"></param>
        [TestCase(4)]
        [TestCase(5,5,5)]
        [TestCase(4, 10)]
        [TestCase(6, 7)]
        public void CutExceptionTest(params double[] values)
        {
            TestDelegate func = delegate
            {
                IFigure figure = factory.CreateFigure(Material.Film, 5, 6);
                IFigure cutFigure = shears.CreateFigure(figure, values);
            };
            Assert.Catch<CutException>(func);
        }

        /// <summary>
        /// ImpossibleToPaintException test
        /// </summary>
        /// <param name="material"></param>
        /// <param name="values"></param>
        [TestCase(Material.Film, 1)]
        [TestCase(Material.Film, 1, 5)]
        [TestCase(Material.Film, 1, 5, 5)]
        [TestCase(Material.Paper, 7)]
        [TestCase(Material.Paper, 1, 5, 5)]
        [TestCase(Material.Paper, 1, 1)]
        public void ImpossibleToPaintTest(Material material, params double[] values)
        {
            TestDelegate func = delegate
            {
                IFigure figure = factory.CreateFigure(material, values);
                PaintBrush.PaintFigure(figure, Paints.Black);
                PaintBrush.PaintFigure(figure, Paints.Blue);
            };
            Assert.Catch<ImpossibleToPaintException>(func);
        }

        /// <summary>
        /// NoPlaceException test
        /// </summary>
        [Test]
        public void NoPlaceTest()
        {
            TestDelegate func = delegate
            {
                Box box = new Box();
                for (int i = 1; i <= 21; i++)
                {
                    box.AddFigure(factory.CreateFigure(Material.Film, i));
                }
            };
            Assert.Catch<NoPlaceException>(func);
        }

        /// <summary>
        /// SameFiguresException test
        /// </summary>
        /// <param name="material"></param>
        /// <param name="values"></param>
        [TestCase(Material.Film, 1)]
        [TestCase(Material.Film, 1, 5)]
        [TestCase(Material.Film, 1, 5, 5)]
        [TestCase(Material.Paper, 7)]
        [TestCase(Material.Paper, 1, 5, 5)]
        [TestCase(Material.Paper, 1, 1)]
        public void SameFigureTest(Material material, params double[] values)
        {
            TestDelegate func = delegate
            {
                Box box = new Box();
                box.AddFigure(factory.CreateFigure(material, values));
                box.AddFigure(factory.CreateFigure(material, values));
            };
            Assert.Catch<SameFigureException>(func);
        }

        /// <summary>
        /// EmptyBoxException test
        /// </summary>
        [Test]
        public void EmptyBoxTest()
        {
            TestDelegate func1 = delegate
            {
                Box box = new Box();
                box.GetCircles();
            };
            TestDelegate func2 = delegate
            {
                Box box = new Box();
                box.GetFigure(1);
            };
            TestDelegate func3 = delegate
            {
                Box box = new Box();
                box.ReplaceFigures(1, factory.GetFigure(Material.Paper, 1));
            };
            Assert.Catch<EmptyBoxException>(func1);
            Assert.Catch<EmptyBoxException>(func2);
            Assert.Catch<EmptyBoxException>(func3);
        }
    }
}
