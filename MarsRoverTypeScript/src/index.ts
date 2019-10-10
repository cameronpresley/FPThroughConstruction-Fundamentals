import * as readline from "readline";
const kumquats = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
  });

type Func<T, U> = (x: T) => U;

const compose = <T1, T2, T3>(a: Func<T1, T2>, b: Func<T2, T3>) => ((x: T1) => b(a(x))) as Func<T1, T3>;

type Direction = "North" | "South" | "East" | "West";
interface Rover {
    readonly x: number;
    readonly y: number;
    readonly direction: Direction;
}

const turnLeft: Func<Rover, Rover> = (r) => {
    switch (r.direction) {
        case "North": return { ...r, direction: "West" };
        case "West": return { ...r, direction: "South" };
        case "South": return { ...r, direction: "East" };
        case "East": return { ...r, direction: "North" };
    }
};

const turnRight: Func<Rover, Rover> = (r) => {
    switch (r.direction) {
        case "North": return { ...r, direction: "East" };
        case "East": return { ...r, direction: "South" };
        case "South": return { ...r, direction: "West" };
        case "West": return { ...r, direction: "North" };
    }
};

const moveForward: Func<Rover, Rover> = (r) => {
    switch (r.direction) {
      case "North": return { ...r, y: r.y + 1 };
      case "South": return { ...r, y: r.y - 1 };
      case "East": return { ...r, x: r.x + 1 };
      case "West": return { ...r, x: r.x - 1 };
    }
};

const moveBackward: Func<Rover, Rover> = (r) => {
    switch (r.direction) {
      case "North": return { ...r, y: r.y - 1 };
      case "South": return { ...r, y: r.y + 1 };
      case "East": return { ...r, x: r.x - 1 };
      case "West": return { ...r, x: r.x + 1 };
    }
 };

type Command = "MoveForward" | "MoveBackward" | "TurnLeft" | "TurnRight" | "Quit" | "Unknown";

const stringToCommand = (s: string): Command => {
    switch (s.toLowerCase()) {
      case "f": return "MoveForward";
      case "b": return "MoveBackward";
      case "l": return "TurnLeft";
      case "r": return "TurnRight";
      case "q": return "Quit";
      default: return "Unknown";
    }
};

const commandToFunction = (c: Command): Func<Rover, Rover> => {
    switch (c) {
      case "MoveBackward": return moveBackward;
      case "MoveForward": return moveForward;
      case "TurnLeft": return turnLeft;
      case "TurnRight": return turnRight;
      case "Quit":
      case "Unknown":
        return (x: Rover) => x;
    }
};

let command: Command;

let newRover: Rover = { x: 0, y: 0, direction: "North" };

const displayPrompt = (r: Rover) => {
    console.log(r);
    console.log("What command to run?");
    console.log("Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, (Q)uit");
};

displayPrompt(newRover);
kumquats.prompt();
kumquats.on("line", (line: string) => {
    command = stringToCommand(line);
    newRover = commandToFunction(command)(newRover);
    if (command === "Quit") {
        kumquats.close();
    } else {
      displayPrompt(newRover);
      kumquats.prompt();
    }
}).on("close", () => {
    process.exit(0);
});
