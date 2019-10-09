using System;
using System.Linq;

namespace MarsRoverDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var rover = new Rover(0, 0, Direction.North);
            Console.WriteLine("How do you want to run the simulator?");
            System.Console.WriteLine("1). Interactive (default)");
            System.Console.WriteLine("2). String of Commands (no intermediate steps shown)");
            var result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    InteractiveMode(rover);
                    break;
                default:
                    StringOfCommands(rover);
                    break;
            }
        }

        private static void InteractiveMode(Rover rover)
        {
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

        private static void StringOfCommands(Rover rover)
        {
            Console.WriteLine("What's the string of commands to process?");
            var input = Console.ReadLine();
            System.Console.WriteLine($"Rover's current location {Converters.ConvertRoverToString(rover)}");

            Func<Rover, Rover> id = r => r;

            var finalRover =
                input
                .Select(x => x.ToString())
                .Select(Converters.ConvertStringToCommand)
                .Select(Converters.ConvertCommandToAction)
                .Aggregate(id, (a, b) => (r) => b(a(r)))
                .Invoke(rover);

            System.Console.WriteLine($"Rover's final location {Converters.ConvertRoverToString(finalRover)}");
        }
    }
}
