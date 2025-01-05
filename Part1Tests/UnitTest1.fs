module Part1Tests

open NUnit.Framework
open Part1.Persons

[<TestFixture>]
type PersonsTests() = 
    [<Test>]
    member this.CheckMe () = 
        let me = Employee { Id = 1; Name = "Daniil"; LastName = "MyFamily" }
        let name, lastName = Name me
        Assert.That(name, Is.EqualTo("Daniil"))
        Assert.That(lastName, Is.EqualTo("MyFamily"))

    [<TestCase(800, 800)>]
    [<TestCase(1000, 1000)>]
    [<TestCase(1001, 900.9)>]
    [<TestCase(5000, 4500)>]
    [<TestCase(10000, 9000)>]
    [<TestCase(10001, 8000.8)>]
    [<TestCase(15569, 12455.2)>]
    member this.CalculateEmployeePrice(spend : decimal, expected : decimal) = 
        let employee = Employee { Id = 3; Name = "PersonName"; LastName = "PersonLastName"}
        let actual = CalculatePrice employee spend
        Assert.That(actual, Is.EqualTo(expected))

    [<TestCase(800, 800)>]
    [<TestCase(1000, 1000)>]
    [<TestCase(1001, 1001)>]
    [<TestCase(5000, 5000)>]
    [<TestCase(10000, 10000)>]
    [<TestCase(10001, 10001)>]
    [<TestCase(15569, 15569)>]
    member this.CalculateNotEmployeePrice(spend : decimal, expected : decimal) = 
        let person = Customer { Id = 3; Name = "PersonName"; LastName = "PersonLastName" }
        let actual = CalculatePrice person spend
        Assert.That(actual, Is.EqualTo(expected))

[<TestFixture>]
type OtherTests() = 
    [<Test>]
    member this.Mutable () = 
        let mutable value = 23
        value <- 22
        Assert.That(value, Is.EqualTo(22))
