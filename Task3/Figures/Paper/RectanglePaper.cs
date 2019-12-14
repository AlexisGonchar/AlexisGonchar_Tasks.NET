using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;
using WorkTable;

namespace Figures
{
    public class RectanglePaper : Rectangle, Paper
    {
        private Paints color;
        public RectanglePaper(double a, double b) : base(a, b)
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
