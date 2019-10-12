using System;

namespace MarsRoverDotNet
{
    public static class Converters
    {
        public static Command ConvertStringToCommand(string s)
        {
            switch(s?.ToLower())
            {
                case "f": return Command.MoveForward;
                case "b": return Command.MoveBackward;
                case "l": return Command.TurnLeft;
                case "r": return Command.TurnRight;
                case "q": return Command.Quit;
                default: return Command.Unknown;
            }
        }

        public static Func<Rover, Rover> ConvertCommandToAction(Command c)
        {
            switch(c)
            {
                case Command.MoveForward: return RoverCommands.MoveForward;
                case Command.MoveBackward: return RoverCommands.MoveBackward;
                case Command.TurnLeft: return RoverCommands.TurnLeft;
                case Command.TurnRight: return RoverCommands.TurnRight;
                case Command.Quit: return RoverCommands.DoNothing;
                default: return RoverCommands.DoNothing;
            }
        }

        public static string ConvertRoverToString(Rover r) => $"(X:{r.X}, Y:{r.Y}) facing {r.Direction}";
    }
}