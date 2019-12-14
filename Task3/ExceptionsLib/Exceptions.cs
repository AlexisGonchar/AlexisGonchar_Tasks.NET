using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    /// <summary>
    /// Class of exceptions
    /// </summary>
    public class Exceptions
    {
        /// <summary>
        /// Wrong parameters exception
        /// </summary>
        public class InvalidParametersException : Exception
        {
            public override string Message
            {
                get
                {
                    return "Incorrect parameters are given.";
                }
            }
        }


        /// <summary>
        /// Cannot to paint the figure
        /// </summary>
        public class ImpossibleToPaintException : Exception
        {
            public override string Message
            {
                get
                {
                    return "The figure is already painted over.";
                }
            }
        }

    }
}
