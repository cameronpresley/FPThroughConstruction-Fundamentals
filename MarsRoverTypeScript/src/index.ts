import { Command, commandToAction } from "./commands";
import { compose } from "./functional";
import { Rover } from "./models";

const prompt = require("prompt-sync")({sigint: true});

const stringToCommand = (s: string): Command => {
  switch (s.toLowerCase()) {
    case "f":
      return "MoveForward";
    case "b":
      return "MoveBackward";
    case "l":
      return "TurnLeft";
    case "r":
      return "TurnRight";
    case "q":
      return "Quit";
    default:
      return "Unknown";
  }
};

let command: Command;

const displayPrompt = (r: Rover) => {
  console.log(r);
  console.log("What command to run?");
  console.log(
    "Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, (Q)uit"
  );
};

const main = () => {
  console.log("How do you want to run the simulator?");
  console.log("1). Interactive (default)");
  console.log("2). String of Commands (no intermediate steps shown)");
  let line = prompt();
  const rover: Rover = { x: 0, y: 0, direction: "North" };
  if (!line || line === "1") {
    runInteractive(rover);
  } else {
    runStringOfCommands(rover);
  }
};

const runInteractive = (r: Rover) => {
  displayPrompt(r);
  const line = prompt();
  command = stringToCommand(line);
  r = commandToAction(command)(r);
  if (command === "Quit") {
    process.exit();
  } else {
    runInteractive(r);
  }
};

const runStringOfCommands = (rover: Rover) => {
  console.log("What are the commands to process?");
  const line = prompt();
  let newR: Rover;
  // worst way (3 iterations)
  newR = [...line]
    .map(stringToCommand)
    .map(commandToAction)
    .reduce((r, f) => f(r), rover);

  // Better way (2 iterations)
  const stringToAction = compose(stringToCommand, commandToAction);
  newR = [...line].map(stringToAction).reduce((r, f) => f(r), rover);

  // Best way (1 iteration)
  newR = [...line].reduce((r, c) => stringToAction(c)(r), rover);

  console.log(newR);
};

main();
