using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;
using Figures;
using WorkTable;
using FileIO;

namespace BoxLib
{
    /// <summary>
    /// Box class
    /// </summary>
    public class Box
    {
        private List<IFigure> figures;

        /// <summary>
        /// Constructor for box
        /// </summary>
        public Box()
        {
            figures = new List<IFigure>();
        }

        /// <summary>
        /// Constructor for box
        /// </summary>
        /// <param name="figures"></param>
        public Box(List<IFigure> figures)
        {
            if (figures.Count > 20)
                throw new NoPlaceException();
            this.figures = figures;
        }

        /// <summary>
        /// Put figure into box
        /// </summary>
        /// <param name="figure"></param>
        public void AddFigure(IFigure figure)
        {
            if(figures.Count == 20)
                throw new NoPlaceException();
            
            foreach (IFigure fig in figures)
                if (fig.Equals(figure))
                    throw new SameFigureException();

            figures.Add(figure);
        }

        /// <summary>
        /// Get figure from box
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IFigure GetFigure(int index)
        {
            if (figures.Count == 0)
                throw new EmptyBoxException();
            if (index < 0 || index > figures.Count)
                throw new InvalidParametersException();
            return figures[index - 1];
        }


        /// <summary>
        /// Get and delete figure from box
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IFigure ExtarctFigure(int index)
        {
            IFigure figure = GetFigure(index);
            figures.Remove(figure);
            return figure;
        }

        /// <summary>
        /// Replace figure
        /// </summary>
        /// <param name="index"></param>
        /// <param name="figure"></param>
        public void ReplaceFigures(int index, IFigure figure)
        {
            if (figures.Count == 0)
                throw new EmptyBoxException();
            if (index < 0 || index > figures.Count)
                throw new InvalidParametersException();
            foreach (IFigure fig in figures)
                if (fig.Equals(figure))
                    throw new SameFigureException();

            figures[index - 1] = figure;
        }

        /// <summary>
        /// Find figure in box
        /// </summary>
        /// <param name="sampleFigure"></param>
        /// <returns></returns>
        public IFigure FindFigure(IFigure sampleFigure)
        {
            if (sampleFigure == null)
                throw new ArgumentNullException();
            foreach (IFigure figure in figures)
                if (figure.Equals(sampleFigure))
                    return figure;
            return null;
        }

        /// <summary>
        /// Get figures count in box
        /// </summary>
        /// <returns></returns>
        public int GetFiguresCount()
        {
            return figures.Count();
        }


        /// <summary>
        /// Calculate total area of figures in the box
        /// </summary>
        /// <returns></returns>
        public double GetTotalArea()
        {
            double area = 0;
            foreach (IFigure figure in figures)
                area += figure.GetSquare();
            return area;
        }

        /// <summary>
        /// Calculate total perimeter of figures in the box
        /// </summary>
        /// <returns></returns>
        public double GetTotalPerimeter()
        {
            double perimeter = 0;
            foreach (IFigure figure in figures)
                perimeter += figure.GetPerimeter();
            return perimeter;
        }

        /// <summary>
        /// Get all circles from box
        /// </summary>
        /// <returns></returns>
        public List<IFigure> GetCircles()
        {
            if (figures.Count == 0)
                throw new EmptyBoxException();

            List<IFigure> circles = new List<IFigure>();
            foreach (IFigure figure in figures)
                if (figure is Circle)
                    circles.Add(figure);
            return circles;
        }

        /// <summary>
        /// Get all circles from box
        /// </summary>
        /// <returns></returns>
        public List<IFigure> GetFilmFigures()
        {
            if (figures.Count == 0)
                throw new EmptyBoxException();

            List<IFigure> filmFigures = new List<IFigure>();
            foreach (IFigure figure in figures)
                if (figure is Film)
                    filmFigures.Add(figure);
            return filmFigures;
        }

        /// <summary>
        /// Write method through StreamWriter
        /// </summary>
        /// <param name="filePath"></param>
        public void StreamWrite(string filePath)
        {
            StreamIO.StreamWriteAll(filePath, figures);
        }

        /// <summary>
        /// Write method through StreamWriter
        /// </summary>
        /// <param name="filePath"></param>
        public void StreamWriteFilm(string filePath)
        {
            List<IFigure> paperFigures = new List<IFigure>();
            foreach (IFigure figure in figures)
            {
                if (figure is Film)
                    paperFigures.Add(figure);
            }
            StreamIO.StreamWriteAll(filePath, paperFigures);
        }

        /// <summary>
        /// Write method through StreamWriter
        /// </summary>
        /// <param name="filePath"></param>
        public void StreamWritePaper(string filePath)
        {
            List<IFigure> paperFigures = new List<IFigure>();
            foreach (IFigure figure in figures)
            {
                if (figure is Paper)
                    paperFigures.Add(figure);
            }
            StreamIO.StreamWriteAll(filePath, paperFigures);
        }

        /// <summary>
        /// Write method through XmlWriter
        /// </summary>
        /// <param name="filePath"></param>
        public void XmlWrite(string filePath)
        { 
            XmlIO.XmlWriteAll(filePath, figures);
        }

        /// <summary>
        /// Write method through XmlWriter
        /// </summary>
        /// <param name="filePath"></param>
        public void XmlWritePaper(string filePath)
        {
            List<IFigure> paperFigures = new List<IFigure>();
            foreach (IFigure figure in figures)
            {
                if (figure is Paper)
                    paperFigures.Add(figure);
            }
            XmlIO.XmlWriteAll(filePath, paperFigures);
        }

        /// <summary>
        /// Write method through XmlWriter
        /// </summary>
        /// <param name="filePath"></param>
        public void XmlWriteFilm(string filePath)
        {
            List<IFigure> paperFigures = new List<IFigure>();
            foreach (IFigure figure in figures)
            {
                if (figure is Film)
                    paperFigures.Add(figure);
            }
            XmlIO.XmlWriteAll(filePath, paperFigures);
        }

        /// <summary>
        /// Read method through XmlReader
        /// </summary>
        /// <param name="filePath"></param>
        public void XmlRead(string filePath)
        {
            List<IFigure> figures = XmlIO.XmlRead(filePath);
            if (figures.Count > 20)
                throw new NoPlaceException();
            this.figures = figures;
        }

        /// <summary>
        /// Read method through StreamReader
        /// </summary>
        /// <param name="filePath"></param>
        public void StreamRead(string filePath)
        {
            List<IFigure> figures = StreamIO.StreamRead(filePath);
            if (figures.Count > 20)
                throw new NoPlaceException();
            this.figures = figures;
        }
    }
}
