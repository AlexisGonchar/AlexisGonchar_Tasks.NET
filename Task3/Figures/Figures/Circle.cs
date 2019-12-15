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
        public double radius;

        public Circle(double radius)
        {
            if(radius <= 0)
            {
                throw new InvalidParametersException();
            }
            this.radius = radius;
        }

        public Circle(IFigure figure, double radius)
        {
            if (radius <= 0)
            {
                throw new InvalidParametersException();
            }
            this.radius = radius;
            if (figure.GetSquare() < GetSquare())
            {
                throw new CutException();
            }            
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double GetSquare()
        {
            return Math.PI * radius * radius;
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
            Circle circle = obj as Circle;
            if (circle == null)
                return false;
            return radius.Equals(circle.radius);
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (3 * radius.GetHashCode());
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Circle: radius = " + radius + "; perimeter = " + GetPerimeter() + "; square = " + GetSquare();
        }
    }
}
