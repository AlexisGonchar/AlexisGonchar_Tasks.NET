using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NODLibrary
{
    public static class NOD
    {
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
    }
}
