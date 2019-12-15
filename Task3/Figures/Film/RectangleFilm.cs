using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Class  representing a film rectangle
    /// </summary>
    public class RectangleFilm : Rectangle, Film
    {
        /// <summary>
        /// Initializes a new instance of the RectangleFilm class
        /// </summary>
        /// <param name="a"> Width of a rectangle</param>
        /// <param name="b"> Height of a rectangle</param>
        public RectangleFilm(double a, double b) : base(a, b)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RectangleFilm class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="a"> Width of a rectangle</param>
        /// <param name="b"> Height of a rectangle</param>
        public RectangleFilm(IFigure figure, double a, double b) : base(figure, a, b)
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
            RectangleFilm rectangleFilm = obj as RectangleFilm;
            if (rectangleFilm == null)
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
