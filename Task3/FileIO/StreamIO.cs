using System;
using System.Collections.Generic;
using Figures;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using WorkTable;

namespace FileIO
{
    /// <summary>
    /// Class for write and read through StreamWriter and StreamReader
    /// </summary>
    public static class StreamIO
    {
        private static FiguresFactory factory = new FiguresFactory();

        /// <summary>
        /// Write method through StreamWriter
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="figures"></param>
        public static void StreamWriteAll(string filePath, List<IFigure> figures)
        {
            StreamWriter stream = new StreamWriter(filePath);

            XDocument document = new XDocument();
            XElement elements = new XElement("figures");
            
            foreach(IFigure fig in figures)
            {
                XElement figure = new XElement("figure");
                Material materia = fig is Paper ? Material.Paper : Material.Film;
                XElement material = new XElement("material", materia.ToString());
                figure.Add(material);
                if (fig is Circle)
                {
                    Circle circle = (Circle)fig;
                    XElement form = new XElement("form", "Circle");
                    XElement radius = new XElement("radius", circle.radius);
                    figure.Add(form, radius);
                    XElement color = null;
                    if (materia == Material.Paper)
                    {
                        color = new XElement("color", (int)((Paper)fig).GetColor());
                        figure.Add(color);
                    }
                }
                else if (fig is Rectangle)
                {
                    Rectangle rect = (Rectangle)fig;
                    XElement form = new XElement("form", "Rectangle");
                    XElement sideA = new XElement("sideA", rect.sides[0]);
                    XElement sideB = new XElement("sideB", rect.sides[1]);
                    figure.Add(form, sideA, sideB);
                    XElement color = null;
                    if (materia == Material.Paper)
                    {
                        color = new XElement("color", (int)((Paper)fig).GetColor());
                        figure.Add(color);
                    }
                }
                else
                {
                    Triangle triangle = (Triangle)fig;
                    XElement form = new XElement("form", "Triangle");
                    XElement sideA = new XElement("sideA", triangle.sides[0]);
                    XElement sideB = new XElement("sideB", triangle.sides[1]);
                    XElement sideC = new XElement("sideC", triangle.sides[2]);
                    figure.Add(form, sideA, sideB, sideC);
                    XElement color = null;
                    if (materia == Material.Paper)
                    {
                        color = new XElement("color", (int)((Paper)fig).GetColor());
                        figure.Add(color);
                    }
                }
                elements.Add(figure);
            }
            document.Add(elements);
            document.Save(stream);
            stream.Close();
        }

        /// <summary>
        /// Read method through StreamReadr
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<IFigure> StreamRead(string filePath)
        {
            List<IFigure> figures = new List<IFigure>();

            StreamReader stream = new StreamReader(filePath);
            XDocument document = XDocument.Load(stream);
            XElement xRoot = document.Element("figures");
            foreach(XElement xe in xRoot.Elements("figure").ToList())
            {
                switch (xe.Element("material").Value)
                {
                    case "Paper":
                        FiguresAdd(xe, figures, Material.Paper);
                        Paints paint = (Paints)int.Parse(xe.Element("color").Value);
                        PaintBrush.PaintFigure(figures[figures.Count - 1], paint);
                        break;
                    case "Film":
                        FiguresAdd(xe, figures, Material.Film);
                        break;
                }
            }
            stream.Close();
            return figures;
        }

        private static void FiguresAdd(XElement xe, List<IFigure> figures, Material material)
        {
            double a, b, c;

            switch (xe.Element("form").Value)
            {
                case "Circle":
                    a = int.Parse(xe.Element("radius").Value);
                    figures.Add(factory.GetFigure(material, a));
                    break;
                case "Rectangle":
                    a = int.Parse(xe.Element("sideA").Value);
                    b = int.Parse(xe.Element("sideB").Value);
                    figures.Add(factory.GetFigure(material, a, b));
                    break;
                case "Triangle":
                    a = int.Parse(xe.Element("sideA").Value);
                    b = int.Parse(xe.Element("sideB").Value);
                    c = int.Parse(xe.Element("sideC").Value);
                    figures.Add(factory.GetFigure(material, a, b, c));
                    break;
            }
        }
    }
}
