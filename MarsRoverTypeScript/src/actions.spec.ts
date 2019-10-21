import { moveForward } from "./actions";
import { Rover } from "./models";

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
