using System;

namespace MarsRoverDotNet
{
    public static class RoverCommands
    {
        public static Rover MoveForward(Rover r)
        {
            switch(r.Direction)
            {
                case Direction.North:
                case Direction.South:
                case Direction.East:
                case Direction.West:
                default:
                return r;
            }
        }
        public static Rover MoveBackward(Rover r)
        {
switch(r.Direction)
            {
                case Direction.North:
                case Direction.South:
                case Direction.East:
                case Direction.West:
                default:
                return r;
            }
        }
        public static Rover TurnLeft(Rover r)
        {
switch(r.Direction)
            {
                case Direction.North:
                case Direction.South:
                case Direction.East:
                case Direction.West:
                default:
                return r;
            }
        }
        public static Rover TurnRight(Rover r)
        {
switch(r.Direction)
            {
                case Direction.North:
                case Direction.South:
                case Direction.East:
                case Direction.West:
                default:
                return r;
            }
        }

        public static Rover Quit (Rover r) => r;
        public static Rover Unknown (Rover r) => r;

    }
}