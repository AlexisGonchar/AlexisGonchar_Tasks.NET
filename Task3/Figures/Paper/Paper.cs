using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// Paper figures interface
    /// </summary>
    public interface Paper
    {
        /// <summary>
        /// Paint figure to concrect color
        /// </summary>
        /// <param name="newColor"></param>
        void Paint(Paints newColor);

        /// <summary>
        /// Returns figure color
        /// </summary>
        /// <returns></returns>
        Paints GetColor();
    }
}
