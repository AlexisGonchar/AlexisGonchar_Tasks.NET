﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public class RectangleFilm : Rectangle, Film
    {
        public RectangleFilm(double a, double b) : base(a, b)
        {
        }

        public RectangleFilm(IFigure figure, double a, double b) : base(figure, a, b)
        {
            if (!(figure is Paper))
            {
                throw new CutException();
            }
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
            RectangleFilm rectangleFilm = obj as RectangleFilm;
            if (rectangleFilm == null)
                return false;
            return base.Equals(obj);
        }

        /// <summary>
        /// GetHashCode method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + 1;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "; material = Film";
        }
    }
}
