using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("[5]: Quit");
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
                        Console.WriteLine("Goodbye.");
                        break;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            } while (menuChoice != "5");
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
            Console.Write("Input the magnitude of the vector in degrees");
            float mag = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the angle of the vector in degrees");
            float angle = Convert.ToSingle(Console.ReadLine());

            vector.SetRectGivenMagHeadPitch(mag, angle);

            Console.WriteLine(vector.PrintRect());
            Console.WriteLine(vector.PrintMagHeadPitch());
            Console.WriteLine(vector.PrintEulerAngles());
        }

        static void MagHeadPitch()
        {
            Vector3D vector = new Vector3D();
            Console.Write("Input the magnitude of the vector");
            float mag = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the heading of the vector in degrees");
            float head = Convert.ToSingle(Console.ReadLine());
            Console.Write("Input the pitch of the vector in degrees");
            float pitch = Convert.ToSingle(Console.ReadLine());

            vector.SetRectGivenMagHeadPitch(mag, head, pitch);

            Console.WriteLine(vector.PrintRect());
            Console.WriteLine(vector.PrintMagHeadPitch());
            Console.WriteLine(vector.PrintEulerAngles());
        }
    }
}
