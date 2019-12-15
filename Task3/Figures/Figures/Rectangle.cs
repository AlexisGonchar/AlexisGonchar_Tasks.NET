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
        public double[] sides;

        public Rectangle(double a, double b)
        {
            if(a <= 0 || b <= 0)
            {
                throw new InvalidParametersException();
            }
            sides = new double[] { a, b };
        }

        public Rectangle(IFigure figure, double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new InvalidParametersException();
            }
            sides = new double[] { a, b };
            if (figure.GetSquare() < GetSquare())
            {
                throw new CutException();
            }
        }

        public double GetPerimeter()
        {
            return 2 * (sides[0] + sides[1]);
        }

        public double GetSquare()
        {
            return sides[0] * sides[1];
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
            Rectangle rectangle = obj as Rectangle;
            if (rectangle == null)
                return false;
            return sides[0] == rectangle.sides[0] && sides[1] == rectangle.sides[1];
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 5 * sides[0].GetHashCode() + 2 * sides[1].GetHashCode();
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Triangle: sides: A = " + sides[0] + "; B = " + sides[1] +
                   "; perimeter = " + GetPerimeter() + "; square = " + GetSquare();
        }
    }
}
