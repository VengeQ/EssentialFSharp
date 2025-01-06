namespace Part2

module Functions = 

    type Customer = {
        Id : int
        Name : string
        Credit : decimal
    }

    // string -> true
    let CheckName (customer) = 
        if customer.Name.ToLower().StartsWith("vip") then (customer, true) else (customer, false)

    let AddCredit (customerInfo) = 
        let (customer, isVip) = customerInfo
        if isVip then { customer with Credit = customer.Credit + 10m} else customer

    let produceLog (value  : double) (logLevel : string) = 
        String.concat " " [logLevel; value.ToString()]
