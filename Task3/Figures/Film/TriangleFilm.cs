using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    /// <summary>
    /// Class representing a film triangle
    /// </summary>
    public class TriangleFilm : Triangle, Film
    {
        /// <summary>
        /// Initializes a new instance of the TriangleFilm class
        /// </summary>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TriangleFilm(double a, double b, double c) : base(a, b, c)
        {
        }

        /// <summary>
        /// Initializes a new instance of the TriangleFilm class, cutting from another figure
        /// </summary>
        /// <param name="figure"> Figure for cutting</param>
        /// <param name="a"> First side of a triangle</param>
        /// <param name="b"> Second side of a triangle</param>
        /// <param name="c"> Third side of a triangle</param>
        public TriangleFilm(IFigure figure, double a, double b, double c) : base(figure, a, b, c)
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
            TriangleFilm triangleFilm = obj as TriangleFilm;
            if (triangleFilm == null)
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
