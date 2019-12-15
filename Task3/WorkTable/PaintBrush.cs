using static ExceptionsLib.Exceptions;
using Figures;

namespace WorkTable
{
    /// <summary>
    /// Class for paint figures
    /// </summary>
    public static class PaintBrush
    {
        /// <summary>
        /// Method for paint figures
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="color"></param>
        public static void PaintFigure(IFigure figure, Paints color)
        {
            if(!(figure is Paper))
            {
                throw new ImpossibleToPaintException();
            }
            ((Paper)figure).Paint(color);
        }
    }
}
