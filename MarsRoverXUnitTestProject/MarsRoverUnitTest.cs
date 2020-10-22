using System;
using Xunit;
using MarsRover;

namespace MarsRoverXUnitTestProject
{
    public class MarsRoverUnitTest
    {
        private RoverNavigation firstRover = null;
        private RoverNavigation secondRover = null;

        /// <summary>
        /// Set the first Rover initial position and the plateau upper right corner.
        /// </summary>
        private void SetupFirstRover()
        {
           firstRover = new RoverNavigation(1, 2, RoverNavigation.Direction.N, new Plateau(5, 5));
        }

        /// <summary>
        /// Set the second Rover initial position and the plateau upper right corner.
        /// </summary>
        private void SetupSecondRover()
        {
            secondRover = new RoverNavigation(3, 3, RoverNavigation.Direction.E, new Plateau(5, 5));
        }

        /// <summary>
        /// Correct assertion 
        /// </summary>
        [Fact]
        public void MoveFirstRover()
        {
            SetupFirstRover();
            firstRover.Command("LMLMLMLMM");
            Assert.Equal("1 3 N",firstRover.GetPosition());
        }

        /// <summary>
        /// Wrong assertion. The value is not equal to the expected result.
        /// </summary>
        [Fact]
        public void MoveSecondRover()
        {
            SetupSecondRover();
            secondRover.Command("MMRMMRMRRM"); 
            Assert.Equal("1 3 N",secondRover.GetPosition());
            //Assert.Equal("5 1 E",secondRover.GetPosition());
        }

        /// <summary>
        /// Can't go out as the moves exceeds the plateau range of (5,5). Moves does not have any effect after
        /// it reached the boundary.
        /// </summary>
        [Fact]
        public void BlurringTheBoundaries()
        {
            SetupSecondRover();
            secondRover.Command("MMMMMMMMMM");
            Assert.Equal("5 3 E",secondRover.GetPosition());
        }

        /// <summary>
        /// SecondRover will move UpperRightCorner pointing North
        /// </summary>
        [Fact]
        public void SecondRoverUpperRightCornerPointingNorth()
        {
            SetupSecondRover();
            secondRover.Command("MMLMM");
            Assert.Equal("5 5 N",secondRover.GetPosition());
        }

        /// <summary>
        /// FirstRover will move at the BottonRightCorner pointing East
        /// </summary>
        [Fact]
        public void FirstRoverBottonRightCornerPointingEast()
        {
            SetupFirstRover();
            firstRover.Command("RMMMMRMML");
            Assert.Equal("5 0 E",firstRover.GetPosition());
        }

        /// <summary>
        ///Set FirstRover coordinates out of range (Position of Rover) as per Plateau boundaries.
        /// Y coordinate is 7 and Plateau.Y= 5
        /// </summary>
        [Fact]
        public void FirstRoverCoordinatesOutofRange()
        {
            firstRover = new RoverNavigation(1, 7, RoverNavigation.Direction.N, new Plateau(5, 5));
            Assert.True(firstRover.PositionX <= firstRover.Plateau.X && firstRover.PositionY <= firstRover.Plateau.Y, "The coordinates position is out of plateau range");
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    