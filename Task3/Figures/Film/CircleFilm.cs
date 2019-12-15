using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Class representing a film circle
    /// </summary>
    public class CircleFilm : Circle, Film
    {
        /// <summary>
        /// Initializes a new instance of the CircleFilm class
        /// </summary>
        /// <param name="radius"> Circle radius</param>
        public CircleFilm(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CircleFilm class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="radius"> Circle radius</param>
        public CircleFilm(IFigure figure, double radius) : base(figure, radius)
        {
            if (!(figure is Paper))
            {
                throw new CutException();
            }
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
            CircleFilm circleFilm = obj as CircleFilm;
            if (circleFilm == null)
                return false;
            return base.Equals(obj);
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + 1;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "; material = Film";
        }
    }
}
