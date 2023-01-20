using AdventOfCode2022.Solutions.DayFourteen;

namespace AdventOfCode2022.Tests.DayFourteenTests;

public class DayFourteenTests
{
    private static readonly string[] ExampleInput =
    {
        "498,4 -> 498,6 -> 496,6",
        "503,4 -> 502,4 -> 502,9 -> 494,9"
    };

    [Test]
    public void CountUnitsOfSand_GivenExampleFromInput_SolvesCorrectly()
    {
        const int expected = 24;

        var actual = DayFourteen.CountUnitsOfSand(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
