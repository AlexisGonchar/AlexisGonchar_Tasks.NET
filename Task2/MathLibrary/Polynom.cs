using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// Polynom class
    /// </summary>
    public class Polynom
    {
        /// <summary>
        /// Array of polynomial coefficients starting at x^0
        /// </summary>
        public float[] Coeff { get; protected set; }
        /// <summary>
        /// Polynomial degree
        /// </summary>
        public int Degree { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coeff"></param>
        public Polynom(params float[] coeff)
        {
            Degree = coeff.Length - 1;
            Coeff = new float[Degree + 1];
            Array.Copy(coeff, Coeff, Degree + 1);            
        }

        /// <summary>
        /// Polynomial addition
        /// </summary>
        /// <param name="poly1"></param>
        /// <param name="poly2"></param>
        /// <returns></returns>
        public static Polynom operator +(Polynom poly1, Polynom poly2)
        {
            float a, b;
            int length = Math.Max(poly1.Degree + 1, poly2.Degree + 1);
            float[] coff = new float[length];
            for(int i = 0; i < length; i++)
            {
                a = i < poly1.Coeff.Length ? poly1.Coeff[i] : 0;
                b = i < poly2.Coeff.Length ? poly2.Coeff[i] : 0;
                coff[i] = a + b;
            }

            return new Polynom(coff);
        }

        /// <summary>
        /// Polynomial subtraction
        /// </summary>
        /// <param name="poly1"></param>
        /// <param name="poly2"></param>
        /// <returns></returns>
        public static Polynom operator -(Polynom poly1, Polynom poly2)
        {
            float a, b;
            int length = Math.Max(poly1.Degree + 1, poly2.Degree + 1);
            float[] coff = new float[length];
            for (int i = 0; i < length; i++)
            {
                a = i < poly1.Coeff.Length ? poly1.Coeff[i] : 0;
                b = i < poly2.Coeff.Length ? poly2.Coeff[i] : 0;
                coff[i] = a - b;
            }

            return new Polynom(coff);
        }

        /// <summary>
        /// Polynomial multiplication
        /// </summary>
        /// <param name="poly1"></param>
        /// <param name="poly2"></param>
        /// <returns></returns>
        public static Polynom operator *(Polynom poly1, Polynom poly2)
        {
            int max = poly1.Degree + poly2.Degree;
            float[] coff = new float[max + 1];

            for (int i = poly1.Degree; i >= 0; i--)
                for (int j = poly2.Degree; j >= 0; j--)
                    coff[i + j] += poly1.Coeff[i] * poly2.Coeff[j];
            return new Polynom(coff);
        }
    }
}
