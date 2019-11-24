using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// Three-dimensional vector
    /// </summary>
    public class Vector3
    {
        /// <summary>
        /// Axle X
        /// </summary>
        public float X { get; protected set; }
        /// <summary>
        /// Axle Y
        /// </summary>
        public float Y { get; protected set; }
        /// <summary>
        /// Axle Z
        /// </summary>
        public float Z { get; protected set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Vector3(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        /// <summary>
        /// Sum of two three-dimensional vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        /// <summary>
        /// subtraction of two three-dimensional vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        /// <summary>
        /// Multiplication of a three-dimendional vector by a number
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 vec, float num)
        {
            return new Vector3(vec.X * num, vec.Y * num, vec.Z * num);
        }

        /// <summary>
        /// Scalar multiplication of two three-dimensional vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static float operator *(Vector3 vec1, Vector3 vec2)
        {
            return (vec1.X * vec2.X) + (vec1.Y * vec2.Y) + (vec1.Z * vec2.Z);
        }

        /// <summary>
        /// Vector multiplication of two three-dimensional vectors
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector3 operator ^(Vector3 vec1, Vector3 vec2)
        {
            float x, y, z;
            x = vec1.Y * vec2.Z - vec1.Z * vec2.Y;
            y = vec1.Z * vec2.X - vec1.X * vec2.Z;
            z = vec1.X * vec2.Y - vec1.Y * vec2.X;

            return new Vector3(x, y, z);
        }
    }
}
