using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NODLibrary
{
    /// <summary>
    /// Класс НОД
    /// </summary>
    public static class NOD
    {
        /// <summary>
        /// Метод нахождения НОД алгоритмом Евклида
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int findGcdEuclid(int a, int b)
        {
            while(a != 0 && b != 0)
            {
                if(a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return (a + b);
        }

        /// <summary>
        /// Перегрузка метода нахождения НОД алгоритмом Евклида для трёх чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int findGcdEuclid(int a, int b, int c)
        {
            return findGcdEuclid(findGcdEuclid(a, b), c);
        }

        /// <summary>
        /// Перегрузка метода нахождения НОД алгоритмом Евклида для четырёх чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int findGcdEuclid(int a, int b, int c, int d)
        {
            return findGcdEuclid(findGcdEuclid(a, b, c), d);
        }

        /// <summary>
        /// Перегрузка метода нахождения НОД алгоритмом Евклида для пяти чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static int findGcdEuclid(int a, int b, int c, int d, int e)
        {
            return findGcdEuclid(findGcdEuclid(a, b, c, d), e);
        }
    }
}
