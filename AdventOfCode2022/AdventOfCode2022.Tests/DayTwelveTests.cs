namespace AdventOfCode2022.Tests;

using AdventOfCode2022.Solutions.DayTwelve;

public class DayTwelveTests
{
    private static readonly string[] ExampleInput =
    {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi",
    };

    [Test]
    public void FindFewestStepsToGoal_GivenInputFromExample_SolvesCorrectly()
    {
        const int expected = 31;
        var actual = DayTwelve.FindFewestStepsToGoal(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
