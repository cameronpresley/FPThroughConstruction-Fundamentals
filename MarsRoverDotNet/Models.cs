namespace MarsRoverDotNet
{
    public enum Direction 
    {
        North,
        South,
        East,
        West,
    }

    public class Rover
    {
        public int X {get;}
        public int Y {get;}
        public Direction Direction {get;}

        public Rover(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }

    public enum Command
    {
        MoveForward,
        MoveBackward,
        TurnLeft,
        TurnRight,
        Quit,
        Unknown
    }
}