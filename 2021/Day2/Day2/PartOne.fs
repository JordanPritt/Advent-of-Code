module PartOne

type Directions =
    | Forward of int
    | Down of int
    | Up of int
    | Invalid of int

type MoveState =
    {
        horizontal: int
        depth: int
    }

let loadInput =
    System.IO.File.ReadAllLines $"{__SOURCE_DIRECTORY__}\Input.txt"

let loadTestInput =
    System.IO.File.ReadAllLines $"{__SOURCE_DIRECTORY__}\TestInput.txt"

let parseInput (input: string) =
    let inputStringArray = input.Split(" ")
    let direction = inputStringArray[0]
    let units = inputStringArray[1] |> int
    let directionToMove =
        match direction with
        | "forward" -> Forward
        | "down" -> Down
        | "up" -> Up
        | _ -> Invalid

    directionToMove units

let updateState (state: MoveState) (direction: Directions) : MoveState =
    match direction with
    | Forward units -> { state with horizontal = state.horizontal + units }
    | Down units -> { state with depth = state.depth + units }
    | Up units -> { state with depth = state.depth - units }
    | Invalid units -> state

let runPartOne =
    let state = { horizontal = 0; depth = 0; }
    let directions = loadInput

    let processDayOne =
        directions
        |> Seq.map parseInput
        |> Seq.fold updateState state

    printfn "===== Part One ====="
    printfn "Submarine position:\n\nposition: %i depth: %i" processDayOne.horizontal processDayOne.depth
    printfn "Total: %i\n\n" (processDayOne.horizontal * processDayOne.depth)