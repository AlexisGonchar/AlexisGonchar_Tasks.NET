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
            box.AddFigure(factory.GetFigure(Material.Paper, 8, 9));
            box.AddFigure(factory.GetFigure(Material.Paper, 10, 11, 12));
            return box;
        }

        [Test]
        public void WriteXmlWriter()
        {
            Box box = InitializeFigures();
            XmlIO.XmlWriteAll(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml", box.figures);
        }

        [Test]
        public void ReadXmlReader()
        {
            Box box = XmlIO.XmlRead(@"D:\Mega\Learning\Semester5\Training.by\Tasks\Task3\resources\figures.xml");
            Assert.IsTrue(box.figures[0].Equals(factory.GetFigure(Material.Film, 1)));
        }
    }
}
