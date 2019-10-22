using NUnit.Framework;
using MarsRoverDotNet;

namespace MarsRoverDotNet.UnitTests.ConverterTests
{
  public class WhenConvertingToACommand
  {
    [Test]
    [TestCase((string)null, Command.Unknown, Description = "And the string is null then Unknown is returned")]
    [TestCase("f", Command.MoveForward, Description = "And the string is 'f' then MoveForward is returned")]
    [TestCase("F", Command.MoveForward, Description = "And the string is 'F' then MoveForard is returned")]
    [TestCase("b", Command.MoveBackward, Description = "And the string is 'b' then MoveBackward is returned")]
    [TestCase("B", Command.MoveBackward, Description = "And the string is 'B' then MoveBackward is returned")]
    [TestCase("l", Command.TurnLeft, Description = "And the string is 'l' then TurnLeft is returned")]
    [TestCase("L", Command.TurnLeft, Description = "And the string is 'L' then TurnLeft is returned")]
    [TestCase("r", Command.TurnRight, Description = "And the string is 'r' then TurnRight is returned")]
    [TestCase("R", Command.TurnRight, Description = "And the string is 'R' then TurnRight is returned")]
    [TestCase("q", Command.Quit, Description = "And the string is 'q' then Quit is returned")]
    [TestCase("Q", Command.Quit, Description = "And the string is 'Q' then Quit is returned")]
    [TestCase("kumquats", Command.Unknown, Description = "And the string is 'kumquats' then Unknown is returned")]
    public void ThenTheInputIsParsedCorrectly(string input, Command expected)
    {
      Assert.AreEqual(expected, Converters.ConvertStringToCommand(input));
    }
  }
}