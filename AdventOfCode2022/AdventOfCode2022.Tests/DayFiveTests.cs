using AdventOfCode2022.Solutions.DayFive;

namespace AdventOfCode2022.Tests;

public class DayFiveTests
{
    private static readonly List<string> ExampleInput = new() {
        "    [D]    ",
        "[N] [C]    ",
        "[Z] [M] [P]",
        " 1   2   3 ",

        "move 1 from 2 to 1",
        "move 3 from 1 to 3",
        "move 2 from 2 to 1",
        "move 1 from 1 to 2",
    };

    [Test]
    public void GetCratesAtTopOfEachStack_GivenExampleInput_SolvesCorrectly()
    {
        const string expected = "CMZ";
        var actual = DayFive.GetCratesAtTopOfEachStack(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
