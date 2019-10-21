import {Func} from "./functional";
import { Rover } from "./models";

type Action = Func<Rover, Rover>;

const turnLeft: Action = (r) => {
  switch (r.direction) {
      case "North": return { ...r, direction: "West" };
      case "West": return { ...r, direction: "South" };
      case "South": return { ...r, direction: "East" };
      case "East": return { ...r, direction: "North" };
  }
};

const turnRight: Action = (r) => {
  switch (r.direction) {
      case "North": return { ...r, direction: "East" };
      case "East": return { ...r, direction: "South" };
      case "South": return { ...r, direction: "West" };
      case "West": return { ...r, direction: "North" };
  }
};

const moveForward: Action = (r) => {
  switch (r.direction) {
      case "North": return { ...r, y: r.y + 1 };
      case "South": return { ...r, y: r.y - 1 };
      case "East": return { ...r, x: r.x + 1 };
      case "West": return { ...r, x: r.x - 1 };
  }
};

const moveBackward: Action = (r) => {
  switch (r.direction) {
      case "North": return { ...r, y: r.y - 1 };
      case "South": return { ...r, y: r.y + 1 };
      case "East": return { ...r, x: r.x - 1 };
      case "West": return { ...r, x: r.x + 1 };
  }
};

const doNothing: Action = (r) => r;

export {moveForward, moveBackward, turnLeft, turnRight, doNothing, Action};
