using System;

namespace MPGLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Vector3D Lab");
                Console.WriteLine("[2]: Projections Lab");
                Console.WriteLine("[3]: Generate Linear Accelerated Motion Files");
                Console.WriteLine("[4]: Force and Motion Lab");
                Console.WriteLine("[5]: Work and Energy Lab");
                Console.WriteLine("[6]: Closest Points Lab");
                Console.WriteLine("[7]: Scaling and Translations Lab");
                Console.WriteLine("[8]: Collisions and Momentum Lab");
                Console.WriteLine("[9]: Rotations Lab");
                Console.WriteLine("[10]: ...");
                Console.WriteLine("[11]: Quaternion Rotations Lab");
                Console.WriteLine("[12]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        VectorLab();
                        break;
                    case "2":
                        ProjectionLab();
                        break;
                    case "3":
                        LinearAcceleratedMotion.RunLAM();
                        break;
                    case "4":
                        ForceAndMotion();
                        break;
                    case "5":
                        WorkAndEnergy();
                        break;
                    case "6":
                        ClosestPoints();
                        break;
                    case "7":
                        ScalingAndTranslations();
                        break;
                    case "8":
                        CollisionsAndMomentum();
                        break;
                    case "9":
                        Rotations();
                        break;
                    case "10":
                        Console.WriteLine("Not yet implemented.");
                        break;
                    case "11":
                        QuaternionRotations();
                        break;
                    case "12":
                        Console.WriteLine("Goodbye.");
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "12");
        }

        #region Quaternion Rotations

        static void QuaternionRotations()
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Quaternion Math");
                Console.WriteLine("[2]: Rotating with Quaternions");
                Console.WriteLine("[3]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        QuaternionMath();
                        break;
                    case "2":
                        RotatingWithQuaternions();
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "3");
        }

        static void QuaternionMath()
        {
            //Collect user input, All units are arbitrary
            Console.Write("Enter a scalar value: ");
            float scalar = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the first quaternion:");
            Console.Write("Scalar component: ");
            float w = Convert.ToSingle(Console.ReadLine());
            Console.Write("Vector-x component: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Vector-y component: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Vector-z component: ");
            float z = Convert.ToSingle(Console.ReadLine());
            Quaternion first = new Quaternion(w, x, y, z);
            Console.WriteLine("Enter the second quaternion:");
            Console.Write("Scalar component: ");
            w = Convert.ToSingle(Console.ReadLine());
            Console.Write("Vector-x component: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Vector-y component: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Vector-z component: ");
            z = Convert.ToSingle(Console.ReadLine());
            Quaternion second = new Quaternion(w, x, y, z);

            //Display output
            Console.WriteLine("Sum: " + (first + second));
            Console.WriteLine("Difference: " + (first - second));
            Console.WriteLine("Scalar multiplication: " + (scalar * first) + " and " + (scalar * second));
            Console.WriteLine("Quaternion multipliation: " + (first * second));
            Console.WriteLine("Magnitudes: " + first.GetMagnitude() + " and " + second.GetMagnitude());
            Console.WriteLine("Conjugates: " + first.GetConjugate() + " and " + second.GetConjugate());
            Console.WriteLine("Inverses: " + first.GetInverse() + " and " + second.GetInverse());
        }

        static void RotatingWithQuaternions()
        {
            //Collect user input
            Console.WriteLine("Enter a point:");
            Console.Write("X-coordinate: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Y-coordinate: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Z-coordinate: ");
            float z = Convert.ToSingle(Console.ReadLine());
            Quaternion point = new Quaternion(0, x, y, z);
            Console.WriteLine("Enter a standard position vector to rotate around:");
            Console.Write("X component: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Y component: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Z component: ");
            z = Convert.ToSingle(Console.ReadLine());
            Quaternion axis = new Quaternion(0, x, y, z);
            Console.Write("Enter an angle in degrees to rotate the point by: ");
            float angle = Convert.ToSingle(Console.ReadLine()); //Degrees

            //Do the rotation
            Quaternion newPoint = point.Rotation(axis, angle);
            Vector3D output = new Vector3D(newPoint.X, newPoint.Y, newPoint.Z);
            Console.WriteLine("New point as a Quaternion: " + newPoint);
            Console.WriteLine("New point as a Vector: " + output);


        }

        #endregion

        #region Rotations

        static void Rotations()
        {
            //Get the initial object positions
            Console.Write("How many points are on the object? ");
            Vector3D[] points = new Vector3D[Convert.ToInt32(Console.ReadLine())];
            float x;
            float y;
            float z;
            for (int i = 0; i < points.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("1st point:");
                        break;
                    case 1:
                        Console.WriteLine("2nd point:");
                        break;
                    case 2:
                        Console.WriteLine("3rd point:");
                        break;
                    default:
                        Console.WriteLine((i + 1) + "th point:");
                        break;
                }
                Console.Write("Enter the x coordinate: ");
                x = Convert.ToSingle(Console.ReadLine());
                Console.Write("Enter the y coordinate: ");
                y = Convert.ToSingle(Console.ReadLine());
                Console.Write("Enter the z coordinate: ");
                z = Convert.ToSingle(Console.ReadLine());
                points[i] = new Vector3D(x, y, z);
            }

            //Do translations until terminated by user
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Rotation around the x-axis");
                Console.WriteLine("[2]: Rotation around the y-axis");
                Console.WriteLine("[3]: Rotation around the z-axis");
                Console.WriteLine("[4]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        RotationX(ref points);
                        break;
                    case "2":
                        RotationY(ref points);
                        break;
                    case "3":
                        RotationZ(ref points);
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "4");
        }

        static void RotationX(ref Vector3D[] points)
        {
            //Get the angle of rotation
            Console.Write("Enter the angle of rotation (in degrees): ");
            float angle = Convert.ToSingle(Console.ReadLine()); //degrees

            //Translate the vertices
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = points[i].RotationAroundX(angle);
                if (i != points.Length - 1)
                {
                    Console.WriteLine(points[i] + ", ");
                }
                else
                {
                    Console.WriteLine(points[i]);
                }
            }
        }

        static void RotationY(ref Vector3D[] points)
        {
            //Get the angle of rotation
            Console.Write("Enter the angle of rotation (in degrees): ");
            float angle = Convert.ToSingle(Console.ReadLine());

            //Translate the vertices
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = points[i].RotationAroundY(angle);
                if (i != points.Length - 1)
                {
                    Console.WriteLine(points[i] + ", ");
                }
                else
                {
                    Console.WriteLine(points[i]);
                }
            }
        }

        static void RotationZ(ref Vector3D[] points)
        {
            //Get the angle of rotation
            Console.Write("Enter the angle of rotation (in degrees): ");
            float angle = Convert.ToSingle(Console.ReadLine());

            //Translate the vertices
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = points[i].RotationAroundZ(angle);
                if (i != points.Length - 1)
                {
                    Console.WriteLine(points[i] + ", ");
                }
                else
                {
                    Console.WriteLine(points[i]);
                }
            }
        }

        #endregion

        #region Collisions and Momentum

        static void CollisionsAndMomentum()
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Reflection off of a plane");
                Console.WriteLine("[2]: Collision in 1D");
                Console.WriteLine("[3]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        PlaneReflection();
                        break;
                    case "2":
                        Collision1D();
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "3");
        }

        static void PlaneReflection()
        {
            //Collect User input
            Console.Write("Enter the coefficient of restitution: ");
            float coefficientOfRestitution = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the x-component of the initial velocity: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y-component of the initial velocity: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z-component of the initial velocity: ");
            float z = Convert.ToSingle(Console.ReadLine());
            Vector3D velocity = new Vector3D(x, y, z);
            Console.Write("Enter the x-component of the first planar vector: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y-component of the first planar vector: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z-component of the first planar vector: ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D plane1 = new Vector3D(x, y, z);
            Console.Write("Enter the x-component of the second planar vector: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y-component of the second planar vector: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z-component of the second planar vector: ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D plane2 = new Vector3D(x, y, z);

            //get the normalized planar normal
            Vector3D normal = !(plane1 % plane2);

            //Get the final velocity
            Vector3D finalVelocity = velocity - ((1 + coefficientOfRestitution) * (normal * velocity)) * normal;
            //Display the final velocity
            Console.WriteLine("New velocity is " + finalVelocity.ToString());
        }

        static void Collision1D()
        {
            //Collect user input
            Console.Write("Enter the coefficient of restitution: ");
            float coefficientOfRestitution = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the mass of the first object: ");
            float mass1 = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the velocity of the first object: ");
            float velocity1 = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the mass of the second object: ");
            float mass2 = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the velocity of the second object: ");
            float velocity2 = Convert.ToSingle(Console.ReadLine());

            //Calculate the final velocities
            float finalVelocity2 = (velocity1 * mass1 * (1 + coefficientOfRestitution) + velocity2 * (mass2 - mass1 * coefficientOfRestitution))
                                    / (mass1 + mass2);
            float finalVelocity1 = finalVelocity2 + coefficientOfRestitution * (velocity2 - velocity1);

            Console.WriteLine("The first object ends up with a velocity of " + finalVelocity1);
            Console.WriteLine("The second object ends up with a velocity of " + finalVelocity2);
        }

        #endregion

        #region Scaling and Translations

        static void ScalingAndTranslations()
        {
            //Get the initial object positions
            Console.Write("How many points are on the object? ");
            Vector3D[] points = new Vector3D[Convert.ToInt32(Console.ReadLine())];
            float x;
            float y;
            float z;
            for (int i = 0; i < points.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("1st point:");
                        break;
                    case 1:
                        Console.WriteLine("2nd point:");
                        break;
                    case 2:
                        Console.WriteLine("3rd point:");
                        break;
                    default:
                        Console.WriteLine((i + 1) + "th point:");
                        break;
                }
                Console.Write("Enter the x coordinate: ");
                x = Convert.ToSingle(Console.ReadLine());
                Console.Write("Enter the y coordinate: ");
                y = Convert.ToSingle(Console.ReadLine());
                Console.Write("Enter the z coordinate: ");
                z = Convert.ToSingle(Console.ReadLine());
                points[i] = new Vector3D(x, y, z);
            }

            //Do translations until terminated by user
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Matrix Translation");
                Console.WriteLine("[2]: Raw Scaling");
                Console.WriteLine("[3]: Center Scaling");
                Console.WriteLine("[4]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        TranslationMatrix(ref points);
                        break;
                    case "2":
                        RawScale(ref points);
                        break;
                    case "3":
                        CenterScale(ref points);
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "4");
        }

        static void TranslationMatrix(ref Vector3D[] points)
        {
            //Get the translation Vector
            Console.WriteLine("Translation Vector:");
            Console.Write("Enter the x coordinate: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate: ");
            float z = Convert.ToSingle(Console.ReadLine());
            Vector3D translation = new Vector3D(x, y, z);

            //Translate the vertices
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = points[i].TranslateWithMatrix(translation);
                if (i != points.Length - 1)
                {
                    Console.WriteLine(points[i] + ", ");
                }
                else
                {
                    Console.WriteLine(points[i]);
                }
            }
        }

        static void RawScale(ref Vector3D[] points)
        {
            //Get the scaling factors
            Console.WriteLine("Scaling Factors:");
            Console.Write("Enter the x direction factor: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y direction factor: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z direction factor: ");
            float z = Convert.ToSingle(Console.ReadLine());
            Vector3D scale = new Vector3D(x, y, z);

            //Scale the vertices
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = points[i].RawScaling(scale);
                if (i != points.Length - 1)
                {
                    Console.WriteLine(points[i] + ", ");
                }
                else
                {
                    Console.WriteLine(points[i]);
                }
            }
        }

        static void CenterScale(ref Vector3D[] points)
        {
            //Get the Center point for the scaling
            Console.WriteLine("Center Point to scale around:");
            Console.Write("Enter the x coordinate: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate: ");
            float z = Convert.ToSingle(Console.ReadLine());
            Vector3D center = new Vector3D(x, y, z);

            //Get the scaling factors
            Console.WriteLine("Scaling Factors:");
            Console.Write("Enter the x direction factor: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y direction factor: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z direction factor: ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D scale = new Vector3D(x, y, z);

            //Scale the vertices
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = points[i].CenterScaling(scale, center);
                if (i != points.Length - 1)
                {
                    Console.WriteLine(points[i] + ", ");
                }
                else
                {
                    Console.WriteLine(points[i]);
                }
            }
        }




        #endregion

        #region Closest Points

        static void ClosestPoints()
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Moving Object Closest Approach");
                Console.WriteLine("[2]: Closest Point on a Surface");
                Console.WriteLine("[3]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        ClosestLine();
                        break;
                    case "2":
                        ClosestPlane();
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "3");
        }

        static void ClosestLine()
        {
            //Collect data from user
            Console.Write("Enter the x coordinate of the ship (km): ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate of the ship (km): ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate of the ship (km): ");
            float z = Convert.ToSingle(Console.ReadLine());
            Vector3D ship = new Vector3D(x, y, z); //km
            Console.Write("Enter the x coordinate of the meteor (km): ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate of the meteor (km): ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate of the meteor (km): ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D meteor = new Vector3D(x, y, z); //km
            Console.Write("Enter the x coordinate of the meteor's trajectory (km/s): ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate of the meteor's trajectory (km/s): ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate of the meteor's trajectory (km/s): ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D trajectory = new Vector3D(x, y, z); //km/s

            //The mathening
            Vector3D closestPoint = ship.ClosestPointLine(meteor, trajectory); //km, the closest point on the line

            //Output
            Console.WriteLine("Closest Point is: " + closestPoint + " km");
            Console.WriteLine("Distance of closest approach is: {0:N2} km", (closestPoint - ship).GetMagnitude());
        }

        static void ClosestPlane()
        {
            //Collect data from user
            Console.Write("Enter the x coordinate of the ship (km): ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate of the ship (km): ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate of the ship (km): ");
            float z = Convert.ToSingle(Console.ReadLine());
            Vector3D ship = new Vector3D(x, y, z); //km
            Console.WriteLine("First planar point:");
            Console.Write("Enter the x coordinate (km): ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate (km): ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate (km): ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D point1 = new Vector3D(x, y, z); //km
            Console.WriteLine("Second planar point:");
            Console.Write("Enter the x coordinate (km): ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate (km): ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate (km): ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D point2 = new Vector3D(x, y, z); //km
            Console.WriteLine("Third planar point:");
            Console.Write("Enter the x coordinate (km): ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the y coordinate (km): ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Enter the z coordinate (km): ");
            z = Convert.ToSingle(Console.ReadLine());
            Vector3D point3 = new Vector3D(x, y, z); //km

            if (point1 == point2 || point2 == point3 || point3 == point1) //check if points are the same
            {
                Console.WriteLine("Error: Redundant points entered.");
            }
            else
            {
                //The mathening
                Vector3D point1To2 = point2 - point1; //km, one vector within the plane
                Vector3D point1To3 = point3 - point1; //km, another vector within the plane

                if ((!point1To2) == (!point1To3) || (!point1To2) == -1 * (!point1To3)) //check if points are on a single line
                {
                    Console.WriteLine("Error: Collinear points entered.");
                }
                else
                {
                    Vector3D normal = !(point1To2 % point1To3); //the planar normal, normalized to remove units
                    Vector3D closestPoint = ship.ClosestPointPlane(point1, normal); //km, the closest point on the plane

                    //Output
                    Console.WriteLine("Closest Point is: " + closestPoint + " km");
                    Console.WriteLine("Distance of closest approach is: {0:N2} km", (closestPoint - ship).GetMagnitude());
                }
            }
        }

        #endregion

        #region Work and Energy

        static void WorkAndEnergy()
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Box on Incline");
                Console.WriteLine("[2]: Orbit");
                Console.WriteLine("[3]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        BoxOnIncline();
                        break;
                    case "2":
                        Orbit();
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "3");
        }

        static void BoxOnIncline()
        {
            //giant block o' variables
            Console.Write("Please enter an initial velocity in m/s: ");
            float velocity = Convert.ToSingle(Console.ReadLine());
            Console.Write("Please enter a percentage of kinetic energy to remove each step: ");
            float percentKELossPerStep = Convert.ToSingle(Console.ReadLine());
            float mass = 100f; //kg
            float timeStep = .05f; //seconds
            float arbitrarySmallAmount = .001f; //m
            float velocityLossFactor = (float)Math.Sqrt(1f - percentKELossPerStep); //vNew = Sqrt(vOld^2 * (1 - loss) = vOld * Sqrt(1 - loss)
            float position = 0f; //m
            float acceleration = ((.3219f * (position + arbitrarySmallAmount) - (.3219f * (position - arbitrarySmallAmount))) * 9.8f / (2f * arbitrarySmallAmount)); //m/(s^2) //netForce / mass
            float potentialEnergy = (-.3219f * position + 10.0f) * mass * 9.8f; //N
            float kineticEnergy = mass * velocity * velocity / 2f; //N
            Console.WriteLine("Potential Energy: {0:N2}N, Kinetic Energy:  {1:N2}N, Total Energy:  {2:N2}N", potentialEnergy, kineticEnergy, potentialEnergy + kineticEnergy);

            //start simulation loop
            for (float time = 0; time < 360 && .3219f * position <= 10.0f; time += timeStep) //time is in seconds //run for 6 minutes, or until the box reaches the end of the ramp
            {
                position += velocity * timeStep; //update position
                velocity += acceleration * timeStep; //update velocity
                acceleration = ((.3219f * (position + arbitrarySmallAmount) - (.3219f * (position - arbitrarySmallAmount))) * 9.8f / (2f * arbitrarySmallAmount)); //update acceleration
                velocity = velocity * velocityLossFactor; //account for loss of kinetic energy
                potentialEnergy = (-.3219f * position + 10.0f) * mass * 9.8f; //calculate potential energy
                kineticEnergy = mass * velocity * velocity / 2f; //calculate kinetic energy
                Console.WriteLine("Potential Energy: {0:N2}N, Kinetic Energy:  {1:N2}N, Total Energy:  {2:N2}N", potentialEnergy, kineticEnergy, potentialEnergy + kineticEnergy);
            }
        }

        static void Orbit()
        {
            //giant block o' variables
            Console.Write("Input initial speed in km/s: ");
            Vector3D velocity = new Vector3D(Convert.ToSingle(Console.ReadLine()) * 1000f, 0); //m/s
            Vector3D position = new Vector3D(0, 6778000f); //m
            float massOfSpacecraft = 225f; //kg
            float inverseMassOfSpacecraft = 1 / massOfSpacecraft; //1/kg
            float massOfEarth = 5.98e24f; //kg
            float radiusOfEarth = 6378000f; //m
            float atmosphereRadius = 6478000f; //m
            int timeStep = 10; //s
            float arbitrarySmallAmount = 1f; //m
            float altitude = (position.Y - radiusOfEarth) / 1000f; //km
            float speed = velocity.X / 1000f; //km/s
            float totalEnergy = (massOfSpacecraft * speed * speed * 500000f) + GravityPE(position.GetMagnitude(), massOfSpacecraft, massOfEarth); //N
            Vector3D acceleration = inverseMassOfSpacecraft * GravityPEForce2D (position, massOfSpacecraft, massOfEarth, arbitrarySmallAmount); //m/(s^2)
            Console.WriteLine("Time: {0:N}s, Altitude: {1:N2}km,\nSpeed: {2:N2}km/s,\nTotal energy: {3:N2}N Acceleration: " + acceleration.PrintRect(), 0, altitude, speed, totalEnergy);

            //start simulation loop
            for (int time = 0; time < 36000 && position.GetMagnitude() > atmosphereRadius; time += timeStep) //time is in seconds
            {
                position += velocity * timeStep; //update position
                velocity += acceleration * timeStep; //update velocity
                acceleration = inverseMassOfSpacecraft * GravityPEForce2D(position, massOfSpacecraft, massOfEarth, arbitrarySmallAmount); //update acceleration

                //calculate and display output
                altitude = (position.GetMagnitude() - radiusOfEarth) / 1000f;
                speed = velocity.GetMagnitude() / 1000f;
                totalEnergy = (massOfSpacecraft * speed * speed * 500000f) + GravityPE(position.GetMagnitude(), massOfSpacecraft, massOfEarth);
                Console.WriteLine("Time: {0:N}s, Altitude: {1:N2}km,\nSpeed: {2:N2}km/s,\nTotal energy: {3:N2}N", time, altitude, speed, totalEnergy);

            }
            if (position.GetMagnitude() <= atmosphereRadius)
            {
                Console.WriteLine("Crashed into atmosphere! Go faster next time!");
            }
        }

        /// <summary>
        /// Get the potential energy as a float value
        /// </summary>
        /// <param name="position">the vector from the center of the object exerting the gravity to the object examined</param>
        /// <param name="mass1"></param>
        /// <param name="mass2"></param>
        /// <returns></returns>
        static float GravityPE(float radius, float mass1, float mass2)
        {
            float gravitationalConstant = 6.67e-11f; //N*(m/kg)^2
            return (-gravitationalConstant * mass1 * mass2 / radius);
        }

        
        /// <summary>
        /// Get the force vector for gravity in 2D space using potential energy
        /// </summary>
        /// <param name="position">the vector from the center of the object exerting the gravity to the object examined</param>
        /// <param name="mass1"></param>
        /// <param name="mass2"></param>
        /// <param name="arbitrarySmallAmount">can be anything, so long as it is less than the anticipated movement per timestep</param>
        /// <returns></returns>
        static Vector3D GravityPEForce2D(Vector3D position, float mass1, float mass2, float arbitrarySmallAmount)
        {
            float xDirForce = (GravityPE(new Vector3D((position.X - arbitrarySmallAmount), position.Y).GetMagnitude(), mass1, mass2) - GravityPE(new Vector3D((position.X + arbitrarySmallAmount), position.Y).GetMagnitude(), mass1, mass2)) / (2 * arbitrarySmallAmount); //N
            float yDirForce = (GravityPE(new Vector3D(position.X, (position.Y - arbitrarySmallAmount)).GetMagnitude(), mass1, mass2) - GravityPE(new Vector3D(position.X, (position.Y + arbitrarySmallAmount)).GetMagnitude(), mass1, mass2)) / (2 * arbitrarySmallAmount); //N
            return new Vector3D(xDirForce, yDirForce);
        }

        /// <summary>
        /// Get the force vector for gravity in 3D space using potential energy
        /// </summary>
        /// <param name="position">the vector from the center of the object exerting the gravity to the object examined</param>
        /// <param name="mass1"></param>
        /// <param name="mass2"></param>
        /// <param name="arbitrarySmallAmount">can be anything, so long as it is less than the anticipated movement per timestep</param>
        /// <returns></returns>
        static Vector3D GravityPEForce3D(Vector3D position, float mass1, float mass2, float arbitrarySmallAmount)
        {
            float xDirForce = (GravityPE((position.X - arbitrarySmallAmount), mass1, mass2) - GravityPE((position.X + arbitrarySmallAmount), mass1, mass2)) / (2 * arbitrarySmallAmount); //N
            float yDirForce = (GravityPE((position.Y - arbitrarySmallAmount), mass1, mass2) - GravityPE((position.Y + arbitrarySmallAmount), mass1, mass2)) / (2 * arbitrarySmallAmount); //N
            float zDirForce = (GravityPE((position.Z - arbitrarySmallAmount), mass1, mass2) - GravityPE((position.Z + arbitrarySmallAmount), mass1, mass2)) / (2 * arbitrarySmallAmount); //N
            return new Vector3D(xDirForce, yDirForce, zDirForce);
        }

        #endregion

        #region Force and Motion Lab

        static void ForceAndMotion()
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Sliding Box");
                Console.WriteLine("[2]: Model Rocket");
                Console.WriteLine("[3]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        SlidingBox();
                        break;
                    case "2":
                        ModelRocket();
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "3");
        }

        static void SlidingBox()
        {
            //Giant pile of variables, assuming mass == 1
            float timeStep = .1f; //seconds
            float time = 0; //seconds
            Vector3D normalForce = new Vector3D(0, 0, 9.8f); //newtons
            Console.Write("Input an initial speed (m/s): ");
            float speed = Convert.ToSingle(Console.ReadLine());
            Vector3D velocity = new Vector3D(speed, 0); //m/s

            Console.Write("Input the coefficient of kinetic friction: ");
            float coefficientOfKineticFriction = Convert.ToSingle(Console.ReadLine());
            Vector3D friction = MPGPhysics.KineticFriction(velocity, normalForce, coefficientOfKineticFriction); //newtons
            float position = 0f; //meters
            while (-friction.X * timeStep <= speed) //check if velocity will be zero at end of time step
            {
                position = position + (speed * timeStep);
                speed = speed + (friction.X * timeStep);
                time += timeStep;
            }
            Console.WriteLine("Box stops after {0:N2} seconds, {1:N2} meters away", time, position);
        }

        static void ModelRocket()
        {
            //Giant pile of Variables
            Vector3D position = new Vector3D(0, 0, .2f); //meters
            float inverseMass = 1 / .0742f; //kilograms
            float coefficientOfWindResistance = .02f;
            Vector3D thrustForce = Vector3D.zero;
            thrustForce.SetRectGivenMagHeadPitch(10f, 23f, 62f); //newtons
            Console.WriteLine(Vector3D.zero.PrintRect());
            Vector3D thrustAcc = inverseMass * thrustForce; //m/(s^2)
            Vector3D velocity = Vector3D.zero; 
            Vector3D gravityAcc = new Vector3D(0f, 0f, -9.8f); //m/(s^2)
            Vector3D acceleration = gravityAcc + thrustAcc; //m/(s^2)
            float timeStep = .1f; //seconds
            float time = 0f; //seconds
            while (time < 1f) //under thrust
            {
                position = position + timeStep * velocity;
                velocity = velocity + timeStep * acceleration;
                acceleration = gravityAcc + thrustAcc - (velocity * (coefficientOfWindResistance * inverseMass));
                time += timeStep;
                Console.WriteLine(position.PrintRect() + " " + velocity.PrintRect() + " " + time);
            }
            while (position.Z > 0) //post thrust
            {
                position = position + timeStep * velocity;
                velocity = velocity + timeStep * acceleration;
                acceleration = gravityAcc - (velocity * (coefficientOfWindResistance * inverseMass));
                time += timeStep;
            }
            Console.WriteLine("Rocket lands at ({0:N2}, {1:N2}) m after {2:N2} seconds of flight.", position.X, position.Y, time);
        }

        #endregion

        #region Projection Lab

        static void ProjectionLab()
        {
            //Declare vectors for tracking the end of the pole and the bee
            Vector3D pole = Vector3D.zero;
            Vector3D bee = Vector3D.zero;

            //Collect user input about the pole
            Console.Write("Input length of the utility pole in furlongs: ");
            float magnitude = Convert.ToSingle(Console.ReadLine()); //In furlongs, because I can
            Console.Write("Input heading of the utility pole in degrees: ");
            float heading = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input pitch of the utility pole in degrees: ");
            float pitch = Convert.ToSingle(Console.ReadLine());

            pole.SetRectGivenMagHeadPitch(magnitude, heading, pitch);
            for (int i = 0; i < 3; i++)
            {
                //Collect user data input about the movement
                Console.Write("Input distance the bee traveled in furlongs: ");
                magnitude = Convert.ToSingle(Console.ReadLine()); //In furlongs again, because consistency is nice
                Console.Write("Input the bee's heading in degrees: ");
                heading = Convert.ToSingle(Console.ReadLine());
                Console.Write("Input the bee's pitch in degrees: ");
                pitch = Convert.ToSingle(Console.ReadLine());
                Vector3D move = Vector3D.zero;
                move.SetRectGivenMagHeadPitch(magnitude, heading, pitch);
                bee += move; //update the bee's position
                Console.WriteLine("bee has moved " + bee.PrintMagHeadPitch("furlongs"));
                Console.WriteLine("closest point on the pole is " + (bee | pole).PrintRect());
            }
            Console.WriteLine("bee needs to move " + (pole - bee).PrintMagHeadPitch("furlongs") + " to reach the end of the pole");
        }

        #endregion

        #region Vector Lab
        static void VectorLab()
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("[1]: Rectangular 2D vector input");
                Console.WriteLine("[2]: Polar 2D vector input");
                Console.WriteLine("[3]: Rectangular 3D vector input");
                Console.WriteLine("[4]: Magnitude, Heading, Pitch 3D vector input");
                Console.WriteLine("[5]: Parallel Projection of a vector onto a second");
                Console.WriteLine("[6]: Cross product of two vectors");
                Console.WriteLine("[7]: Perpendicular projection");
                Console.WriteLine("[8]: Quit");
                Console.Write("Input your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Rect2D();
                        break;
                    case "2":
                        Polar();
                        break;
                    case "3":
                        Rect3D();
                        break;
                    case "4":
                        MagHeadPitch();
                        break;
                    case "5":
                        ParallelProjection();
                        break;
                    case "6":
                        CrossProduct();
                        break;
                    case "7":
                        PerpendicularProjection();
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "8");
        }

        private static void PerpendicularProjection()
        {
            Vector3D vectorOne = Vector3D.zero;
            Vector3D vectorTwo = Vector3D.zero;
            Console.Write("Input the x coordinate for the first vector: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y coordinate for the first vector: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the z coordinate for the first vector: ");
            float z = Convert.ToSingle(Console.ReadLine());
            vectorOne.SetRectGivenRect(x, y, z);
            Console.Write("Input the x coordinate for the second vector: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y coordinate for the second vector: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the z coordinate for the second vector: ");
            z = Convert.ToSingle(Console.ReadLine());
            vectorTwo.SetRectGivenRect(x, y, z);

            vectorOne = vectorOne ^ vectorTwo;

            Console.WriteLine(vectorOne.PrintRect());

        }

        private static void CrossProduct()
        {
            Vector3D vectorOne = Vector3D.zero;
            Vector3D vectorTwo = Vector3D.zero;
            Console.Write("Input the x coordinate for the first vector: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y coordinate for the first vector: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the z coordinate for the first vector: ");
            float z = Convert.ToSingle(Console.ReadLine());
            vectorOne.SetRectGivenRect(x, y, z);
            Console.Write("Input the x coordinate for the second vector: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y coordinate for the second vector: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the z coordinate for the second vector: ");
            z = Convert.ToSingle(Console.ReadLine());
            vectorTwo.SetRectGivenRect(x, y, z);

            vectorOne = vectorOne % vectorTwo;

            Console.WriteLine(vectorOne.PrintRect());

        }

        private static void ParallelProjection()
        {
            Vector3D vectorOne = Vector3D.zero;
            Vector3D vectorTwo = Vector3D.zero;
            Console.Write("Input the x coordinate for the first vector: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y coordinate for the first vector: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the z coordinate for the first vector: ");
            float z = Convert.ToSingle(Console.ReadLine());
            vectorOne.SetRectGivenRect(x, y, z);
            Console.Write("Input the x coordinate for the second vector: ");
            x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y coordinate for the second vector: ");
            y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the z coordinate for the second vector: ");
            z = Convert.ToSingle(Console.ReadLine());
            vectorTwo.SetRectGivenRect(x, y, z);

            vectorOne = vectorOne | vectorTwo;

            Console.WriteLine(vectorOne.PrintRect());

        }

        static void Rect2D()
        {
            Vector3D vector = Vector3D.zero;
            Console.Write("Input the x value for the vector: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y value for the vector: ");
            float y = Convert.ToSingle(Console.ReadLine());

            vector.SetRectGivenRect(x, y);

            Console.WriteLine(vector.PrintRect());
            Console.WriteLine(vector.PrintMagHeadPitch());
            Console.WriteLine(vector.PrintEulerAngles());
        }

        static void Rect3D()
        {
            Vector3D vector = Vector3D.zero;
            Console.Write("Input the x value for the vector: ");
            float x = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the y value for the vector: ");
            float y = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the z value for the vector: ");
            float z = Convert.ToSingle(Console.ReadLine());

            vector.SetRectGivenRect(x, y, z);

            Console.WriteLine(vector.PrintRect());
            Console.WriteLine(vector.PrintMagHeadPitch());
            Console.WriteLine(vector.PrintEulerAngles());
        }

        static void Polar()
        {
            Vector3D vector = Vector3D.zero;
            Console.Write("Input the magnitude of the vector: ");
            float mag = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the angle of the vector in degrees: ");
            float angle = Convert.ToSingle(Console.ReadLine());

            vector.SetRectGivenMagHeadPitch(mag, angle);

            Console.WriteLine(vector.PrintRect());
            Console.WriteLine(vector.PrintMagHeadPitch());
            Console.WriteLine(vector.PrintEulerAngles());
        }

        static void MagHeadPitch()
        {
            Vector3D vector = Vector3D.zero;
            Console.Write("Input the magnitude of the vector: ");
            float mag = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the heading of the vector in degrees: ");
            float head = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the pitch of the vector in degrees: ");
            float pitch = Convert.ToSingle(Console.ReadLine());

            vector.SetRectGivenMagHeadPitch(mag, head, pitch);

            Console.WriteLine(vector.PrintRect());
            Console.WriteLine(vector.PrintMagHeadPitch());
            Console.WriteLine(vector.PrintEulerAngles());
        }
        #endregion
    }
}
