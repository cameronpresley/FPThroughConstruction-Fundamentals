import {createInterface} from "readline";
const readline = createInterface({
    input: process.stdin,
    output: process.stdout,
  });

type Func<T, U> = (x: T) => U;

const compose = <T1, T2, T3>(a: Func<T1, T2>, b: Func<T2, T3>) => ((x: T1) => b(a(x))) as Func<T1, T3>;

type Direction = "North"
               | "South"
               | "East"
               | "West";

type Command = "MoveForward"
             | "MoveBackward"
             | "TurnLeft"
             | "TurnRight"
             | "Quit"
             | "Unknown";

interface Rover {
    x: number;
    y: number;
    direction: Direction;
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

const doNothing: Func<Rover, Rover> = (r) => r;

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

const commandToAction = (c: Command): Func<Rover, Rover> => {
    switch (c) {
      case "MoveBackward": return moveBackward;
      case "MoveForward": return moveForward;
      case "TurnLeft": return turnLeft;
      case "TurnRight": return turnRight;
      case "Quit": return doNothing;
      case "Unknown": return doNothing;
    }
};

let command: Command;

let rover: Rover = { x: 0, y: 0, direction: "North" };

const displayPrompt = (r: Rover) => {
    console.log(r);
    console.log("What command to run?");
    console.log("Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, (Q)uit");
};

console.log("How do you want to run the simulator?");
console.log("1). Interactive (default)");
console.log("2). String of Commands (no intermediate steps shown)");
readline.prompt();
readline.on("line", (line: string) => {
    if (!line || line === "1") {
        runInteractive(rover);
    } else {
        runStringOfCommands(rover);
    }
});

const runInteractive = (r: Rover) => {
    displayPrompt(rover);
    readline.prompt();
    readline.on("line", (line: string) => {
    command = stringToCommand(line);
    rover = commandToAction(command)(rover);
    if (command === "Quit") {
        readline.close();
    } else {
      displayPrompt(rover);
      readline.prompt();
    }
}).on("close", () => {
    process.exit(0);
});
};

const runStringOfCommands = (r: Rover) => {
    const stringToAction = compose(stringToCommand, commandToAction);
    console.log("What are the commands to process?");
    readline.prompt();
    readline.on("line", (line: string) => {
      const newR =
        [... line]
        .map(stringToAction)
        .reduce(compose, doNothing)
        (r);
      console.log(newR);
      readline.close();
    })
    .on("close", () => {
        process.exit(0);
    });
};
