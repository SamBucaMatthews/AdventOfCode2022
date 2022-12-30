namespace AdventOfCode2022.Tests.DayNineTests;

using AdventOfCode2022.Solutions.DayNine;

public class RopeTests
{
    private static readonly Movement Right = new(1, 0);
    private static readonly Movement Up = new(0, -1);
    private static readonly Movement Left = new(-1, 0);
    private static readonly Movement Down = new(0, 1);

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
    public void Move_GivenInputsFromExampleAndTenSegments_MovesCorrectly()
    {
        /*
         *  R 5
            U 8
            L 8
            D 3
            R 17
            D 10
            L 25
            U 20
         */
        
        var third = new RopeSegment();
        var fourth = new RopeSegment();
        var fifth = new RopeSegment();
        var sixth = new RopeSegment();
        var seventh = new RopeSegment();
        var eighth = new RopeSegment();
        var ninth = new RopeSegment();
        var last = new RopeSegment();
        
        _tailSegment.Append(third);
        third.Append(fourth);
        fourth.Append(fifth);
        fifth.Append(sixth);
        sixth.Append(seventh);
        seventh.Append(eighth);
        eighth.Append(ninth);
        ninth.Append(last);

        for (var i = 0; i < 5; i++)
        {
            _headSegment.Move(Right);
        }
        
        Assert.That(last.Position, Is.EqualTo(new Coordinate(0, 0)));
        
        for (var i = 0; i < 8; i++)
        {
            _headSegment.Move(Up);
        }
        
        Assert.That(last.Position, Is.EqualTo(new Coordinate(0, 0)));

        
        for (var i = 0; i < 8; i++)
        {
            _headSegment.Move(Left);
        }

        Assert.That(last.Position, Is.EqualTo(new Coordinate(1, -3)));

        for (var i = 0; i < 3; i++)
        {
            _headSegment.Move(Down);
        }
        
        Assert.That(last.Position, Is.EqualTo(new Coordinate(1, -3)));

        for (var i = 0; i < 17; i++)
        {
            _headSegment.Move(Right);
        }
        
        Assert.That(last.Position, Is.EqualTo(new Coordinate(5, -5)));

        for (var i = 0; i < 10; i++)
        {
            _headSegment.Move(Down);
        }
        
        Assert.That(last.Position, Is.EqualTo(new Coordinate(10, 0)));

        for (var i = 0; i < 25; i++)
        {
            _headSegment.Move(Left);
        }

        Assert.That(last.Position, Is.EqualTo(new Coordinate(-2, 5)));

        for (var i = 0; i < 20; i++)
        {
            _headSegment.Move(Up);
        }
        
        Assert.That(last.Position, Is.EqualTo(new Coordinate(-11, -6)));
        
        Assert.That(last.PreviousPositions.Append(last.Position).Distinct().Count(), Is.EqualTo(36));
    }
    
    [Test]
    public void Move_GivenThreeSegments_MovesCorrectly()
    {
        var thirdSegment = new RopeSegment();
        _tailSegment.Append(thirdSegment);

        _headSegment.Move(Down);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(0, 1)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(0, 0)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(0, 0)));
        });
        
        _headSegment.Move(Down);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(0, 2)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(0, 1)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(0, 0)));

        });
        
        _headSegment.Move(Down);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(0, 3)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(0, 2)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(0, 1)));
        });
        
        _headSegment.Move(Down);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(0, 4)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(0, 3)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(0, 2)));
        });
        
        _headSegment.Move(Right);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(1, 4)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(0, 3)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(0, 2)));
        });
        
        _headSegment.Move(Right);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(2, 4)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(1, 4)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(1, 3)));
        });
        
        _headSegment.Move(Right);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(3, 4)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(2, 4)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(1, 3)));
        });
        
        _headSegment.Move(Up);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(new Coordinate(3, 3)));
            Assert.That(_tailSegment.Position, Is.EqualTo(new Coordinate(2, 4)));
            Assert.That(thirdSegment.Position, Is.EqualTo(new Coordinate(1, 3)));
        });
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
        var expectedHeadPosition = new Coordinate(0, expectedHeadPositionY);
        var expectedTailPosition = new Coordinate(0, expectedTailPositionY);

        for (var i = 0; i < steps; i++)
        {
            _headSegment.Move(Up);
        }

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
        var expectedHeadPosition = new Coordinate(0, expectedHeadPositionY);
        var expectedTailPosition = new Coordinate(0, expectedTailPositionY);
        
        for (var i = 0; i < steps; i++)
        {
            _headSegment.Move(Down);
        }

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
        var expectedHeadPosition = new Coordinate(expectedHeadPositionX, 0);
        var expectedTailPosition = new Coordinate(expectedTailPositionX, 0);

        for (var i = 0; i < steps; i++)
        {
            _headSegment.Move(Left);
        }
        
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
        var expectedHeadPosition = new Coordinate(expectedHeadPositionX, 0);
        var expectedTailPosition = new Coordinate(expectedTailPositionX, 0);
        
        for (var i = 0; i < steps; i++)
        {
            _headSegment.Move(Right);
        }

        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
        });
    }

    [Test]
    public void Move_GivenDiagonalMovementRightThenUp_MovesCorrectly()
    {
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Right);
        }
        
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Up);
        }

        var expectedHeadPosition = new Coordinate(4, -2);
        var expectedTailPosition = new Coordinate(4, -1);
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new(0, 0),
            new(1, 0),
            new(2, 0),
            new(3, 0),
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
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Left);
        }
        
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Up);
        }

        var expectedHeadPosition = new Coordinate(-4, -2);
        var expectedTailPosition = new Coordinate(-4, -1);
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementLeftThenDown_MovesCorrectly()
    {
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Left);
        }
        
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Down);
        }

        var expectedHeadPosition = new Coordinate(-4, 2);
        var expectedTailPosition = new Coordinate(-4, 1);

        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new(0, 0),
            new(-1, 0),
            new(-2, 0),
            new(-3, 0),
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
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Right);
        }
        
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Down);
        }

        var expectedHeadPosition = new Coordinate(4, 2);
        var expectedTailPosition = new Coordinate(4, 1);
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new(0, 0),
            new(1, 0),
            new(2, 0),
            new(3, 0),
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
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Down);
        }
        
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Left);
        }

        var expectedHeadPosition = new Coordinate(-4, 2);
        var expectedTailPosition = new Coordinate(-3, 2);
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new(0, 0),
            new(0, 1),
            new(-1, 2),
            new(-2, 2),
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
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Down);
        }
        
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Right);
        }

        var expectedHeadPosition = new Coordinate(4, 2);
        var expectedTailPosition = new Coordinate(3, 2);
                
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new(0, 0),
            new(0, 1),
            new(1, 2),
            new(2, 2),
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
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Up);
        }
        
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Right);
        }

        var expectedHeadPosition = new Coordinate(4, -2);
        var expectedTailPosition = new Coordinate(3, -2);
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new(0, 0),
            new(0, -1),
            new(1, -2),
            new(2, -2),
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
        for (var i = 0; i < 2; i++)
        {
            _headSegment.Move(Up);
        }
        
        for (var i = 0; i < 4; i++)
        {
            _headSegment.Move(Left);
        }

        var expectedHeadPosition = new Coordinate(-4, -2);
        var expectedTailPosition = new Coordinate(-3, -2);
        
        var expectedPreviousTailPositions = new List<Coordinate>
        {
            new(0, 0),
            new(0, -1),
            new(-1, -2),
            new(-2, -2),
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(_headSegment.Position, Is.EqualTo(expectedHeadPosition));
            Assert.That(_tailSegment.Position, Is.EqualTo(expectedTailPosition));
            Assert.That(_tailSegment.PreviousPositions, Is.EqualTo(expectedPreviousTailPositions));
        });
    }
}