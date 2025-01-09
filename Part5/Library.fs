namespace Part5

module Collections =

    let head elements =
        match elements with
        | [] -> None
        | head :: _ -> Some head