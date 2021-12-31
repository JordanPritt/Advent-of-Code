module PartTwo

type Directions =
    | Forward of int
    | Down of int
    | Up of int
    | Invalid of int

type MoveState =
    {
        horizontal: int
        depth: int
        aim: int
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
        | _ -> failwith "Invalid input data."

    directionToMove units

let updateState (state: MoveState) (direction: Directions) : MoveState =
    match direction with
    | Forward units -> { state with horizontal = state.horizontal + units; depth = state.depth + state.aim * units }
    | Down units -> { state with aim = state.aim + units }
    | Up units -> { state with aim = state.aim - units }
    | Invalid units -> failwith "Invalid state from bad input."

let runPartTwo =
    let state = { horizontal = 0; depth = 0; aim = 0; }
    let directions = loadInput

    let processDayTwo =
        directions
        |> Seq.map parseInput
        |> Seq.fold updateState state

    printfn "===== Part Two ====="
    printfn "Submarine position:\n\nposition: %i depth: %i" processDayTwo.horizontal processDayTwo.depth
    printfn "Total: %i" (processDayTwo.horizontal * processDayTwo.depth)