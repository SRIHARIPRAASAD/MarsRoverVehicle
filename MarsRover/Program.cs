using System;

namespace MarsRover
{
    class Program
    {    
                                                                                                                
        static void Main(string[] args)
        {
            Console.WriteLine("Test Input");
            Console.WriteLine("5 5");

            Console.WriteLine("1 2 N");
            RoverNavigation firstRover = new RoverNavigation(1, 2, RoverNavigation.Direction.N, new Plateau(5, 5));
            Console.WriteLine("LMLMLMLMM");
            firstRover.Command("LMLMLMLMM");

            Console.WriteLine("3 3 E");
            RoverNavigation secondRover = new RoverNavigation(3, 3, RoverNavigation.Direction.E, new Plateau(5, 5));
            Console.WriteLine("MMRMMRMRRM");
            secondRover.Command("MMRMMRMRRM");

            Console.WriteLine(Environment.NewLine);                                    
            Console.WriteLine("Output");

            firstRover.GetPosition();
            secondRover.GetPosition();

            Console.ReadLine();
        }
    }
}
