module Sonar

open System.IO

let loadInput =
    let path = "./DayOne/input.txt"
    let input = 
        File.ReadAllLines(path)
        |> Array.map int
    input

let getDepthChangeCount (changes:int[]) : int =
    changes
    |> Seq.pairwise
    |> Seq.filter((fun (val1, val2) -> val1 < val2))
    |> Seq.length

let getWindowedDepthCount (changes: int[]) : int =
    changes
    |> Seq.windowed 3
    |> Seq.map Seq.sum
    |> Seq.pairwise
    |> Seq.filter((fun (val1, val2) -> val1 < val2))
    |> Seq.length

let runDayOne = 

    printfn "Getting input..."
    let input = loadInput
    let depthChanges = getDepthChangeCount input
    let windowedDepthCount = getWindowedDepthCount input

    printfn "Depth Changes: %i" depthChanges
    printfn "Windowed Depth Changes: %i" windowedDepthCount
    true