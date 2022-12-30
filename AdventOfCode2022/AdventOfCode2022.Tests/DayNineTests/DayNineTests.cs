namespace AdventOfCode2022.Tests.DayNineTests;

using AdventOfCode2022.Solutions.DayNine;

public class DayNineTests
{
    private static readonly string[] ExampleInput1 =
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
    
    private static readonly string[] ExampleInput2 =
    {
        "R 5",
        "U 8",
        "L 8",
        "D 3",
        "R 17",
        "D 10",
        "L 25",
        "U 20",
    };

    [TestCase(2, 13)]
    [TestCase(10, 1)]
    public void CountPositionsVisitedByTail_GivenInputsFromExample1_SolvesCorrectly(int ropeSegments, int expected)
    {
        var actual = DayNine.CountPositionsVisitedByTail(ExampleInput1, ropeSegments);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CountPositionsVisitedByTail_GivenInputsFromExample2_SolvesCorrectly()
    {
        const int expected = 36;

        var actual = DayNine.CountPositionsVisitedByTail(ExampleInput2, 10);

        Assert.That(actual, Is.EqualTo(expected));
    }
}