module Part3Tests

open NUnit.Framework
open System
open Part3.NullAndExceptions

[<TestFixture>]
type NullAndExceptionsTests() = 

    [<TestCase("2024-01-01", 1)>]
    [<TestCase("2023-01-25", 25)>]
    [<TestCase("9999-11-30", 30)>]
    [<TestCase("0001-08-8", 8)>]
    member this.ValidDate date expect = 
        let day = getDayFromString date
        Assert.That(day.Value, Is.EqualTo(expect))

    [<TestCase("2024-02-30")>]
    [<TestCase("-2023-01-25")>]
    [<TestCase("99999-11-30")>]
    member this.InValidDate date = 
        let day = getDayFromString date
        Assert.That(day.IsNone, Is.True)

    [<TestCase("2024-01-01", 1)>]
    [<TestCase("2023-01-25", 25)>]
    [<TestCase("9999-11-30", 30)>]
    [<TestCase("0001-08-8", 8)>]
    member this.ValidDateWithMatch date expect = 
        let day = getDayFromStringWithMatch date
        Assert.That(day.Value, Is.EqualTo(expect))

    [<TestCase("2024-02-30")>]
    [<TestCase("-2023-01-25")>]
    [<TestCase("99999-11-30")>]
    member this.InValidDateWithMatch date = 
        let day = getDayFromStringWithMatch date
        Assert.That(day.IsNone, Is.True)

    [<Test>]
    member this.PriceWithDiscount () =
        let john = { Id = 1; Name = "John"; Discount = Some 0.1m }
        let actualPrice = getPrice john 10000m
        Assert.That(actualPrice, Is.EqualTo(9000m))

    [<Test>]
    member this.NullObject () =
        let nullObject : string = null
        let option = Option.ofObj nullObject
        Assert.That(option.IsNone, Is.True)

    [<Test>]
    member this.NullRef() =
        let nullRef = Nullable<int> ()
        let option = Option.ofNullable nullRef
        Assert.That(option.IsNone, Is.True)

    [<TestCase(10, 5, 2)>]
    [<TestCase(11, 2, 5.5)>]
    [<TestCase(100, 4, 25)>]
    member this.SuccessDivide x y expected =
        let result = tryDivide x y
        let actual = resultToOption result
        Assert.That(actual.Value, Is.EqualTo(expected))

    [<Test>]
    member this.failureDivide () =
        let result = tryDivide 100m 0m
        let actual = resultToOption result
        Assert.That(actual, Is.EqualTo(None))

    [<Test>]
    member this.DivideError () = 
        let result = DivideThenRoot 3m 0m
        Assert.That(result, Is.EqualTo("zero divide: 3 0"))

    [<Test>]
    member this.InvalidRoot () = 
        let result = DivideThenRoot 3m 1m
        Assert.That(result, Is.EqualTo("Root error: 3"))

    [<Test>]
    member this.DivideThenRoot () = 
        let result = DivideThenRoot 100m 4m
        Assert.That(result, Is.EqualTo("5"))

    [<Test>]
    member this.DivideErrorWithMap () = 
        let result = DivideThenRootWithMap 3m 0m
        Assert.That(result, Is.EqualTo("zero divide: 3 0"))

    [<Test>]
    member this.InvalidRootWithMap () = 
        let result = DivideThenRootWithMap -3m 1m
        Assert.That(result, Is.EqualTo("не число"))

    [<Test>]
    member this.DivideThenRootWithMap () = 
        let result = DivideThenRootWithMap 100m 4m
        Assert.That(result, Is.EqualTo("5"))
    
