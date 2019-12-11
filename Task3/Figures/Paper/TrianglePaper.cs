using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class TrianglePaper : Triangle, Paper
    {
        public TrianglePaper(int a, int b, int c) : base(a, b, c)
        {
        }

        public void Paint()
        {
        }
    }
}
