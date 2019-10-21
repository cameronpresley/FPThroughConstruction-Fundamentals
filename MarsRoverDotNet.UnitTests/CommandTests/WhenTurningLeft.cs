using NUnit.Framework;
using MarsRoverDotNet;

namespace MarsRoverDotNet.UnitTests.CommandTests
{
  public class WhenTurningLeft
  {
    [Test]
    [TestCase(Direction.North, Direction.West, Description="AndFacingNorthThenRoverIsFacingWest")]
    [TestCase(Direction.West, Direction.South, Description="AndFacingWestThenRoverIsFacingSouth")]
    [TestCase(Direction.South, Direction.East, Description="AndFacingSouthThenRoverIsFacingEast")]
    [TestCase(Direction.East, Direction.North, Description="AndFacingEastThenRoverIsFacingNorth")]
    public void AndTheRoverIsFacingNorthThenTheYDecreasesByOne(Direction start, Direction end)
    {
      var rover = new Rover(0, 0, start);
      var newRover = RoverCommands.TurnLeft(rover);
      Assert.AreEqual(newRover.X, rover.X);
      Assert.AreEqual(newRover.Y, rover.Y);
      Assert.AreEqual(newRover.Direction, end);
    }
  }
}