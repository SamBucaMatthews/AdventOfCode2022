namespace AdventOfCode2022.Tests.DayNineTests;

using AdventOfCode2022.Solutions.DayNine;

public class RopeTests
{

    private static readonly List<(MovementDirection direction, int steps, Coordinate headPosition, Coordinate tailPosition)>
        ExampleInput = new()
        {
            (MovementDirection.Right, 4, new Coordinate { X = 4, Y = 0 }, new Coordinate { X = 3, Y = 0 }),
            (MovementDirection.Up, 4, new Coordinate { X = 4, Y = -4 }, new Coordinate { X = 4, Y = -3 }),
            (MovementDirection.Left, 3, new Coordinate { X = 1, Y = -4 }, new Coordinate { X = 2, Y = -4 }),
            (MovementDirection.Down, 1, new Coordinate { X = 1, Y = -3 }, new Coordinate { X = 2, Y = -4 }),
            (MovementDirection.Right, 4, new Coordinate { X = 5, Y = -3 }, new Coordinate { X = 4, Y = -3 }),
            (MovementDirection.Down, 1, new Coordinate { X = 5, Y = -2 }, new Coordinate { X = 4, Y = -3 }),
            (MovementDirection.Left, 5, new Coordinate { X = 0, Y = -2 }, new Coordinate { X = 1, Y = -2 }),
            (MovementDirection.Right, 2, new Coordinate { X = 2, Y = -2 }, new Coordinate { X = 1, Y = -2 }),
        };

    private RopeSegment _headSegment = null!;
    private RopeSegment _tailSegment = null!;

    [SetUp]
    public void SetUp()
    {
        _headSegment = new RopeSegment();
        _tailSegment = new RopeSegment();

        _headSegment.Append(_tailSegment);
    }

    [Test]
    public void Move_GivenInstructionsFromExample_ExecutesEachMovementCorrectly()
    {
        foreach (var input in ExampleInput)
        {
            _headSegment.Move(input.direction, input.steps);

            Assert.Multiple(() =>
            {
                Assert.That(_headSegment.Position, Is.EqualTo(input.headPosition));
                Assert.That(_tailSegment.Position, Is.EqualTo(input.tailPosition));
            });
        }
    }
    
    [TestCase(1, -1, 0)]
    [TestCase(2, -2, -1)]
    [TestCase(3, -3, -2)]
    [TestCase(4, -4, -3)]
    public void Move_GivenOnlyUp_MovesCorrectly(
        int steps,
        int expectedHeadPositionY,
        int expectedTailPositionY)
    {
        var expectedHeadPosition = new Coordinate
        {
            X = 0,
            Y = expectedHeadPositionY,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = 0,
            Y = expectedTailPositionY,
        };

        _headSegment.Move(MovementDirection.Up, steps);

        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [TestCase(1, 1, 0)]
    [TestCase(2, 2, 1)]
    [TestCase(3, 3, 2)]
    [TestCase(4, 4, 3)]
    public void Move_GivenOnlyDown_MovesCorrectly(
        int steps,
        int expectedHeadPositionY,
        int expectedTailPositionY)
    {
        var expectedHeadPosition = new Coordinate
        {
            X = 0,
            Y = expectedHeadPositionY,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = 0,
            Y = expectedTailPositionY,
        };

        _headSegment.Move(MovementDirection.Down, steps);

        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [TestCase(1, -1, 0)]
    [TestCase(2, -2, -1)]
    [TestCase(3, -3, -2)]
    [TestCase(4, -4, -3)]
    public void Move_GivenOnlyLeft_MovesCorrectly(
        int steps,
        int expectedHeadPositionX,
        int expectedTailPositionX)
    {
        var expectedHeadPosition = new Coordinate
        {
            X = expectedHeadPositionX,
            Y = 0,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = expectedTailPositionX,
            Y = 0,
        };

        _headSegment.Move(MovementDirection.Left, steps);

        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [TestCase(1, 1, 0)]
    [TestCase(2, 2, 1)]
    [TestCase(3, 3, 2)]
    [TestCase(4, 4, 3)]
    public void Move_GivenOnlyRight_MovesCorrectly(
        int steps,
        int expectedHeadPositionX,
        int expectedTailPositionX)
    {
        var expectedHeadPosition = new Coordinate
        {
            X = expectedHeadPositionX,
            Y = 0,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = expectedTailPositionX,
            Y = 0,
        };

        _headSegment.Move(MovementDirection.Right, steps);

        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
        });
    }

    [Test]
    public void Move_GivenDiagonalMovementRightThenUp_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Right, 4);
        _headSegment.Move(MovementDirection.Up, 2);

        var expectedHeadPosition = new Coordinate
        {
            X = 4,
            Y = -2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = 4,
            Y = -1,
        };
        
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new() { X = 0, Y = 0 },
            new() { X = 1, Y = 0 },
            new() { X = 2, Y = 0 },
            new() { X = 3, Y = 0 },
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementLeftThenUp_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Left, 4);
        _headSegment.Move(MovementDirection.Up, 2);

        var expectedHeadPosition = new Coordinate
        {
            X = -4,
            Y = -2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = -4,
            Y = -1,
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementLeftThenDown_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Left, 4);
        _headSegment.Move(MovementDirection.Down, 2);

        var expectedHeadPosition = new Coordinate
        {
            X = -4,
            Y = 2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = -4,
            Y = 1,
        };

        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new() { X = 0, Y = 0 },
            new() { X = -1, Y = 0 },
            new() { X = -2, Y = 0 },
            new() { X = -3, Y = 0 },
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementRightThenDown_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Right, 4);
        _headSegment.Move(MovementDirection.Down, 2);

        var expectedHeadPosition = new Coordinate
        {
            X = 4,
            Y = 2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = 4,
            Y = 1,
        };
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new() { X = 0, Y = 0 },
            new() { X = 1, Y = 0 },
            new() { X = 2, Y = 0 },
            new() { X = 3, Y = 0 },
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementDownThenLeft_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Down, 2);
        _headSegment.Move(MovementDirection.Left, 4);

        var expectedHeadPosition = new Coordinate
        {
            X = -4,
            Y = 2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = -3,
            Y = 2,
        };
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new() { X = 0, Y = 0 },
            new() { X = 0, Y = 1 },
            new() { X = -1, Y = 1 },
            new() { X = -1, Y = 2 },
            new() { X = -2, Y = 2 },
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementDownThenRight_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Down, 2);
        _headSegment.Move(MovementDirection.Right, 4);

        var expectedHeadPosition = new Coordinate
        {
            X = 4,
            Y = 2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = 3,
            Y = 2,
        };
        
                
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new() { X = 0, Y = 0 },
            new() { X = 0, Y = 1 },
            new() { X = 1, Y = 1 },
            new() { X = 1, Y = 2 },
            new() { X = 2, Y = 2 },
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementUpThenRight_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Up, 2);
        _headSegment.Move(MovementDirection.Right, 4);

        var expectedHeadPosition = new Coordinate
        {
            X = 4,
            Y = -2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = 3,
            Y = -2,
        };
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new() { X = 0, Y = 0 },
            new() { X = 0, Y = -1 },
            new() { X = 1, Y = -1 },
            new() { X = 1, Y = -2 },
            new() { X = 2, Y = -2 },
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementUpThenLeft_MovesCorrectly()
    {
        _headSegment.Move(MovementDirection.Up, 2);
        _headSegment.Move(MovementDirection.Left, 4);

        var expectedHeadPosition = new Coordinate
        {
            X = -4,
            Y = -2,
        };
        
        var expectedTailPosition = new Coordinate
        {
            X = -3,
            Y = -2,
        };
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new() { X = 0, Y = 0 },
            new() { X = 0, Y = -1 },
            new() { X = -1, Y = -1 },
            new() { X = -1, Y = -2 },
            new() { X = -2, Y = -2 },
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
}