type Direction = "North"
    | "South"
    | "East"
    | "West";

interface Rover {
    readonly x: number;
    readonly y: number;
    readonly direction: Direction;
}

export {Direction, Rover};
