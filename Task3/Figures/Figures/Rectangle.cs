using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public abstract class Rectangle : IFigure
    {
        double[] sides;

        public Rectangle(double a, double b)
        {
            if(a <= 0 || b <= 0)
            {
                throw new InvalidParametersException();
            }
            sides = new double[] { a, b };
        }

        public double GetPerimeter()
        {
            return 2 * (sides[0] + sides[1]);
        }

        public double GetSquare()
        {
            return sides[0] * sides[1];
        }
    }
}
