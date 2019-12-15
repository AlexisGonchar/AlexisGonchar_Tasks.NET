using System;
using System.Collections.Generic;
using Figures;
using WorkTable;
using System.Xml;

namespace FileIO
{
    public static class XmlIO
    {
        private static FiguresFactory factory = new FiguresFactory();

        public static void XmlWriteAll(string filePath, List<IFigure> figures)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter writer = XmlWriter.Create(filePath, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("figures");
            foreach(IFigure figure in figures)
            {
                writer.WriteStartElement("figure");
                Material material = figure is Paper ? Material.Paper : Material.Film;
                writer.WriteElementString("material", material.ToString());
                if(figure is Circle)
                {
                    Circle circle = (Circle)figure;
                    writer.WriteElementString("form", "Circle");
                    writer.WriteElementString("radius", circle.radius.ToString());
                    if(material == Material.Paper)
                        writer.WriteElementString("color", ((int)((Paper)figure).GetColor()).ToString());
                }
                else if(figure is Rectangle)
                {
                    Rectangle rectangle = (Rectangle)figure;
                    writer.WriteElementString("form", "Rectangle");
                    writer.WriteElementString("sideA", rectangle.sides[0].ToString());
                    writer.WriteElementString("sideB", rectangle.sides[1].ToString());
                    if (material == Material.Paper)
                        writer.WriteElementString("color", ((int)((Paper)figure).GetColor()).ToString());
                }
                else
                {
                    Triangle triangle = (Triangle)figure;
                    writer.WriteElementString("form", "Triangle");
                    writer.WriteElementString("sideA", triangle.sides[0].ToString());
                    writer.WriteElementString("sideB", triangle.sides[1].ToString());
                    writer.WriteElementString("sideC", triangle.sides[2].ToString());
                    if (material == Material.Paper)
                        writer.WriteElementString("color", ((int)((Paper)figure).GetColor()).ToString());
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
                            reader.Read();
                            Paints paint = (Paints)int.Parse(reader.ReadInnerXml());
                            PaintBrush.PaintFigure(box.GetFigure(box.GetFiguresCount()), paint); 
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
            reader.Read();
            String value = reader.ReadInnerXml();
            switch (value)
            {
                case "Circle":
                    reader.Read();
                    a = int.Parse(reader.ReadInnerXml());
                    box.AddFigure(factory.GetFigure(material, a));
                    break;
                case "Rectangle":
                    reader.Read();
                    a = int.Parse(reader.ReadInnerXml());
                    reader.Read();
                    b = int.Parse(reader.ReadInnerXml());
                    box.AddFigure(factory.GetFigure(material, a, b));
                    break;
                case "Triangle":
                    reader.Read();
                    a = int.Parse(reader.ReadInnerXml());
                    reader.Read();
                    b = int.Parse(reader.ReadInnerXml());
                    reader.Read();
                    c = int.Parse(reader.ReadInnerXml());
                    box.AddFigure(factory.GetFigure(material, a, b, c));
                    break;
            }
        }
    }
}