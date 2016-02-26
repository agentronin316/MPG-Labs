using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MPGLabs
{
    static class LinearAcceleratedMotion
    {
        //Create a program that uses the Forward Euler method to model a ball being thrown upward from an
        //initial height of 2.00 meters at an initial upward velocity of 49.0 m/s for times between 0.00 s
        //and 10.00 s using a time-step of 0.10 s. Assume the acceleration to be due to gravity, -9.8 m/s2.
        //Have your code output the time, position, and velocity data for the ball to the screen and to a
        //comma-delimited ASCII file called “ex02_euler_0-10.csv”.
        //Repeat this for time-steps of 1.0 s, and 0.01 s, outputting the data to files called “ex02_euler_1-0.csv” and “ex02_euler_0-01.csv”.
        //Create a program that determines the position and velocity for the ball specified in Procedure 1 using Equations 5 and 7. Output the data to a file called “ex02_analytic.csv”.
        //Import the four data files into Excel or similar spreadsheet program and create a plot of position vs. time with all four datasets being plotted on the same graph.
        //Create a program that determines the position and velocity for the ball specified in Procedure 1 using the Forward Euler method, but instead of assuming the acceleration to be a constant -9.8 m/s2, use the relationship, a=−9.8−0.10v, where a is in units of m/s2 and v is in units of m/s. This relationship will model the affect of air resistance on the ball. Output the time and position to a file named “ex02_wind.csv” and plot the data using a spreadsheet.
        //Demonstrate the execution of your code and the graphical results to your instructor.

        static float initialHeight = 2f; //meters
        static float initialVelocity = 49f; //meters per second
        static float startTime = 0f; //seconds
        static float stopTime = 10f; //seconds
        static float timeStepOne = .1f; //seconds
        static float timeStepTwo = 1f; //seconds
        static float timeStepThree = .01f; //seconds

        static float gravity = 9.8f; //meters per second squared
        static string fileOne = "ex02_euler_0-10.csv";
        static string fileTwo = "ex02_euler_1-00.csv";
        static string fileThree = "ex02_euler_0-01.csv";
        static string fileFour = "ex02_analytic.csv";
        static string fileFive = "ex02_wind.csv";
        
        public static void RunLAM()
        {
            //Forward Euler with a time step of .1 seconds
            using (StreamWriter writer = new StreamWriter("..//..//" + fileOne))
            {
                float timeStep = timeStepOne;
                float pos = initialHeight;
                float time = startTime;
                float velocity = initialVelocity;
                writer.WriteLine("time,position,velocity");
                writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                while (time <= stopTime)
                {
                    time += timeStep;
                    pos += velocity * timeStep;
                    velocity -= gravity * timeStep;
                    writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                }
            }

            //Forward Euler with a timestep of 1 second
            using (StreamWriter writer = new StreamWriter("..//..//" + fileTwo))
            {
                float timeStep = timeStepTwo;
                float pos = initialHeight;
                float time = startTime;
                float velocity = initialVelocity;
                writer.WriteLine("time,position,velocity");
                writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                while (time <= stopTime)
                {
                    time += timeStep;
                    pos += velocity * timeStep;
                    velocity -= gravity * timeStep;
                    writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                }
            }

            //Forward Euler with a timestep of .01 seconds
            using (StreamWriter writer = new StreamWriter("..//..//" + fileThree))
            {
                float timeStep = timeStepThree;
                float pos = initialHeight;
                float time = startTime;
                float velocity = initialVelocity;
                writer.WriteLine("time,position,velocity");
                writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                while (time <= stopTime)
                {
                    time += timeStep;
                    pos += velocity * timeStep;
                    velocity -= gravity * timeStep;
                    writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                }
            }

            //Analytic values
            using (StreamWriter writer = new StreamWriter("..//..//" + fileFour))
            {
                float timeStep = timeStepOne;
                float pos = initialHeight;
                float time = startTime;
                float velocity = initialVelocity;
                writer.WriteLine("time,position,velocity");
                writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                while (time <= stopTime)
                {
                    time += timeStep;
                    pos = initialHeight + initialVelocity * time - .5f * gravity * time * time;
                    velocity = initialVelocity - gravity * time;
                    writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                }
            }

            //Forward Euler with a timestep of .1 seconds and inclusion of wind resistance
            using (StreamWriter writer = new StreamWriter("..//..//" + fileFive))
            {
                float timeStep = timeStepOne;
                float pos = initialHeight;
                float time = startTime;
                float velocity = initialVelocity;
                float acceleration = -gravity;
                writer.WriteLine("time,position,velocity");
                writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                while (time <= stopTime)
                {
                    time += timeStep;
                    pos += velocity * timeStep;
                    velocity += acceleration * timeStep;
                    acceleration = -gravity - .1f * velocity;
                    writer.WriteLine("{0},{1},{2}", time, pos, velocity);
                }
            }


        }
    }
}
