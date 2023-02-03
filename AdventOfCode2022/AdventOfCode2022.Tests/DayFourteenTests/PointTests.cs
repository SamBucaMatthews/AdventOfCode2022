using AdventOfCode2022.Solutions.DayFourteen;

namespace AdventOfCode2022.Tests.DayFourteenTests;

public class PointTests
{
    [Test]
    public void Parse_GivenValidString_ReturnsCorrectPoint()
    {
        const string input = "498,4";
        var expected = new Point(498, 4);

        var actual = Point.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(",0")]
    [TestCase("4980")]
    [TestCase("498,")]
    public void Parse_GivenStringWithoutBothParts_ThrowsArgumentException(string input)
    {
        Assert.That(() => Point.Parse(input), Throws.TypeOf<ArgumentException>());
    }
}
