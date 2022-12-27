namespace AdventOfCode2022.Tests;

using AdventOfCode2022.Solutions.DayEight;

public class DayEightTests
{
    private static readonly string[] ExampleInput =
    {
        "30373",
        "25512",
        "65332",
        "33549",
        "35390",
    };

    [Test]
    public void CountVisibleTrees_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 21;

        var dayEight = new DayEight(ExampleInput);

        var actual = dayEight.CountVisibleTrees();
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CountVisibleTrees_GivenAllVisibleTrees_SolvesCorrectly()
    {
        var input = new[]
        {
            "000",
            "010",
            "000",
        };

        const int expected = 9;

        var dayEight = new DayEight(input);

        var actual = dayEight.CountVisibleTrees();

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CountVisibleTrees_GivenOneHiddenTree_SolvesCorrectly()
    {
        var input = new[]
        {
            "000",
            "000",
            "000",
        };

        const int expected = 8;

        var dayEight = new DayEight(input);

        var actual = dayEight.CountVisibleTrees();

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CountVisibleTrees_GivenInteriorTreeVisibleFromRightSide_SolvesCorrectly()
    {
        var input = new[]
        {
            "111",
            "110",
            "111",
        };

        const int expected = 9;

        var dayEight = new DayEight(input);

        var actual = dayEight.CountVisibleTrees();

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CountVisibleTrees_GivenInteriorTreeVisibleFromTopSide_SolvesCorrectly()
    {
        var input = new[]
        {
            "101",
            "111",
            "111",
        };

        const int expected = 9;

        var dayEight = new DayEight(input);

        var actual = dayEight.CountVisibleTrees();

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CountVisibleTrees_GivenInteriorTreeVisibleFromLeftSide_SolvesCorrectly()
    {
        var input = new[]
        {
            "111",
            "011",
            "111",
        };

        const int expected = 9;

        var dayEight = new DayEight(input);

        var actual = dayEight.CountVisibleTrees();

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CountVisibleTrees_GivenInteriorTreeVisibleFromBottomSide_SolvesCorrectly()
    {
        var input = new[]
        {
            "111",
            "111",
            "101",
        };

        const int expected = 9;

        var dayEight = new DayEight(input);

        var actual = dayEight.CountVisibleTrees();

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CountVisibleTrees_GivenFourFullyVisibleTreesInInterior_SolvesCorrectly()
    {
        var input = new[]
        {
            "1111",
            "1221",
            "1221",
            "1111",
        };

        const int expected = 16;

        var dayEight = new DayEight(input);

        var actual = dayEight.CountVisibleTrees();

        Assert.That(actual, Is.EqualTo(expected));
    }
}
