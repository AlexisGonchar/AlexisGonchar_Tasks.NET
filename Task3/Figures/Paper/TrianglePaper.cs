using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Triangle of paper class
    /// </summary>
    public class TrianglePaper : Triangle, Paper
    {
        private Paints color;

        /// <summary>
        /// Constructor for crating triangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public TrianglePaper(double a, double b, double c) : base(a, b, c)
        {
        }

        public Paints GetColor()
        {
            return color;
        }

        public void Paint(Paints newColor)
        {
            if (color != null)
            {
                throw new ImpossibleToPaintException();
            }
            color = newColor;
        }
    }
}
