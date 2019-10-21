import {Rover, Direction} from "./models";
import {moveForward} from "./actions";

describe("When moving forward", () => {
  it("and facing north, then y increases by one", () => {
    const r :Rover = {x:0, y:0, direction:"North"}
    const newR = moveForward(r);
    expect(newR.x).toBe(r.x);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y+1);
  });
  it("and facing south, then y decreases by one", () => {
    const r :Rover = {x:0, y:0, direction:"South"}
    const newR = moveForward(r);
    expect(newR.x).toBe(r.x);
    expect(newR.direction).toBe(r.direction);
    expect(newR.y).toBe(r.y-1);
  });

})
