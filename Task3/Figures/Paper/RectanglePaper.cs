using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Class representing a paper rectangle
    /// </summary>
    public class RectanglePaper : Rectangle, Paper
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        private Paints color;

        /// <summary>
        /// Initializes a new instance of the RectanglePaper class
        /// </summary>
        /// <param name="a"> Width of a rectangle</param>
        /// <param name="b"> Height of a rectangle</param>
        public RectanglePaper(double a, double b) : base(a, b)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RectanglePaper class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="b"> Width of a rectangle</param>
        /// <param name="a"> Height of a rectangle</param>
        public RectanglePaper(IFigure figure, double a, double b) : base(figure, a, b)
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
            RectanglePaper rectanglePaper = obj as RectanglePaper;
            if (rectanglePaper == null)
                return false;
            return base.Equals(obj) && rectanglePaper.GetColor() == GetColor();
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
