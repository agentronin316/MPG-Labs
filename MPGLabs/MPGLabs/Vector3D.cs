using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGLabs
{
    /// <summary>
    /// @author Marshall R Mason
    /// </summary>
    class Vector3D
    {
        //x, y, z, and w components of the vector
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public float W { get; private set; }
        
        //Precalculated conversion values
        const float DEG_TO_RAD = (float)(180 / Math.PI);
        const float RAD_TO_DEG = (float)(Math.PI / 180);

        //public static methods
        public static float Deg2Rad(float degrees)
        {
            return degrees * DEG_TO_RAD;
        }

        public static float Rad2Deg(float radians)
        {
            return radians * RAD_TO_DEG;
        }

        
        public Vector3D()
        {
            //set x, y, z, w to 0, 0, 0, 1
            X = Y = Z = 0;
            W = 1;
        }

        /// <summary>
        /// Assigns the properties of the vector given rectangular coordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z">skip for 2D</param>
        void SetRectGivenRect(float x, float y, float z = 0)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1;
        }

        /// <summary>
        /// Assigns the properties of the vector given magnitude, heading, and pitch
        /// </summary>
        /// <param name="magnitude"></param>
        /// <param name="heading">in degrees, angle of vector in xy-plane</param>
        /// <param name="pitch">between -90 and 90, in degrees, angle of vector from xy-plane; skip for 2D</param>
        void SetRectGivenMagHeadPitch(float magnitude, float heading, float pitch = 0)
        { 
            if (magnitude == 0)
            {
                //set x, y, z to 0, 0, 0
                X = Y = Z = 0;
            }
            else if (pitch == 90 || pitch == -90)
            {
                X = 0;
                Y = 0;
                if (pitch > 0)
                    Z = magnitude;
                else
                    Z = -magnitude;
            }
            else
            {
                heading = Deg2Rad(heading);
                pitch = Deg2Rad(pitch);
                float sinH = (float)Math.Sin(heading);
                float cosH = (float)Math.Cos(heading);
                float sinP = (float)Math.Sin(pitch);
                float cosP = (float)Math.Cos(pitch);
                X = magnitude * cosP * cosH;
                Y = magnitude * cosP * sinH;
                Z = magnitude * sinP;
            }
            W = 1;

        }

        public string PrintRect()
        {
            return String.Format("<{0:N2}, {1:N2}, {2:N2}>", X, Y, Z);
        }

        public string PrintMagHeadPitch()
        {
            return String.Format("{0:N2} at heading {1:N2} and pitch {2:N2}", GetMagnitude(), GetHeading(), GetPitch());
        }

        public string PrintEulerAngles()
        {
            return String.Format("alpha = {0:N2}; beta = {1:N2}; gamma = {2:N2}", GetAlpha(), GetBeta(), GetGamma());
        }

        public float GetMagnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The heading of the vector in degrees</returns>
        public float GetHeading()
        {
            if (X == 0)
            {
                if (Y > 0)
                {
                    return 90f;
                }
                else if (Y < 0)
                {
                    return -90f;
                }
                else //Y == 0
                {
                    return 0;
                }
            }
            else if (X > 0)
            {
                if (Y == 0)
                {
                    return 0f;
                }
                else
                {
                    return Rad2Deg((float)Math.Atan(Y / X));
                }
            }
            else // x < 0
            {
                if (Y == 0)
                {
                    return 180f;
                }
                else
                {
                    return (Rad2Deg((float)Math.Atan(Y / X)) + 180f);
                }
            }
            
            
        }

        public float GetPitch()
        {
            return Rad2Deg((float)Math.Asin(Z));
        }

        public float GetAlpha() //Euler Angle to x-axis in degrees
        {
            return Rad2Deg((float)(Math.Acos(X / GetMagnitude())));
        }

        public float GetBeta() //Euler Angle to y-axis in degrees
        {
            return Rad2Deg((float)(Math.Acos(Y / GetMagnitude())));
        }

        public float GetGamma() //Euler Angle to z-axis in degrees
        {
            return Rad2Deg((float)(Math.Acos(Z / GetMagnitude())));
        }


    }
}
