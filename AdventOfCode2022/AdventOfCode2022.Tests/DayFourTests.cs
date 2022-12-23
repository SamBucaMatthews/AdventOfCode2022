using AdventOfCode2022.Solutions.DayFour;

namespace AdventOfCode2022.Tests;

public class DayFourTests
{
    private static readonly string[] ExampleInput =
    {
        "2-4,6-8",
        "2-3,4-5",
        "5-7,7-9",
        "2-8,3-7",
        "6-6,4-6",
        "2-6,4-8"
    };
    
    [Test]
    public void CountFullyOverlappingAssignmentPairs_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 2;
        var actual = DayFour.CountFullyOverlappingAssignmentPairs(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}