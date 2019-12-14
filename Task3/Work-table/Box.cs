using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;
using Figures;

namespace WorkTable
{
    public class Box
    {
        List<IFigure> figures;

        public Box()
        {
            figures = new List<IFigure>();
        }

        public void Add(IFigure figure)
        {
            if(figures.Count == 20)
                throw new NoPlaceException();

            if (figures.Count == 0)
                figures.Add(figure);
            else
                foreach(IFigure fig in figures)
                    if(fig.Equals(figure))
                        throw new 
        }
    }
}
