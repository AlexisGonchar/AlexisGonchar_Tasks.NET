using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public class RectanglePaper : Rectangle, Paper
    {
        private Paints color;
        public RectanglePaper(double a, double b) : base(a, b)
        {
        }

        public RectanglePaper(IFigure figure, double a, double b) : base(figure, a, b)
        {
            if (!(figure is Paper))
            {
                throw new CutException();
            }
            this.color = ((Paper)figure).GetColor();
        }

        public Paints GetColor()
        {
            return color;
        }

        public void Paint(Paints newColor)
        {
            if (color != null)
            {
                throw new ImpossibleToPaintException();
            }
            color = newColor;
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
            RectanglePaper rectanglePaper = obj as RectanglePaper;
            if (rectanglePaper == null)
                return false;
            return base.Equals(obj) && rectanglePaper.GetColor() == GetColor();
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + 2 + GetColor().GetHashCode();
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "; material = Paper; color = " + GetColor().ToString();
        }
    }
}
