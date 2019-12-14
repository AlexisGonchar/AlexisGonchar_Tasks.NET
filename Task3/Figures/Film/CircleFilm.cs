using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public class CircleFilm : Circle, Film
    {
        public CircleFilm(double radius) : base(radius)
        {
        }

        public CircleFilm(IFigure figure, double radius) : base(figure, radius)
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
            CircleFilm circleFilm = obj as CircleFilm;
            if (circleFilm == null)
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
