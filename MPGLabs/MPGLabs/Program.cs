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
                Console.WriteLine("[4]: ...");
                Console.WriteLine("[5]: ...");
                Console.WriteLine("[6]: Quit");
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
                        Console.WriteLine("Not yet implemented.");
                        break;
                    case "5":
                        Console.WriteLine("Not yet implemented.");
                        break;
                    case "6":
                        Console.WriteLine("Goodbye.");
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "6");
        }

        static void ProjectionLab()
        {
            //Declare vectors for tracking the end of the pole and the bee
            Vector3D pole = new Vector3D();
            Vector3D bee = new Vector3D();

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
                Vector3D move = new Vector3D();
                move.SetRectGivenMagHeadPitch(magnitude, heading, pitch);
                bee += move; //update the bee's position
                Console.WriteLine("bee has moved " + bee.PrintMagHeadPitch("furlongs"));
                Console.WriteLine("closest point on the pole is " + (bee | pole).PrintRect());
            }
            Console.WriteLine("bee needs to move " + (pole - bee).PrintMagHeadPitch("furlongs") + " to reach the end of the pole");
        }

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
                Console.WriteLine("[6]: Quit");
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
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            } while (menuChoice != "6");
        }

        private static void ParallelProjection()
        {
            Vector3D vectorOne = new Vector3D();
            Vector3D vectorTwo = new Vector3D();
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
            Vector3D vector = new Vector3D();
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
            Vector3D vector = new Vector3D();
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
            Vector3D vector = new Vector3D();
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
            Vector3D vector = new Vector3D();
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
