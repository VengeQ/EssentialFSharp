module Part1Tests

open NUnit.Framework
open Part2.Functions

[<TestFixture>]
type FunctionsTests() = 
    [<Test>]
    member this.Compose () = 
        let customer =  { Id = 1 ; Name = "Vip_nm"; Credit = 100m }
        let addCredit = CheckName >> AddCredit
        let actual = addCredit customer
        Assert.That(actual.Credit, Is.EqualTo(110m))

    [<Test>]
    member this.Nested () = 
        let customer =  { Id = 1 ; Name = "Vip_nm"; Credit = 100m }
        let addCredit customer = AddCredit(CheckName(customer))
        let actual = addCredit customer
        Assert.That(actual.Credit, Is.EqualTo(110m))

    [<Test>]
    member this.Procedural () = 
        let customer =  { Id = 1 ; Name = "Vip_nm"; Credit = 100m }
        let checkedCustomer = CheckName customer
        let actual = AddCredit checkedCustomer
        Assert.That(actual.Credit, Is.EqualTo(110m))

    [<Test>]
    member this.Pipe () = 
        let customer = { Id = 1 ; Name = "Vip_nm"; Credit = 100m }
        let addCredit customer = 
            customer
            |> CheckName
            |> AddCredit
        let actual = addCredit customer
        Assert.That(actual.Credit, Is.EqualTo(110m))

    [<Test>]
    member this.Partial () =
        let produceLogfor10 = produceLog 10
        Assert.That(produceLogfor10 "info", Is.EqualTo("info 10"))
        Assert.That(produceLogfor10 "warn", Is.EqualTo("warn 10"))

    [<Test>]
    member this.PartialWithPipe () =
        let result = "error" |> produceLog 10
        Assert.That(result, Is.EqualTo("error 10"))

