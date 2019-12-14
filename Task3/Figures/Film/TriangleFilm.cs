using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class TriangleFilm : Triangle, Film
    {
        public TriangleFilm(double a, double b, double c) : base(a, b, c)
        {
        }
    }
}
