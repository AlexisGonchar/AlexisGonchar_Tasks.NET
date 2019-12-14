using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionsLib;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public class CirclePaper : Circle, Paper
    {
        private Paints color;
        public CirclePaper(double radius) : base(radius)
        {
        }

        public Paints GetColor()
        {
            return color;
        }

        public void Paint(Paints newColor)
        {
            if(color != null)
            {
                throw new ImpossibleToPaintException();
            }
            color = newColor;
        }
    }
}
