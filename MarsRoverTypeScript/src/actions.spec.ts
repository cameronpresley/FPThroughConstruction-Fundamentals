import { moveBackward, moveForward, turnLeft, turnRight } from "./actions";
import { Direction, Rover } from "./models";

describe("When moving forward", () => {
  it("and facing north, then y increases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "North" };
    const newR = moveForward(r);
    expect(newR.x).toBe(r.x);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y + 1);
  });
  it("and facing south, then y decreases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "South" };
    const newR = moveForward(r);
    expect(newR.x).toBe(r.x);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y - 1);
  });
  it("and facing east, then x increases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "East" };
    const newR = moveForward(r);
    expect(newR.x).toBe(r.x + 1);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y);
  });
  it("and facing west, then x decreases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "West" };
    const newR = moveForward(r);
    expect(newR.x).toBe(r.x - 1);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y);
  });
});

describe("When moving backward", () => {
  it("and facing north, then y decreases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "North" };
    const newR = moveBackward(r);
    expect(newR.x).toBe(r.x);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y - 1);
  });
  it("and facing south, then y increases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "South" };
    const newR = moveBackward(r);
    expect(newR.x).toBe(r.x);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y + 1);
  });
  it("and facing east, then x decreases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "East" };
    const newR = moveBackward(r);
    expect(newR.x).toBe(r.x - 1);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y);
  });
  it("and facing west, then x increases by one", () => {
    const r: Rover = { x: 0, y: 0, direction: "West" };
    const newR = moveBackward(r);
    expect(newR.x).toBe(r.x + 1);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y);
  });
});

describe("When turning left", () => {
  it.each([["North", "West"], ["West", "South"], ["South", "East"], ["East", "North"]])(
    `and facing %s then the rover is facing %s`, (start: Direction, end: Direction) => {
      const r: Rover = { x: 0, y: 0, direction: start };
      const newR = turnLeft(r);
      expect(newR.x).toBe(r.x);
      expect(newR.y).toBe(r.y);
      expect(newR.direction).toBe(end);
    });
});

describe("When turning right", () => {
  it.each([["North", "East"], ["East", "South"], ["South", "West"], ["West", "North"]])(
    `and facing %s then the rover is facing %s`, (start: Direction, end: Direction) => {
      const r: Rover = { x: 0, y: 0, direction: start };
      const newR = turnRight(r);
      expect(newR.x).toBe(r.x);
      expect(newR.y).toBe(r.y);
      expect(newR.direction).toBe(end);
    });
});
