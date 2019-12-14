﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionsLib;
using static ExceptionsLib.Exceptions;

namespace Figures
{
    public class CirclePaper : Circle, Paper
    {
        private Paints color;
        public CirclePaper(double radius) : base(radius)
        {
        }

        public CirclePaper(IFigure figure, double radius) : base(figure, radius)
        {
            if(!(figure is Paper))
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
            if(color != null)
            {
                throw new ImpossibleToPaintException();
            }
            color = newColor;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            CirclePaper circlePaper = obj as CirclePaper;
            if (circlePaper == null)
                return false;
            return base.Equals(obj) && circlePaper.GetColor() == GetColor();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + 2 + GetColor().GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "; material = Paper; color = " + GetColor().ToString();
        }
    }
}
