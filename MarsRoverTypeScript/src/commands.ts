import { Action, doNothing, moveBackward, moveForward, turnLeft, turnRight } from "./actions";

type Command = "MoveForward"
  | "MoveBackward"
  | "TurnLeft"
  | "TurnRight"
  | "Quit"
  | "Unknown";

const commandToAction = (c: Command): Action => {
  switch (c) {
    case "MoveBackward": return moveBackward;
    case "MoveForward": return moveForward;
    case "TurnLeft": return turnLeft;
    case "TurnRight": return turnRight;
    case "Quit": return doNothing;
    case "Unknown": return doNothing;
  }
};

export { Command, commandToAction };
