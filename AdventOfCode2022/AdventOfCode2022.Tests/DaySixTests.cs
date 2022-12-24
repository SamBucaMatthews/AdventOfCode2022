namespace AdventOfCode2022.Tests;

using AdventOfCode2022.Solutions.DaySix;

public class DaySixTests
{
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void FindStartOfMarker_GivenInputsFromExampleAndFourCharacters_SolvesCorrectly(
        string input,
        int firstMarkerAfter)
    {
        var actual = DaySix.FindStartOfMarker(input, 4);
        
        Assert.That(actual, Is.EqualTo(firstMarkerAfter));
    }
    
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void FindStartOfMarker_GivenInputsFromExampleAndFourteenCharacters_SolvesCorrectly(
        string input,
        int firstMarkerAfter)
    {
        var actual = DaySix.FindStartOfMarker(input, 14);
        
        Assert.That(actual, Is.EqualTo(firstMarkerAfter));
    }
}
