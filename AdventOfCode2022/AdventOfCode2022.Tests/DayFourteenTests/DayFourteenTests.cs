using AdventOfCode2022.Solutions.DayFourteen;

namespace AdventOfCode2022.Tests.DayFourteenTests;

public class DayFourteenTests
{
    private static readonly string[] ExampleInput =
    {
        "498,4 -> 498,6 -> 496,6",
        "503,4 -> 502,4 -> 502,9 -> 494,9"
    };

    [TestCase(24, false)]
    [TestCase(93, true)]
    public void CountUnitsOfSand_GivenExampleFromInputWithNoFloor_SolvesCorrectly(int expected, bool hasFloor)
    {
        var actual = DayFourteen.CountUnitsOfSand(ExampleInput, hasFloor);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
