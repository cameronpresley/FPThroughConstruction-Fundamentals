namespace MarsRoverDotNet
{
    public static class RoverCommands
    {
        public static Rover MoveForward(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r.WithYOf(r.Y + 1);
                case Direction.South:
                    return r.WithYOf(r.Y - 1);
                case Direction.East:
                    return r.WithXOf(r.X + 1);
                case Direction.West:
                    return r.WithXOf(r.X - 1);
                default:
                    return r;
            }
        }
        
        public static Rover MoveBackward(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r.WithYOf(r.Y - 1);
                case Direction.South:
                    return r.WithYOf(r.Y + 1);
                case Direction.East:
                    return r.WithXOf(r.X - 1);
                case Direction.West:
                    return r.WithXOf(r.X + 1);
                default:
                    return r;
            }
        }
        public static Rover TurnLeft(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r.WithDirectionOf(Direction.West);
                case Direction.South:
                    return r.WithDirectionOf(Direction.East);
                case Direction.East:
                    return r.WithDirectionOf(Direction.North);
                case Direction.West:
                    return r.WithDirectionOf(Direction.South);
                default:
                    return r;
            }
        }
        public static Rover TurnRight(Rover r)
        {
            switch (r.Direction)
            {
                case Direction.North:
                    return r.WithDirectionOf(Direction.East);
                case Direction.South:
                    return r.WithDirectionOf(Direction.West);
                case Direction.East:
                    return r.WithDirectionOf(Direction.South);
                case Direction.West:
                    return r.WithDirectionOf(Direction.North);
                default:
                    return r;
            }
        }
        public static Rover DoNothing (Rover r) => r;
    }
}