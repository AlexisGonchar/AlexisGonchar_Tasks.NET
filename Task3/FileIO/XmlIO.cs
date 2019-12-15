using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using WorkTable;
using static ExceptionsLib.Exceptions;
using System.Xml;

namespace FileIO
{
    public static class XmlIO
    {
        private static FiguresFactory factory = new FiguresFactory();

        public static void XmlWriteAll(string filePath, List<IFigure> figures)
        {
            XmlWriter writer = XmlWriter.Create(filePath);
            writer.WriteStartDocument();
            writer.WriteStartElement("figures");
            foreach(IFigure figure in figures)
            {
                writer.WriteStartElement("figure");
                String material = figure is Paper ? "Paper" : "Film";
                writer.WriteElementString("material", material);
                if(figure is Circle)
                {
                    Circle circle = (Circle)figure;
                    writer.WriteElementString("form", "Circle");
                    writer.WriteElementString("radius", circle.radius.ToString());
                }
                else if(figure is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)figure;
                    writer.WriteElementString("form", "Rectangle");
                    writer.WriteElementString("sideA", rectangle.sides[0].ToString());
                    writer.WriteElementString("sideB", rectangle.sides[1].ToString());
                }else
                {
                    Triangle triangle = (Triangle)figure;
                    writer.WriteElementString("form", "Triangle");
                    writer.WriteElementString("sideA", triangle.sides[0].ToString());
                    writer.WriteElementString("sideB", triangle.sides[1].ToString());
                    writer.WriteElementString("sideC", triangle.sides[2].ToString());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public static Box XmlRead(String filePath)
        {
            Box box = new Box();

            XmlReader reader = XmlReader.Create(filePath);
            while (reader.Read())
            {
                if (reader.Name == "material")
                {
                    String value = reader.ReadInnerXml();
                    switch (value)
                    {
                        case "Paper":
                            FiguresAdd(reader, box, Material.Paper);
                            break;
                        case "Film":
                            FiguresAdd(reader, box, Material.Film);
                            break;
                    }
                }
            }
            reader.Close();
            return box;
        }

        private static void FiguresAdd(XmlReader reader, Box box, Material material)
        {
            double a, b, c;
            String value = reader.ReadInnerXml();
            switch (value)
            {
                case "Circle":
                    a = int.Parse(reader.ReadInnerXml());
                    box.AddFigure(factory.GetFigure(material, a));
                    break;
                case "Rectangle":
                    a = int.Parse(reader.ReadInnerXml());
                    b = int.Parse(reader.ReadInnerXml());
                    box.AddFigure(factory.GetFigure(material, a, b));
                    break;
                case "Triangle":
                    a = int.Parse(reader.ReadInnerXml());
                    b = int.Parse(reader.ReadInnerXml());
                    c = int.Parse(reader.ReadInnerXml());
                    box.AddFigure(factory.GetFigure(material, a, b, c));
                    break;
            }
        }
    }
}