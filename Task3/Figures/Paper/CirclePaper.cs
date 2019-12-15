using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionsLib;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Class representing a paper circle
    /// </summary>
    public class CirclePaper : Circle, Paper
    {
        /// <summary>
        /// Figure's color
        /// </summary>
        private Paints color;

        /// <summary>
        /// Initializes a new instance of the CirclePaper class
        /// </summary>
        /// <param name="radius"> Circle radius</param>
        public CirclePaper(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CirclePaper class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="radius"> Circle radius</param>
        public CirclePaper(IFigure figure, double radius) : base(figure, radius)
        {
            if(!(figure is Paper))
            {
                throw new CutException();
            }
            this.color = ((Paper)figure).GetColor();
        }

        /// <summary>
        /// Gert figure's color
        /// </summary>
        public Paints GetColor()
        {
            return color;
        }

        /// <summary>
        /// Paint mathod
        /// </summary>
        /// <param name="newColor"></param>
        public void Paint(Paints newColor)
        {
            if(color != Paints.None)
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
            CirclePaper circlePaper = obj as CirclePaper;
            if (circlePaper == null)
                return false;
            return base.Equals(obj) && circlePaper.GetColor() == GetColor();
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
