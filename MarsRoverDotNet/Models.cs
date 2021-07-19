namespace MarsRoverDotNet
{
    public enum Command
    {
        MoveForward, MoveBackward, TurnLeft,
        TurnRight, Quit,
        Unknown,
    }

    public enum Direction
    {
        North, South, East, West,
    }

    public record Rover
    {
        public int X {get;init;}
        public int Y {get; init;}
        public Direction Direction {get; init;}
    }
}