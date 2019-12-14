﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExceptionsLib.Exceptions;
using WorkTable;

namespace Figures
{
    public class TrianglePaper : Triangle, Paper
    {
        private Paints color;
        public TrianglePaper(int a, int b, int c) : base(a, b, c)
        {
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
    }
}
