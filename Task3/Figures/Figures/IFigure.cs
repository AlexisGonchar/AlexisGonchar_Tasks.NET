using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    /// <summary>
    /// Class representing a common figure
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Get perimeter of the figure
        /// </summary>
        /// <returns></returns>
        double GetPerimeter();

        /// <summary>
        /// Get area of the figure
        /// </summary>
        /// <returns></returns>
        double GetSquare();
    }
}
