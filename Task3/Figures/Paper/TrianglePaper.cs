using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Class representing a paper triangle
    /// </summary>
    public class TrianglePaper : Triangle, Paper
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        private Paints color;

        /// <summary>
        /// Initializes a new instance of the TrianglePaper class
        /// </summary>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TrianglePaper(double a, double b, double c) : base(a, b, c)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TrianglePaper class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TrianglePaper(IFigure figure, double a, double b, double c) : base(figure, a, b, c)
        {
            if (!(figure is Paper))
            {
                throw new CutException();
            }
            this.color = ((Paper)figure).GetColor();
        }

        /// <summary>
        /// Get figure's color
        /// </summary>
        public Paints GetColor()
        {
            return color;
        }

        /// <summary>
        /// Paint method
        /// </summary>
        /// <param name="newColor"></param>
        public void Paint(Paints newColor)
        {
            if (color != Paints.None)
            {
                throw new ImpossibleToPaintException();
            }
            color = newColor;
        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            TrianglePaper trianglePaper = obj as TrianglePaper;
            if (trianglePaper == null)
                return false;
            return base.Equals(obj) && trianglePaper.GetColor() == GetColor();
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + 2 + GetColor().GetHashCode();
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "; material = Paper; color = " + GetColor().ToString();
        }
    }
}
