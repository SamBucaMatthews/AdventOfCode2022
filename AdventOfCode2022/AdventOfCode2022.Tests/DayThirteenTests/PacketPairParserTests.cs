namespace AdventOfCode2022.Tests.DayThirteenTests;

using AdventOfCode2022.Solutions.DayThirteen;

public class PacketPairParserTests
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
    };

    [Test]
    public void ParsePairs_GivenInputFromExample_ParsesPairsCorrectly()
    {
        var expected = new List<Tuple<List<object>, List<object>>>
        {
            new(new List<object> { 1, 1, 3, 1, 1, }, new List<object> { 1, 1, 5, 1, 1 }),
            new(new List<object> { new List<int> { 1 }, new List<int> { 2, 3, 4 } },
                new List<object> { new List<int> { 1 }, 4 }),
            new(new List<object> { 9 }, new List<object> { new List<int> { 8, 7, 6 } }),
            new(new List<object> { new List<int> { 4, 4 }, 4, 4 },
                new List<object> { new List<int> { 4, 4 }, 4, 4, 4 }),
            new(new List<object> { 7, 7, 7, 7 }, new List<object> { 7, 7, 7 }),
            new(new List<object>(), new List<object> { 3 }),
            new(new List<object> { new List<object> { new List<object>() } }, new List<object> { new List<object>() }),
        };
        
        var actual = PacketPairParser.ParsePairs(ExampleInput);
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Parse_GivenEmptyInput_ReturnsEmptyList()
    {
        const string input = "[]";
        var expected = new List<object>();

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Parse_GivenListWithSingleInts_ReturnsListWithInts()
    {
        const string input = "[2]";
        var expected = new List<object> { 2 };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Parse_GivenListWithManyInts_ReturnsListWithInts()
    {
        const string input = "[2, 3, 7]";
        var expected = new List<object> { 2, 3, 7 };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Parse_GivenListWithInnerEmptyList_ReturnsListWithList()
    {
        const string input = "[[]]";
        var expected = new List<object> { new List<object>() };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Parse_GivenListWithInnerListWithSingleInt_ReturnsListInnerList()
    {
        const string input = "[[1]]";
        var expected = new List<object> { new List<object> { 1 } };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Parse_GivenListWithInnerListWithMultipleInts_ReturnsListInnerList()
    {
        const string input = "[[1, 5, 3]]";
        var expected = new List<object> { new List<object> { 1, 5, 3 } };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Parse_GivenListWithListAndInts_ParsesCorrectly()
    {
        const string input = "[[1, 5, 3], 4, 5]";
        var expected = new List<object>
        {
            new List<object> { 1, 5, 3 },
            4,
            5,
        };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Parse_GivenListWithManyLists_ParsesCorrectly()
    {
        const string input = "[[1], [4], [5]]";
        var expected = new List<object>
        {
            new List<object> { 1 },
            new List<object> { 4 },
            new List<object> { 5 },
        };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void Parse_GivenListWithDeeplyNestedList_ParsesCorrectly()
    {
        const string input = "[[[[[1]]]]]";
        var expected = new List<object>
        {
            new List<object>
            {
                new List<object>
                {
                    new List<object>
                    {
                        new List<object> { 1 },
                    }
                }
            },
        };

        var actual = PacketPairParser.Parse(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}