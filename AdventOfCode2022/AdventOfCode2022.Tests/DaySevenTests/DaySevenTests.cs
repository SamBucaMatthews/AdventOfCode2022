namespace AdventOfCode2022.Tests.DaySevenTests;

using AdventOfCode2022.Solutions.DaySeven;

public class DaySevenTests
{
    private static readonly List<string> ExampleInput = new()
    {
        "$ cd /",
        "$ ls",
        "dir a",
        "14848514 b.txt",
        "8504156 c.dat",
        "dir d",
        "$ cd a",
        "$ ls",
        "dir e",
        "29116 f",
        "2557 g",
        "62596 h.lst",
        "$ cd e",
        "$ ls",
        "584 i",
        "$ cd ..",
        "$ cd ..",
        "$ cd d",
        "$ ls",
        "4060174 j",
        "8033020 d.log",
        "5626152 d.ext",
        "7214296 k",
    };
    
    [Test]
    public void FindSumOfTotalMatchingDirectories_GivenInputsFromExampleAnd_SolvesCorrectly()
    {
        const int expected = 95437;
        var actual = DaySeven.FindSumOfTotalMatchingDirectories(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
