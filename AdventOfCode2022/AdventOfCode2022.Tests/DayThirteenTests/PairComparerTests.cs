namespace AdventOfCode2022.Tests.DayThirteenTests;

using AdventOfCode2022.Solutions.DayThirteen;

public class PairComparerTests
{
    [Test]
    public void PairsInCorrectOrder_GivenTwoEmptyPairs_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object>(),
            new List<object>());

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }

    [Test]
    public void PairsInCorrectOrder_GivenSameInts_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { 1 },
            new List<object> { 1 });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenIntsInCorrectOrder_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { 1, 2, 3 },
            new List<object> { 4, 5, 6 });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenIntsInWrongOrder_ReturnsFalse()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { 4, 5, 6 },
            new List<object> { 1, 2, 3 });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(false));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenTwoEmptyLists_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object>() },
            new List<object> { new List<object>() });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }

    [Test]
    public void PairsInCorrectOrder_GivenTwoNestedEmptyLists_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { new List<object>() } },
            new List<object> { new List<object> { new List<object>() } });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenTwoIdenticalLists_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { 1 } },
            new List<object> { new List<object> { 1 } });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenTwoListsWithIntsInCorrectOrder_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { 1, 1, 3, 1, 1 } },
            new List<object> { new List<object> { 1, 1, 5, 1, 1 } });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenTwoListsWithIntsInWrongOrder_ReturnsFalse()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { 4, 5, 6 } },
            new List<object> { new List<object> { 1, 2, 3 } });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(false));
    }
    
    [Test]
    public void PairsInCorrectOrder_WhenRightSideRunsOutOfItems_ReturnsFalse()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { 7, 7, 7, 7 },
            new List<object> { 7, 7, 7 });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(false));
    }
    
    [Test]
    public void PairsInCorrectOrder_WhenLeftSideRunsOutOfItems_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object>(),
            new List<object> { 3 });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenMixedListInCorrectOrder_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { 4, 4 }, 4, 4 },
            new List<object> { new List<object> { 4, 4 }, 4, 4, 4 });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenEmptyListsWhenRightSideRunsOutFirst_ReturnsFalse()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { new List<object>() } },
            new List<object> { new List<object>() });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(false));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenEmptyListsWhenLeftSideRunsOutFirst_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object>() },
            new List<object> { new List<object> { new List<object>() } });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenListsWithIntsWhenLeftSideRunsOutFirst_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { 1, 2 } },
            new List<object> { new List<object> { new List<object> { 1, 2, 3 } } });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenListsWithIntsWhenRightSideRunsOutFirst_ReturnsFalse()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<object> { new List<object> { 1, 2, 3 } } },
            new List<object> { new List<object> { 1, 2 } });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(false));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenDeeplyNestedListsInWrongOrder_ReturnsFalse()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object>
            {
                1,
                new List<object> { 2, new List<object> { 3, new List<object> { 4, new List<object> { 5, 6, 7 }, } } },
                8, 9
            },
            new List<object>
            {
                1, new List<object> { 2, new List<object> { 3, new List<object> { 4, new List<object> { 5, 6, 0 } } } },
                8, 9
            });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(false));
    }
    
    [Test]
    public void PairsInCorrectOrder_GivenMixedListsInCorrectOrder_ReturnsTrue()
    {
        var pairs = new Tuple<object?, object?>(
            new List<object> { new List<int> { 1 }, new List<int> { 2, 3, 4 } },
            new List<object> { new List<int> { 1 }, 4 });

        var actual = PairComparer.PairsInCorrectOrder(pairs);
        
        Assert.That(actual, Is.EqualTo(true));
    }
}
