// For more information see https://aka.ms/fsharp-console-apps

open System

// unit -> int
let rnd () =
    let rand = Random()
    rand.Next(100)

let x =List.init 50 (fun _ -> rnd())

Console.Write(x)