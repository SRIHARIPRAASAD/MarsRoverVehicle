using System;
using System.Collections.Generic;
using System.Text;


namespace MarsRover
{
    public class RoverNavigation
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        Direction RoboticRoverDirection { get; set; }
        public Plateau Plateau { get; set; }

        /// <summary>
        /// Shows the direction of the rover 
        /// </summary>
        public enum Direction
        {
            N = 90,
            E = 180,
            S = 270,
            W = 360
        }

        /// <summary>
        /// Constructor of the class 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <param name="plateau"></param>
        public RoverNavigation(Int32 x, Int32 y, Direction direction, Plateau plateau)
        {
            PositionX = x;
            PositionY = y;
            RoboticRoverDirection = direction;
            Plateau = plateau;
        }

        /// <summary>
        /// Movements of rover based on direction
        /// </summary>
        private void Go()
        {
            if (RoboticRoverDirection == Direction.N && Plateau.Y > PositionY)
            {
                PositionY++;
            }
            else if (RoboticRoverDirection == Direction.E && Plateau.X > PositionX)
            {
                PositionX++;
            }
            else if (RoboticRoverDirection == Direction.S && PositionY > 0)
            {
                PositionY--;
            }
            else if (RoboticRoverDirection == Direction.W && PositionX > 0)
            {
                PositionX--;
            }
        }

        /// <summary>
        /// Change the direction of the rover
        /// </summary>
        /// <param name="directionCode"></param>
        private void ChangeDirection(Char directionCode)
        {
            if (directionCode == 'L')
                RoboticRoverDirection = (RoboticRoverDirection - 90) < Direction.N ? Direction.W : RoboticRoverDirection - 90;
            else if (directionCode == 'R')
                RoboticRoverDirection = (RoboticRoverDirection + 90) > Direction.W ? Direction.N : RoboticRoverDirection + 90;
        }

        /// <summary>
        /// Process the command string
        /// </summary>
        /// <param name="commandStr"></param>
        public void Command(string commandStr)
        {
            foreach (var command in commandStr)
            {
                if (command == 'L' || command == 'R')
                    ChangeDirection(command);
                else if (command == 'M')
                    Go();
            }
        }

        /// <summary>
        /// Get position and direction of the cover at the end of the command
        /// </summary>
        public string GetPosition()
        {
            string printedRoverPosition = string.Format("{0} {1} {2}", PositionX, PositionY, RoboticRoverDirection);
            Console.WriteLine(printedRoverPosition);
            return printedRoverPosition;
        }
    }
}
