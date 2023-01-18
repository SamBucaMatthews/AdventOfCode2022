namespace AdventOfCode2022.Tests.DayThirteenTests;

using AdventOfCode2022.Solutions.DayThirteen;

public class DayThirteenTests
{
    private static readonly string[] ExampleInput = {
        "[1,1,3,1,1]",
        "[1,1,5,1,1]",
        "",
        "[[1],[2,3,4]]",
        "[[1],4]",
        "",
        "[9]",
        "[[8,7,6]]",
        "",
        "[[4,4],4,4]",
        "[[4,4],4,4,4]",
        "",
        "[7,7,7,7]",
        "[7,7,7]",
        "",
        "[]",
        "[3]",
        "",
        "[[[]]]",
        "[[]]",
        "",
        "[1,[2,[3,[4,[5,6,7]]]],8,9]",
        "[1,[2,[3,[4,[5,6,0]]]],8,9]",
    };

    [Test]
    public void SumIndicesOfCorrectlyOrderedPairs_GivenInputFromExample_SolvesCorrectly()
    {
        const int expected = 13;

        var actual = DayThirteen.SumIndicesOfCorrectlyOrderedPairs(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetDecoderKey_GivenInputFromExample_SolvesCorrectly()
    {
        const int expected = 140;

        var actual = DayThirteen.GetDecoderKey(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
