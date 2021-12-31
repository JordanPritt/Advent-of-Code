open System
open System.IO
open Part1
open Part2

let loadInput (fileName: string) =
    let lines = File.ReadAllLines($"{__SOURCE_DIRECTORY__}/{fileName}")
    lines

let printPart number =
    Console.ForegroundColor <- ConsoleColor.DarkGreen
    printfn "================="
    printfn " Solution Part%i" number
    printfn "=================\n"
    Console.ForegroundColor <- ConsoleColor.White

let printSolution solution =
    printf "Solution: "
    Console.ForegroundColor <- ConsoleColor.DarkRed
    printf "%i\n\n" solution
    Console.ForegroundColor <- ConsoleColor.White    

[<EntryPointAttribute>]
let main args =
   
    printPart 1
    let input = loadInput "TestInput.txt"
    let partOneSolution = processList input
    printSolution partOneSolution

    printPart 2
    let partTwoSolution = getLifeSupportRating input
    printSolution partTwoSolution

    0