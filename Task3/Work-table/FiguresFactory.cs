using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;
using Figures;

namespace WorkTable
{
    public class FiguresFactory
    {
        /// <summary>
        /// Method for get circle
        /// </summary>
        /// <param name="Material"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public IFigure GetFigure(string material, float radius)
        {
            IFigure figure = CreateFigure(material, radius);
            return figure;
        }

        /// <summary>
        /// Method for get rectangle
        /// </summary>
        /// <param name="material"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public IFigure GetFigure(string material, float a, float b)
        {
            IFigure figure = CreateFigure(material, a, b);
            return figure;
        }

        /// <summary>
        /// Method for get triangle
        /// </summary>
        /// <param name="material"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public IFigure GetFigure(string material, float a, float b, float c)
        {
            IFigure figure = CreateFigure(material, a, b, c);
            return figure;
        }

        private IFigure CreateFigure(string material, params float[] values)
        {
            IFigure figure = null;
            switch (material)
            {
                case "Paper":
                    switch (values.Length)
                    {
                        case 1:
                            figure = new CirclePaper(values[0]);
                            break;
                        case 2:
                            figure = new RectanglePaper(values[0], values[1]);
                            break;
                        case 3:
                            figure = new TrianglePaper(values[0], values[1], values[2]);
                            break;
                        default:
                            throw new InvalidParametersException();
                    }
                    break;
                case "Film":
                    switch (values.Length)
                    {
                        case 1:
                            figure = new CircleFilm(values[0]);
                            break;
                        case 2:
                            figure = new RectangleFilm(values[0], values[1]);
                            break;
                        case 3:
                            figure = new TriangleFilm(values[0], values[1], values[2]);
                            break;
                        default:
                            throw new InvalidParametersException();
                    }
                    break;
                default:
                    throw new InvalidParametersException();
            }
        }
    }
}
