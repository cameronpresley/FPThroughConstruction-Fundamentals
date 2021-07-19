using NUnit.Framework;
using MarsRoverDotNet;

namespace MarsRoverDotNet.UnitTests.CommandTests
{
    public class WhenMovingBackward
    {
        [Test]
        public void AndTheRoverIsFacingNorthThenTheYDecreasesByOne()
        {
            var rover = new Rover{X=0,Y=0, Direction=Direction.North};
            var newRover = RoverCommands.MoveBackward(rover);
            Assert.AreEqual(newRover.X, rover.X);
            Assert.AreEqual(newRover.Y, rover.Y-1);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }

        [Test]
        public void AndTheRoverIsFacingSouthThenTheYIncreasesByOne()
        {
            var rover = new Rover{X=0,Y=0, Direction=Direction.South};
            var newRover = RoverCommands.MoveBackward(rover);
            Assert.AreEqual(newRover.X, rover.X);
            Assert.AreEqual(newRover.Y, rover.Y+1);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }

        [Test]
        public void AndTheRoverIsFacingEastThenTheXDecreasesByOne()
        {
            var rover = new Rover{X=0,Y=0, Direction=Direction.East};
            var newRover = RoverCommands.MoveBackward(rover);
            Assert.AreEqual(newRover.X, rover.X-1);
            Assert.AreEqual(newRover.Y, rover.Y);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }

        [Test]
        public void AndTheRoverIsFacingWestThenTheXIncreasesByOne()
        {
            var rover = new Rover{X=0,Y=0, Direction=Direction.West};
            var newRover = RoverCommands.MoveBackward(rover);
            Assert.AreEqual(newRover.X, rover.X+1);
            Assert.AreEqual(newRover.Y, rover.Y);
            Assert.AreEqual(newRover.Direction, rover.Direction);
        }
    }
}