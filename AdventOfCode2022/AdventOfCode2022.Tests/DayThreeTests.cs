using AdventOfCode2022.Solutions.DayThree;

namespace AdventOfCode2022.Tests;

public class DayThreeTests
{
    private static readonly string[] ExampleInput = {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw",
    };
    
    [Test]
    public void CalculatePriorities_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 157;
        var actual = DayThree.CalculatePriorities(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
        
    }
}
