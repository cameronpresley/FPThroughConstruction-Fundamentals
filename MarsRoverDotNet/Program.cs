using System;

namespace MarsRoverDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How do you want to run the simulator?");
            System.Console.WriteLine("1). Interactive (default)");
            
            var rover = new Rover(0, 0, Direction.North);
            Command command = Command.Unknown;
            while (command != Command.Quit)
            {
                System.Console.WriteLine($"Rover's current location {Converters.ConvertRoverToString(rover)}");
                System.Console.WriteLine("What command to run?");
                System.Console.WriteLine("Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, (Q)uit");
                command = Converters.ConvertStringToCommand(Console.ReadLine());
                rover = Converters.ConvertCommandToAction(command).Invoke(rover);
            }
        }
    }
}
