using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;
using Figures;

namespace WorkTable
{
    public static class PaintBrush
    {
        public static void PaintFigure(IFigure figure, Paints color)
        {
            if(!(figure is Paper))
            {
                throw new ImpossibleToPaintException();
            }
            ((Paper)figure).Paint(color);
        }
    }
}
