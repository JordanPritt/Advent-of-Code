module Part1

open System

type Counts = { Zeros : int; Ones: int }

let aggregate counts number =
    counts
    |> Seq.zip number
    |> Seq.map
        (fun (character, count) -> 
            if character = '0' then 
                { count with Zeros = count.Zeros + 1 } 
            else 
                { count with Ones = count.Ones + 1 })

let processList (binaryArray: string[]) =
    let countsList = 
        binaryArray
        |> Seq.fold aggregate (List.replicate binaryArray.Length { Zeros = 0; Ones = 0 })
        |> Seq.toArray

    let gamma = 
        countsList 
        |> Array.map(fun c -> if c.Ones > c.Zeros then 1 else 0 )
        |> Array.map string
        |> String.concat ""
        |> (fun i -> Convert.ToInt32(i, 2))

    let epsilon = 
        countsList 
        |> Array.map(fun c -> if c.Ones > c.Zeros then 0 else 1 )
        |> Array.map string
        |> String.concat ""
        |> (fun i -> Convert.ToInt32(i, 2))

    gamma * epsilon