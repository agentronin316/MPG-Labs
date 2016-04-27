using System;

namespace MPGLabs
{
    struct Quaternion
    {

        public static Quaternion identity = new Quaternion(0, 0, 0, 0);
        public float W { get; private set; }
        Vector3D v;

        #region Interface Properties for Vector
        public float X
        {
            get
            {
                return v.X;
            }
            private set
            {
                v = new Vector3D(value, v.Y, v.Z);
            }
        }
        public float Y
        {
            get
            {
                return v.Y;
            }
            private set
            {
                v = new Vector3D(v.X, value, v.Z);
            }
        }
        public float Z
        {
            get
            {
                return v.Z;
            }
            private set
            {
                v = new Vector3D(v.X, v.Y, value);
            }
        }
        #endregion

        #region Constructors
        public Quaternion(float w, Vector3D vector) : this()
        {
            W = w;
            v = vector;
        }

        public Quaternion(float w, float x, float y, float z) : this()
        {
            W = w;
            v = new Vector3D(x, y, z);
        }

        public Quaternion(Vector3D vector) : this()
        {
            W = 0;
            v = vector;
        }
        #endregion

        #region Operations
        /// <summary>
        /// Quaternion Addition
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            Quaternion toReturn = new Quaternion(left.W + right.W, left.v + right.v);
            return toReturn;
        }

        /// <summary>
        /// Quaternion Subtraction
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            Quaternion toReturn = new Quaternion(left.W - right.W, left.v - right.v);
            return toReturn;
        }

        /// <summary>
        /// Scalar Multiplication of a Quaternion
        /// </summary>
        /// <param name="a"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quaternion operator *(float a, Quaternion q)
        {
            Quaternion toReturn = new Quaternion(q.W * a, q.v * a);
            return toReturn;
        }

        /// <summary>
        /// Scalar Multiplication of a Quaternion
        /// </summary>
        /// <param name="a"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quaternion operator *(Quaternion q, float a)
        {
            Quaternion toReturn = new Quaternion(q.W * a, q.v * a);
            return toReturn;
        }

        /// <summary>
        /// Quaternion Multiplication
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            Quaternion toReturn = new Quaternion(left.W * right.W - (left.v * right.v), (left.W * right.v) + (right.W * left.v) + (left.v % right.v));
            return toReturn;
        }

        public float GetMagnitude()
        {
            return (float)Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
        }

        public Quaternion GetConjugate()
        {
            return new Quaternion(W, -1 * v);
        }

        public Quaternion GetInverse()
        {
            return GetConjugate() * (1 / (GetMagnitude() * GetMagnitude()));
        }
        #endregion

        public Quaternion Rotation(Quaternion axis, float angle)
        {
            axis = axis * (1f / axis.GetMagnitude()); // normalize the axis of rotation
            angle = Vector3D.Deg2Rad(angle); // convert the angle from degrees to radians
            Quaternion rotator = new Quaternion((float)Math.Cos(angle * .5), new Vector3D(axis.X, axis.Y, axis.Z) * (float)Math.Sin(angle * .5));
            return (rotator * this * rotator.GetConjugate());
        }

        public override string ToString()
        {
            return String.Format("[{0:N2}, <{1:N2}, {2:N2}, {3:N2}>]", W, X, Y, Z);
        }
    }
}
