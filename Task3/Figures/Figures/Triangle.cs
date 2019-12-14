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

        public Triangle(IFigure figure, double a, double b, double c)
        {
            if (!IsExist(a, b, c))
            {
                throw new InvalidParametersException();
            }
            sides = new double[] { a, b, c };
            if (figure.GetSquare() < GetSquare())
            {
                throw new CutException();
            }
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Triangle triangle = obj as Triangle;
            if (triangle == null)
                return false;
            return sides[0] == triangle.sides[0] && sides[1] == triangle.sides[1] && sides[3] == triangle.sides[3];
        }

        public override int GetHashCode()
        {
            return 2 * sides[0].GetHashCode() + 3 * sides[1].GetHashCode() + 4 * sides[2].GetHashCode();
        }

        public override string ToString()
        {
            return "Triangle: sides: A = " + sides[0] + "; B = " + sides[1] + "; C = " + sides[3] + 
                   "; perimeter = " + GetPerimeter() + "; square = " + GetSquare();
        }
    }
}
