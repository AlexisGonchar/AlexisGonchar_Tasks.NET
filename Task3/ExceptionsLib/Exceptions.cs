﻿using System;
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
                    return "This figure cannot be painted.";
                }
            }
        }

        /// <summary>
        /// Cannot to cutting the figure
        /// </summary>
        public class CutException : Exception
        {
            public override string Message
            {
                get
                {
                    return "This figure cannot be cutting.";
                }
            }
        }

        /// <summary>
        /// Cannot put figure in the box
        /// </summary>
        public class NoPlaceException : Exception
        {
            public override string Message
            {
                get
                {
                    return "There is no more space in the box.";
                }
            }
        }

        /// <summary>
        /// This figure is already in the box
        /// </summary>
        public class SameFigureException : Exception
        {
            public override string Message
            {
                get
                {
                    return "This figure is already in the box.";
                }
            }
        }

        /// <summary>
        /// Box is empty
        /// </summary>
        public class EmptyBoxException : Exception
        {
            public override string Message
            {
                get
                {
                    return "Box is empty.";
                }
            }
        }
    }
}
