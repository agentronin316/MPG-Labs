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
                    case "6":
                        Console.WriteLine("Goodbye.");
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
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
    }
}
