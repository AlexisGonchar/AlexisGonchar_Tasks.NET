﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTable;

namespace Figures
{
    public interface Paper
    {
        void Paint(Paints newColor);

        Paints GetColor();
    }
}
