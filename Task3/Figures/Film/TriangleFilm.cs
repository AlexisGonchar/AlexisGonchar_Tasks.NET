using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public class TriangleFilm : Triangle, Film
    {
        public TriangleFilm(double a, double b, double c) : base(a, b, c)
        {
        }

        public TriangleFilm(IFigure figure, double a, double b, double c) : base(figure, a, b, c)
        {
            if (!(figure is Paper))
            {
                throw new CutException();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            TriangleFilm triangleFilm = obj as TriangleFilm;
            if (triangleFilm == null)
                return false;
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + 1;
        }

        public override string ToString()
        {
            return base.ToString() + "; material = Film";
        }
    }
}
