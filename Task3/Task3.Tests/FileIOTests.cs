using NUnit.Framework;
using Figures;
using static ExceptionsLib.Exceptions;
using WorkTable;
using FileIO;
using BoxLib;

namespace Task3.Tests
{
    /// <summary>
    /// Tests class for write and read files
    /// </summary>
    [TestFixture]
    public class FileIOTests
    {
        FiguresFactory factory = new FiguresFactory();
        
        private Box InitializeFigures()
        {
            Box box = new Box();
            box.AddFigure(factory.GetFigure(Material.Film, 1));
            box.AddFigure(factory.GetFigure(Material.Film, 2, 3));
            box.AddFigure(factory.GetFigure(Material.Film, 4, 5, 6));
            box.AddFigure(factory.GetFigure(Material.Paper, 7));
            PaintBrush.PaintFigure(box.GetFigure(box.GetFiguresCount()), Paints.Azure);
            box.AddFigure(factory.GetFigure(Material.Paper, 8, 9));
            PaintBrush.PaintFigure(box.GetFigure(box.GetFiguresCount()), Paints.Orange);
            box.AddFigure(factory.GetFigure(Material.Paper, 10, 11, 12));
            PaintBrush.PaintFigure(box.GetFigure(box.GetFiguresCount()), Paints.Pink);
            return box;
        }

        /// <summary>
        /// Test Write through XmlWriter > Read through XmlReader
        /// </summary>
        [Test]
        public void WriteXmlReadXml()
        {
            Box box = InitializeFigures();
            box.XmlWrite(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }

        /// <summary>
        /// Test Write through XmlWriter > Read through StreamReader
        /// </summary>
        [Test]
        public void WriteXmlReadStream()
        {
            Box box = InitializeFigures();
            box.XmlWrite(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }

        /// <summary>
        /// Test Write through StreamWriter > Read through XmlReader
        /// </summary>
        [Test]
        public void WriteStreamReadXml()
        {
            Box box = InitializeFigures();
            box.StreamWrite(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }

        /// <summary>
        /// Test Write through StreamWriter > Read through StreamReader
        /// </summary>
        [Test]
        public void WriteStreamReadStream()
        {
            Box box = InitializeFigures();
            box.StreamWrite(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }

        /// <summary>
        /// Test Write Papers Figures through XmlWriter > Read through XmlReader
        /// </summary>
        [Test]
        public void WriteXmlReadXmlPaper()
        {
            Box box = InitializeFigures();
            box.XmlWritePaper(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\paperFigures.xml");
            IFigure figure = factory.GetFigure(Material.Paper, 7);
            PaintBrush.PaintFigure(figure, Paints.Azure);
            Assert.IsTrue(box.GetFigure(1).Equals(figure));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }

        /// <summary>
        /// Test Write Papers Figures through XmlWriter > Read through StreamReader
        /// </summary>
        [Test]
        public void WriteXmlReadStreamPaper()
        {
            Box box = InitializeFigures();
            box.XmlWritePaper(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\paperFigures.xml");
            IFigure figure = factory.GetFigure(Material.Paper, 7);
            PaintBrush.PaintFigure(figure, Paints.Azure);
            Assert.IsTrue(box.GetFigure(1).Equals(figure));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }

        /// <summary>
        /// Test Write Papers Figures through StreamWriter > Read through XmlReader
        /// </summary>
        [Test]
        public void WriteStreamReadXmlPaper()
        {
            Box box = InitializeFigures();
            box.StreamWritePaper(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\paperFigures.xml");
            IFigure figure = factory.GetFigure(Material.Paper, 7);
            PaintBrush.PaintFigure(figure, Paints.Azure);
            Assert.IsTrue(box.GetFigure(1).Equals(figure));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }

        /// <summary>
        /// Test Write Papers Figures through StreamWriter > Read through StreamReader
        /// </summary>
        [Test]
        public void WriteStreamReadStreamPaper()
        {
            Box box = InitializeFigures();
            box.StreamWritePaper(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\paperFigures.xml");
            IFigure figure = factory.GetFigure(Material.Paper, 7);
            PaintBrush.PaintFigure(figure, Paints.Azure);
            Assert.IsTrue(box.GetFigure(1).Equals(figure));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }

        /// <summary>
        /// Test Write Films Figures through XmlWriter > Read through XmlReader
        /// </summary>
        [Test]
        public void WriteXmlReadXmlFilm()
        {
            Box box = InitializeFigures();
            box.XmlWriteFilm(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\filmFigures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }

        /// <summary>
        /// Test Write Films Figures through XmlWriter > Read through StreamReader
        /// </summary>
        [Test]
        public void WriteXmlReadStreamFilm()
        {
            Box box = InitializeFigures();
            box.XmlWriteFilm(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\filmFigures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }

        /// <summary>
        /// Test Write Films Figures through StreamWriter > Read through XmlReader
        /// </summary>
        [Test]
        public void WriteStreamReadXmlFilm()
        {
            Box box = InitializeFigures();
            box.StreamWriteFilm(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\filmFigures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }

        /// <summary>
        /// Test Write Films Figures through StreamWriter > Read through StreamReader
        /// </summary>
        [Test]
        public void WriteStreamReadStreamFilm()
        {
            Box box = InitializeFigures();
            box.StreamWriteFilm(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");

            box = new Box();
            box.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\filmFigures.xml");
            Assert.IsTrue(box.GetFigure(1).Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 3);
        }
    }
}
