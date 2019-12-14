using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public abstract class Triangle : IFigure
    {
        private double[] sides;
        public Triangle(double a, double b, double c)
        {
            if(!IsExist(a, b, c))
            {
                throw new InvalidParametersException();
            }
            sides = new double[] { a, b, c };
        }

        private bool IsExist(double a, double b, double c)
        {
            return 
                (a > 0) && (b > 0) && (c > 0) && (a + b > c) && (a + c > b) && (b + c > a);
        }
        public double GetSquare()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }

        public double GetPerimeter()
        {
            double perimeter = 0;
            foreach(double side in sides)
            {
                perimeter += side;
            }
            return perimeter;
        }
    }
}
