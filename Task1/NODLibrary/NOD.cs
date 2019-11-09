using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace NODLibrary
{
    /// <summary>
    /// Класс НОД
    /// </summary>
    public static class NOD
    {
        static Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// Метод нахождения НОД алгоритмом Евклида
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int findGcdEuclid(int a, int b, ref double time)
        {
            stopWatch.Start();
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
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
            stopWatch.Stop();
            time += stopWatch.Elapsed.TotalMilliseconds;
            return (a + b);
        }

        /// <summary>
        /// Перегрузка метода нахождения НОД алгоритмом Евклида для трёх чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int findGcdEuclid(int a, int b, int c, ref double time)
        {
            int gcd;
            stopWatch.Start();
            gcd = findGcdEuclid(findGcdEuclid(a, b, ref time), c, ref time);
            stopWatch.Stop();
            time += stopWatch.Elapsed.TotalMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Перегрузка метода нахождения НОД алгоритмом Евклида для четырёх чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int findGcdEuclid(int a, int b, int c, int d, ref double time)
        {
            int gcd;
            stopWatch.Start();
            gcd = findGcdEuclid(findGcdEuclid(a, b, c, ref time), d, ref time);
            stopWatch.Stop();
            time += stopWatch.Elapsed.TotalMilliseconds;
            return gcd;
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
        public static int findGcdEuclid(int a, int b, int c, int d, int e, ref double time)
        {
            int gcd;
            stopWatch.Start();
            gcd = findGcdEuclid(findGcdEuclid(a, b, c, d, ref time), e, ref time);
            stopWatch.Stop();
            time += stopWatch.Elapsed.TotalMilliseconds;
            return gcd;
        }

        /// <summary>
        /// Метод нахождения НОД алгоритмом Стейна
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="time">Время выполнения метода</param>
        /// <returns></returns>
        public static int findGcdStein(int a, int b, ref double time)
        {
            stopWatch.Start();
            if (a == 0)
            {
                stopWatch.Stop();
                time += stopWatch.Elapsed.TotalMilliseconds;
                return b;
            }                            
            if (b == 0)
            {
                stopWatch.Stop();
                time += stopWatch.Elapsed.TotalMilliseconds;
                return a;
            }                         
            if (a == b)
            {
                stopWatch.Stop();
                time += stopWatch.Elapsed.TotalMilliseconds;
                return a;
            }                      
            if (a == 1 || b == 1)
            {
                stopWatch.Stop();
                time += stopWatch.Elapsed.TotalMilliseconds;
                return 1;
            }                  
            if ((a & 1) == 0)
            {
                stopWatch.Stop();
                time += stopWatch.Elapsed.TotalMilliseconds;
                return ((b & 1) == 0)
                    ? findGcdStein(a >> 1, b >> 1, ref time) << 1
                    : findGcdStein(a >> 1, b, ref time);
            }                     
                              
            else
            {
                stopWatch.Stop();
                time += stopWatch.Elapsed.TotalMilliseconds;
                return ((b & 1) == 0)
                    ? findGcdStein(a, b >> 1, ref time)
                    : findGcdStein(b, a > b ? a - b : b - a, ref time);
            }     
        }
    }
}
