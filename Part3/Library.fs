namespace Part3

open System

module NullAndExceptions = 
    let getDayFromString (input : string) =
        let isSuccess, value = DateOnly.TryParse input
        if isSuccess then Some value.Day else None

    let getDayFromStringWithMatch (input : string) =
        match DateOnly.TryParse input with
        | true, result -> Some result.Day
        | _ -> None

    type Customer = {
        Id : int
        Name : string
        Discount : Option<decimal>
    }

    let getPrice customer price = 
        match customer.Discount with
        | Some discount -> price * (1m - discount)
        | _ -> price

    let okey value = Ok value

    let tryDivide (x : decimal) (y : decimal) = 
        try x/y |> okey
        with | :? DivideByZeroException as e -> Error (String.concat " "  ["zero divide:"; x.ToString () ; y.ToString ()])

    let tryRoot (x : decimal) = 
        let result = Math.Sqrt((float)x)
        if result = Math.Ceiling result then Ok result else Error ("Root error: " + x.ToString ())

    let resultToOption input =
        match input with
        | Ok x -> Some x
        | _ -> None

    let DivideThenRoot x y = 
        tryDivide x y 
        |> fun result ->
            match result with
            | Ok x -> tryRoot x
            | Error e -> Error e
        |> function // equal to previous fun result -> ...
            | Ok x -> x.ToString ()
            | Error e -> e
 
    let root (x : decimal) = Math.Sqrt((float)x)

    let DivideThenRootWithMap x y = 
        tryDivide x y 
        |> Result.map root
        |> function // equal to previous fun result -> ...
            | Ok x -> x.ToString ()
            | Error e -> e