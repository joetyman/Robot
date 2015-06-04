using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Robot Simulator!");
            Console.WriteLine("Please enter a series of commands or HELP for more information");
            parseInput();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        static void parseInput(){
            string input = Console.ReadLine();
            if (input == "HELP"){
                Console.WriteLine("Please enter a series of commands in a row, f for forward, r for right, l for left");
                parseInput();
            }else {
                Random random = new Random();
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                Map myMap = new Map(x, y);
                Robot myRobot = new Robot(input, myMap);
                myRobot.TransverseMap();
            }

        }
    }
}
