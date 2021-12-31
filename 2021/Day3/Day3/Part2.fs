module Part2

open System

let rec filterList index bit (numList: string seq) =
    if numList |> Seq.length = 1 then
        numList |> Seq.head
    else
        let mostCommonBit =
            numList
            |> Seq.map (Seq.item index)
            |> Seq.countBy id
            |> bit

        let filtered =
            numList
            |> Seq.filter (fun digit -> digit.[index] = mostCommonBit)
            |> Seq.toList

        filterList (index + 1) bit filtered

let oxygenFilter = filterList 0 (Seq.sortDescending >> Seq.maxBy snd >> fst)
let co2Filter = filterList 0 (Seq.sort >> Seq.minBy snd >> fst)

let getLifeSupportRating (numList: string[]) =
    let oxygenRating = 
        numList
        |> Array.toSeq
        |> oxygenFilter
        |> (fun i -> Convert.ToInt32(i, 2))
    let co2Rating =
        numList
        |> Array.toSeq
        |> co2Filter
        |> (fun i -> Convert.ToInt32(i, 2))

    oxygenRating * co2Rating