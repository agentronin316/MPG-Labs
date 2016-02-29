using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPGLabs
{
    static class MPGPhysics
    {
        /// <summary>
        /// Kinetic Friction
        /// </summary>
        /// <param name="velocity">velocity vector</param>
        /// <param name="normalForce">normal force vector</param>
        /// <param name="coefficientOfFriction">the coefficient of kinetic friction</param>
        /// <returns>kinetic friction force vector</returns>
        public static Vector3D KineticFriction(Vector3D velocity, Vector3D normalForce, float coefficientOfFriction)
        {
            return ((-coefficientOfFriction * normalForce.GetMagnitude()) * (!velocity));
        }

        /// <summary>
        /// Check Static Friction
        /// </summary>
        /// <param name="parallelNetForce">the net force vector projected parallel to the surface</param>
        /// <param name="normalForce">the normal force vector</param>
        /// <param name="coefficientOfFriction">the coefficient of static friction</param>
        /// <returns>if the force is sufficient to overcome static friction</returns>
        public static bool CheckStaticFriction(Vector3D parallelNetForce, Vector3D normalForce, float coefficientOfFriction)
        {
            return ((coefficientOfFriction * normalForce.GetMagnitude()) < parallelNetForce.GetMagnitude());
        }
    }
}
