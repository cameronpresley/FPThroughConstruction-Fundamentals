using System;
using System.Linq;

namespace MarsRoverDotNet
{
    class Program
    {
        static void Main(string[] args)
        {            
            var rover = new Rover{X=0,Y=0, Direction=Direction.North};
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

        private static void InteractiveMode(Rover r)
        {
            Rover rover = r;
            Command command = Command.Unknown;
            while (command != Command.Quit)
            {
                Console.WriteLine($"Rover's current location {Converters.ConvertRoverToString(rover)}");
                Console.WriteLine("What command to run?");
                Console.WriteLine("Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, (Q)uit");
                command = Converters.ConvertStringToCommand(Console.ReadLine());
                rover = Converters.ConvertCommandToAction(command).Invoke(rover);
            }
        }

        private static void StringOfCommands(Rover rover)
        {
            Console.WriteLine("What's the string of commands to process?");
            var input = Console.ReadLine();
            Console.WriteLine($"Rover's current location {Converters.ConvertRoverToString(rover)}");

            Rover finalRover;
            
            // Worst way to process (4 iterations)
            finalRover = input
                            .Select(x=>x.ToString())
                            .Select(Converters.ConvertStringToCommand)
                            .Select(Converters.ConvertCommandToAction)
                            .Aggregate(rover, (r, f) => f(r));

            // Better way to process (2 iterations!)
            Func<char, string> toString = c => c.ToString();
            Func<char, Func<Rover, Rover>> charToAction = toString
                                                            .Compose(Converters.ConvertStringToCommand)
                                                            .Compose(Converters.ConvertCommandToAction);
            finalRover = input.Select(charToAction).Aggregate(rover, (r, f) => f(r));

            // Best way (1 iteration)
            finalRover = input.Aggregate(rover, (r, c) => charToAction(c).Invoke(r));

            Console.WriteLine($"Rover's final location {Converters.ConvertRoverToString(finalRover)}");
        }
    }
}
