namespace MarsRoverDotNet
{
    public static class RoverExtensions
    {
        public static Rover WithXOf(this Rover r, int x)
        {
            return new Rover(x, r.Y, r.Direction);
        }
        public static Rover WithYOf(this Rover r, int y)
        {
            return new Rover(r.X, y, r.Direction);
        }
        public static Rover WithDirectionOf(this Rover r, Direction direction)
        {
            return new Rover(r.X, r.Y, direction);
        }
    }
}