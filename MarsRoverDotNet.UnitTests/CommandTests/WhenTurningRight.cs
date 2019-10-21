using NUnit.Framework;
using MarsRoverDotNet;

namespace MarsRoverDotNet.UnitTests.CommandTests
{
  public class WhenTurningRight
  {
    [Test]
    [TestCase(Direction.North, Direction.East, Description="AndFacingNorthThenRoverIsFacingEast")]
    [TestCase(Direction.East, Direction.South, Description="AndFacingEastThenRoverIsFacingSouth")]
    [TestCase(Direction.South, Direction.West, Description="AndFacingSouthThenRoverIsFacingWest")]
    [TestCase(Direction.West, Direction.North, Description="AndFacingWestThenRoverIsFacingNorth")]
    public void ThenTheRoverIsFacingTheCorrectDirection(Direction start, Direction end)
    {
      var rover = new Rover(0, 0, start);
      var newRover = RoverCommands.TurnRight(rover);
      Assert.AreEqual(newRover.X, rover.X);
      Assert.AreEqual(newRover.Y, rover.Y);
      Assert.AreEqual(newRover.Direction, end);
    }
  }
}