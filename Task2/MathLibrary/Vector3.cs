using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class Vector3
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public float Z { get; protected set; }

        public Vector3(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
}
