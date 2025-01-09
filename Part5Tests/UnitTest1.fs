module Part5Tests

open NUnit.Framework
open FsUnit
open System
open Part5.Collections

[<TestFixture>]
type CollectionsTests() = 

    //[<TestCase("2024-01-01", 1)>]
    //[<TestCase("2023-01-25", 25)>]
    //[<TestCase("9999-11-30", 30)>]
    //[<TestCase("0001-08-8", 8)>]
    //member this.ValidDate date expect = 
    //    let day = getDayFromString date
    //    Assert.That(day.Value, Is.EqualTo(expect))

    [<Test>]
    member this.LengthTest () = 
        let values = []
        Assert.That(values.Length, Is.Zero)


    [<Test>]
    member this.ListMethods () = 
        let values = [1;3;5;7]
        
        Assert.Throws<ArgumentException>(fun () -> values[5] |> ignore) |> ignore
        Assert.That(values.Length, Is.EqualTo(4))
        Assert.That(values.Head, Is.EqualTo(1))
        Assert.That(values.Tail, Is.EquivalentTo([3;5;7]))

    [<Test>]
    member this.ListComprehensionTest () =
        let items = [for x in 7..13 do x]
        Assert.That(items, Is.EquivalentTo([7;8;9;10;11;12;13]))

    [<Test>]
    member this.ExtendList () =
        let items = [for x in 7..13 do x]
        let actual = 6 :: items
        Assert.That(actual, Is.EquivalentTo([6;7;8;9;10;11;12;13]))

    [<Test>]
    member this.PatternMatching () =
        let items = [for x in 7..13 do x]
        let actual = 6 :: items
        actual |> should equivalent [6;7;8;9;10;11;12;13]

    [<Test>]
    member this.HeadAsOption () =
        head [] |> should equal None
        head [1] |> should equal (Some 1)
        head ["a";"c"] |> should equal (Some "a")

    [<Test>]
    member this.Concatenate () =
        let first = [1;2]
        let second = [3;4]
        let actual = first @ second
        actual |> should equivalent [1;2;3;4]

    [<Test>]
    member this.Map () =
        let items = [2;4;6]
        let actual = items |> List.map (fun x -> x + 1)
        actual |> should equivalent [3;5;7]

    [<Test>]
    member this.Reduce () =
        let items = [2;4;6]
        let actual = items |> List.reduce (fun x y -> x + y) 
        actual |> should equal 12

    [<Test>]
    member this.Fold () =
        let folded = [1..10] |> List.fold (+) 0
        let reduced = [1..10] |> List.reduce (+)
        folded |> should equal reduced

    [<Test>]
    member this.ForwardPipe () =
        let items = [2;4;6;8;]
        let actual = (0, items) ||> List.fold (+) 
        actual |> should equal 20

