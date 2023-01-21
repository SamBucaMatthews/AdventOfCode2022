using AdventOfCode2022.Solutions.DayFourteen;

namespace AdventOfCode2022.Tests.DayFourteenTests;

public class CaveTests
{
    private static readonly Point StartingPoint = new(500, 0);

    private static readonly string[] ExampleInput =
    {
        "498,4 -> 498,6 -> 496,6",
        "503,4 -> 502,4 -> 502,9 -> 494,9"
    };

    [Test]
    public void Parse_GivenExampleFromInput_ParsesRocksCorrectly()
    {
        var expectedRocks = new HashSet<Point>
        {
            new(498, 4),
            new(498, 5),
            new(498, 6),

            new(497, 6),
            new(496, 6),
            
            new(503, 4),
            new(502, 4),

            new(502, 5),
            new(502, 6),
            new(502, 7),
            new(502, 8),
            new(502, 9),
            
            new(502, 9),
            new(501, 9),
            new(500, 9),
            new(499, 9),
            new(498, 9),
            new(497, 9),
            new(496, 9),
            new(495, 9),
            new(494, 9),
        };

        var cave = new Cave(ExampleInput, StartingPoint);
        
        Assert.That(cave.Rocks, Is.EquivalentTo(expectedRocks));
    }

    [Test]
    public void Parse_GivenInputWithOneVerticalRockLine_ParsesRocksCorrectly()
    {
        const string input = "100,0 -> 103,0";

        var expectedRocks = new HashSet<Point>
        {
            new(100, 0),
            new(101, 0),
            new(102, 0),
            new(103, 0),
        };

        var cave = new Cave(new[] { input }, StartingPoint);
        
        Assert.That(cave.Rocks, Is.EquivalentTo(expectedRocks));
    }
    
    [Test]
    public void Parse_GivenInputWithOneHorizontalRockLine_ParsesRocksCorrectly()
    {
        const string input = "100,0 -> 100,3";

        var expectedRocks = new HashSet<Point>
        {
            new(100, 0),
            new(100, 1),
            new(100, 2),
            new(100, 3),
        };

        var cave = new Cave(new[] { input }, StartingPoint);
        
        Assert.That(cave.Rocks, Is.EquivalentTo(expectedRocks));
    }
    
    [Test]
    public void Parse_GivenInputWithBothHorizontalAndVerticalRockLines_ParsesRocksCorrectly()
    {
        const string input = "100,0 -> 100,3 -> 103,3";

        var expectedRocks = new HashSet<Point>
        {
            new(100, 0),
            new(100, 1),
            new(100, 2),
            new(100, 3),
            new(101, 3),
            new(102, 3),
            new(103, 3),
        };

        var cave = new Cave(new[] { input }, StartingPoint);
        
        Assert.That(cave.Rocks, Is.EquivalentTo(expectedRocks));
    }

    [Test]
    public void ProduceSand_GivenSingleCycleAndInputFromExample_UpdatesSettledSandCorrectly()
    {
        var expectedSettledSand = new HashSet<Point>
        {
            new(500, 8),
        };

        var cave = BuildCaveFromExample();

        ProduceSand(cave, 1);
        
        Assert.That(cave.SettledSand, Is.EquivalentTo(expectedSettledSand));
    }
    
    [Test]
    public void ProduceSand_GivenTwoCyclesAndInputFromExample_UpdatesSettledSandCorrectly()
    {
        var expectedSettledSand = new HashSet<Point>
        {
            new(500, 8),
            new(499, 8),
        };

        var cave = BuildCaveFromExample();

        ProduceSand(cave, 2);
        
        Assert.That(cave.SettledSand, Is.EquivalentTo(expectedSettledSand));
    }
    
    [Test]
    public void ProduceSand_GivenFiveCyclesAndInputFromExample_UpdatesSettledSandCorrectly()
    {
        var expectedSettledSand = new HashSet<Point>
        {
            new(500, 8),
            new(499, 8),
            new(500, 7),
            new(498, 8),
            new(501, 8),
        };

        var cave = BuildCaveFromExample();

        ProduceSand(cave, 5);
        
        Assert.That(cave.SettledSand, Is.EquivalentTo(expectedSettledSand));
    }
    
    [Test]
    public void ProduceSand_Given22CyclesAndInputFromExample_UpdatesSettledSandCorrectly()
    {
        var expectedSettledSand = new HashSet<Point>
        {
            new(497, 8),

            new(498, 8),
            new(498, 7),

            new(499, 3),
            new(499, 4),
            new(499, 5),
            new(499, 6),
            new(499, 7),
            new(499, 8),

            new(500, 2),
            new(500, 3),
            new(500, 4),
            new(500, 5),
            new(500, 6),
            new(500, 7),
            new(500, 8),
            
            new(501, 3),
            new(501, 4),
            new(501, 5),
            new(501, 6),
            new(501, 7),
            new(501, 8),
        };

        var cave = BuildCaveFromExample();

        ProduceSand(cave, 22);
        
        Assert.That(cave.SettledSand, Is.EquivalentTo(expectedSettledSand));
    }

    [Test]
    public void ProduceSand_Given24CyclesAndInputFromExample_UpdatesSettledSandCorrectly()
    {
        var expectedSettledSand = new HashSet<Point>
        {
            new(495, 8),

            new(497, 5),
            new(497, 8),

            new(498, 8),
            new(498, 7),

            new(499, 3),
            new(499, 4),
            new(499, 5),
            new(499, 6),
            new(499, 7),
            new(499, 8),

            new(500, 2),
            new(500, 3),
            new(500, 4),
            new(500, 5),
            new(500, 6),
            new(500, 7),
            new(500, 8),
            
            new(501, 3),
            new(501, 4),
            new(501, 5),
            new(501, 6),
            new(501, 7),
            new(501, 8),
        };

        var cave = BuildCaveFromExample();

        ProduceSand(cave, 24);
        
        Assert.That(cave.SettledSand, Is.EquivalentTo(expectedSettledSand));
    }

    [Test]
    public void RunUntilOverflow_GivenInputFromExample_SolvesCorrectly()
    {
        const int expected = 24;
        var cave = BuildCaveFromExample();

        cave.RunUntilOverflow();

        Assert.That(cave.SettledSand, Has.Count.EqualTo(expected));
    }

    private static void ProduceSand(Cave cave, int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            cave.ProduceSand();
        }
    }

    private static Cave BuildCaveFromExample() => new(ExampleInput, StartingPoint);
}