using NUnit.Framework;
using Figures;
using static ExceptionsLib.Exceptions;
using WorkTable;
using FileIO;

namespace Task3.Tests
{
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

        [Test]
        public void WriteXmlReadXml()
        {
            Box box = InitializeFigures();
            XmlIO.XmlWriteAll(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml", box.figures);

            box = XmlIO.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.figures[0].Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }

        [Test]
        public void WriteXmlReadStream()
        {
            Box box = InitializeFigures();
            XmlIO.XmlWriteAll(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml", box.figures);

            box = StreamIO.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.figures[0].Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }

        [Test]
        public void WriteStreamReadXml()
        {
            Box box = InitializeFigures();
            StreamIO.StreamWriterAll(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml", box.figures);

            box = XmlIO.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.figures[0].Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }

        [Test]
        public void WriteStreamReadStream()
        {
            Box box = InitializeFigures();
            StreamIO.StreamWriterAll(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml", box.figures);

            box = StreamIO.StreamRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.figures[0].Equals(factory.GetFigure(Material.Film, 1)));
            Assert.AreEqual(box.GetFiguresCount(), 6);
        }
    }
}
