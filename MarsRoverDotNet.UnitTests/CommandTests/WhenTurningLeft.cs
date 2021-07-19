using NUnit.Framework;
using MarsRoverDotNet;

namespace MarsRoverDotNet.UnitTests.CommandTests
{
    public class WhenTurningLeft
    {
        [Test]
        [TestCase(Direction.North, Direction.West, Description = "AndFacingNorthThenRoverIsFacingWest")]
        [TestCase(Direction.West, Direction.South, Description = "AndFacingWestThenRoverIsFacingSouth")]
        [TestCase(Direction.South, Direction.East, Description = "AndFacingSouthThenRoverIsFacingEast")]
        [TestCase(Direction.East, Direction.North, Description = "AndFacingEastThenRoverIsFacingNorth")]
        public void ThenTheRoverIsFacingTheCorrectDirection(Direction start, Direction end)
        {
            var rover = new Rover { X = 0, Y = 0, Direction = start };
            var newRover = RoverCommands.TurnLeft(rover);
            Assert.AreEqual(newRover.X, rover.X);
            Assert.AreEqual(newRover.Y, rover.Y);
            Assert.AreEqual(newRover.Direction, end);
        }
    }
}