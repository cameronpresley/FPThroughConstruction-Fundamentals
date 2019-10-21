using NUnit.Framework;
using MarsRoverDotNet;

namespace MarsRoverDotNet.UnitTests.CommandTests
{
    public class WhenMovingForward
    {
        [Test]
        public void AndTheRoverIsFacingNorthThenTheYIncreasesByOne()
        {
            var rover = new Rover(0, 0, Direction.North);
            var newRover = RoverCommands.MoveForward(rover);
            Assert.AreEqual(newRover.X, rover.X);
            Assert.AreEqual(newRover.Y, rover.Y+1);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }

        [Test]
        public void AndTheRoverIsFacingSouthThenTheYDecreasesByOne()
        {
            var rover = new Rover(0, 0, Direction.South);
            var newRover = RoverCommands.MoveForward(rover);
            Assert.AreEqual(newRover.X, rover.X);
            Assert.AreEqual(newRover.Y, rover.Y-1);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }

        [Test]
        public void AndTheRoverIsFacingEastThenTheXIncreasesByOne()
        {
            var rover = new Rover(0, 0, Direction.East);
            var newRover = RoverCommands.MoveForward(rover);
            Assert.AreEqual(newRover.X, rover.X+1);
            Assert.AreEqual(newRover.Y, rover.Y);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }

        [Test]
        public void AndTheRoverIsFacingWestThenTheXDecreasesByOne()
        {
            var rover = new Rover(0, 0, Direction.West);
            var newRover = RoverCommands.MoveForward(rover);
            Assert.AreEqual(newRover.X, rover.X-1);
            Assert.AreEqual(newRover.Y, rover.Y);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }
    }
}