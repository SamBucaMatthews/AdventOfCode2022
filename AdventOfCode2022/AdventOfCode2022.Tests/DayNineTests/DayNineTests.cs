namespace AdventOfCode2022.Tests.DayNineTests;

using AdventOfCode2022.Solutions.DayNine;

public class DayNineTests
{
    private static readonly string[] ExampleInput =
    {
        "R 4",
        "U 4",
        "L 3",
        "D 1",
        "R 4",
        "D 1",
        "L 5",
        "R 2",
    };

    [Test]
    public void CountPositionsVisitedByTail_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 13;

        var actual = DayNine.CountPositionsVisitedByTail(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}