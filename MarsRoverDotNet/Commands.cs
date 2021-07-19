namespace MarsRoverDotNet
{
    public static class RoverCommands
    {
        public static Rover MoveForward(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r with { Y = r.Y + 1 };
                case Direction.South:
                    return r with { Y = r.Y - 1 };
                case Direction.East:
                    return r with { X = r.X + 1 };
                case Direction.West:
                    return r with { X = r.X - 1 };
                default:
                    return r;
            }
        }

        public static Rover MoveBackward(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r with { Y = r.Y - 1 };
                case Direction.South:
                    return r with { Y = r.Y + 1 };
                case Direction.East:
                    return r with { X = r.X - 1 };
                case Direction.West:
                    return r with { X = r.X + 1 };
                default:
                    return r;
            }
        }
        public static Rover TurnLeft(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r with { Direction = Direction.West };
                case Direction.South:
                    return r with { Direction = Direction.East };
                case Direction.East:
                    return r with { Direction = Direction.North };
                case Direction.West:
                    return r with { Direction = Direction.South };
                default:
                    return r;
            }
        }
        public static Rover TurnRight(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r with { Direction = Direction.East };
                case Direction.South:
                    return r with { Direction = Direction.West };
                case Direction.East:
                    return r with { Direction = Direction.South };
                case Direction.West:
                    return r with { Direction = Direction.North };
                default:
                    return r;
            }
        }
        public static Rover DoNothing(Rover r) => r;
    }
}