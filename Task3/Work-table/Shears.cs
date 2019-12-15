using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;
using Figures;

namespace WorkTable
{
    public class Shears
    {
        /// <summary>
        /// Method for cut circle
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public IFigure CutFigure(IFigure figure, double radius)
        {
            IFigure newFigure = CreateFigure(figure, radius);
            return newFigure;
        }

        /// <summary>
        /// ethod for cut rectangle
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public IFigure CutFigure(IFigure figure, double a, double b)
        {
            IFigure newFigure = CreateFigure(figure, a, b);
            return newFigure;
        }

        /// <summary>
        /// Method for cut triangle
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public IFigure GetFigure(IFigure figure, double a, double b, double c)
        {
            IFigure newFigure = CreateFigure(figure, a, b, c);
            return newFigure;
        }

        public IFigure CreateFigure(IFigure figure, params double[] values)
        {
            IFigure newFigure = null;
            if(figure is Paper)
                    switch (values.Length)
                    {
                        case 1:
                            figure = new CirclePaper(figure, values[0]);
                            break;
                        case 2:
                            figure = new RectanglePaper(figure, values[0], values[1]);
                            break;
                        case 3:
                            figure = new TrianglePaper(figure, values[0], values[1], values[2]);
                            break;
                        default:
                            throw new InvalidParametersException();
                    }
            else if(figure is Film)
                    switch (values.Length)
                    {
                        case 1:
                            figure = new CircleFilm(figure, values[0]);
                            break;
                        case 2:
                            figure = new RectangleFilm(figure, values[0], values[1]);
                            break;
                        case 3:
                            figure = new TriangleFilm(figure, values[0], values[1], values[2]);
                            break;
                        default:
                            throw new InvalidParametersException();
                    }
            return newFigure;
        }
    }
}
