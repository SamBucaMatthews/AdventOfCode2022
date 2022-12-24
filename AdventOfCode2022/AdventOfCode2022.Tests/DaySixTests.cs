namespace AdventOfCode2022.Tests;

using AdventOfCode2022.Solutions.DaySix;

public class DaySixTests
{
    [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void FindStartOfPacketMarker_GivenInputsFromExample_SolvesCorrectly(string input, int firstMarkerAfter)
    {
        var actual = DaySix.FindStartOfPacketMarker(input);
        
        Assert.That(actual, Is.EqualTo(firstMarkerAfter));
    }
}
