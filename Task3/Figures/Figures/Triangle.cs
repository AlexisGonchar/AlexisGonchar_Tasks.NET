using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Class representing an triangle
    /// </summary>
    public abstract class Triangle : IFigure
    {
        /// <summary>
        /// Sides of triangle
        /// </summary>
        public double[] sides;

        /// <summary>
        /// Initializes a new instance of the Triangle class
        /// </summary>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public Triangle(double a, double b, double c)
        {
            if(!IsExist(a, b, c))
            {
                throw new InvalidParametersException();
            }
            sides = new double[] { a, b, c };
        }

        /// <summary>
        /// Initializes a new instance of the Triangle class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
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

        /// <summary>
        /// Get the area of a triangle
        /// </summary>
        /// <returns></returns>
        public double GetSquare()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }

        /// <summary>
        /// Get the perimeter of a triangle
        /// </summary>
        /// <returns></returns>
        public double GetPerimeter()
        {
            double perimeter = 0;
            foreach(double side in sides)
            {
                perimeter += side;
            }
            return perimeter;
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
            Triangle triangle = obj as Triangle;
            if (triangle == null)
                return false;
            return sides[0] == triangle.sides[0] && sides[1] == triangle.sides[1] && sides[2] == triangle.sides[2];
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 2 * sides[0].GetHashCode() + 3 * sides[1].GetHashCode() + 4 * sides[2].GetHashCode();
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Triangle: sides: A = " + sides[0] + "; B = " + sides[1] + "; C = " + sides[3] + 
                   "; perimeter = " + GetPerimeter() + "; square = " + GetSquare();
        }
    }
}
