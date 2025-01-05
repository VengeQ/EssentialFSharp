namespace Part1

module Persons =
    //type Person = { Id: int; Name: string; LastName : string; IsEmployee : bool}

    type Employee = { Id: int; Name: string; LastName : string }
    type Customer = { Id: int; Name: string; LastName : string }
    type Person = 
        | Employee of Employee 
        | Customer of Customer

    let Name person = 
        let name, lastName= 
            match person with
            | Employee e -> e.Name, e.LastName
            | Customer c -> c.Name, c.LastName
        name, lastName

    let CalculatePrice person spend = 
        let discountRatio =
            match person with
            | Employee _ ->
                if spend > 10000m then 0.2m
                else if spend > 1000m then 0.1m
                else 0.0m
            | Customer _ -> 0.0m
        spend * (1m - discountRatio)
            