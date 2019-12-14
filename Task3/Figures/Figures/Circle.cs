using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public abstract class Circle : IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            if(radius <= 0)
            {
                throw new InvalidParametersException();
            }
            this.radius = radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double GetSquare()
        {
            return Math.PI * radius * radius;
        }
    }
}
