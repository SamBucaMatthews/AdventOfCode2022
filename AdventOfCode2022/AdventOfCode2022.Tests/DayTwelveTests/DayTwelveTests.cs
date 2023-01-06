using AdventOfCode2022.Solutions.DayTwelve;

namespace AdventOfCode2022.Tests.DayTwelveTests;

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
    public void FindFewestStepsToGoalFromStart_GivenInputFromExample_SolvesCorrectly()
    {
        const int expected = 31;
        var actual = DayTwelve.FindFewestStepsToGoal(ExampleInput, new []{ 'S' });
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void FindFewestStepsToGoalFromAllLowestPositions_GivenInputFromExample_SolvesCorrectly()
    {
        const int expected = 29;
        var actual = DayTwelve.FindFewestStepsToGoal(ExampleInput, new []{ 'S', 'a' });
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
