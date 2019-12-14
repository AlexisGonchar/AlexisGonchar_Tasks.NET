using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class CircleFilm : Circle, Film
    {
        public CircleFilm(double radius) : base(radius)
        {
        }
    }
}
