namespace AdventOfCode2022.Tests.DayNineTests;

using AdventOfCode2022.Solutions.DayNine;

public class RopeTests
{

    private static readonly List<(string instruction, Coordinate headPosition, Coordinate tailPosition)> ExampleInput =
        new()
        {
            ("R 4", new Coordinate { X = 4, Y = 0 }, new Coordinate { X = 3, Y = 0 }),
            ("U 4", new Coordinate { X = 4, Y = -4 }, new Coordinate { X = 4, Y = -3 }),
            ("L 3", new Coordinate { X = 1, Y = -4 }, new Coordinate { X = 2, Y = -4 }),
            ("D 1", new Coordinate { X = 1, Y = -3 }, new Coordinate { X = 2, Y = -4 }),
            ("R 4", new Coordinate { X = 5, Y = -3 }, new Coordinate { X = 4, Y = -3 }),
            ("D 1", new Coordinate { X = 5, Y = -2 }, new Coordinate { X = 4, Y = -3 }),
            ("L 5", new Coordinate { X = 0, Y = -2 }, new Coordinate { X = 1, Y = -2 }),
            ("R 2", new Coordinate { X = 2, Y = -2 }, new Coordinate { X = 1, Y = -2 }),
        };

    private Rope _rope = null!;

    [SetUp]
    public void SetUp()
    {
        _rope = new Rope();
    }

    [Test]
    public void Move_GivenInstructionsFromExample_ExecutesEachMovementCorrectly()
    {
        foreach (var input in ExampleInput)
        {
            var moveResults = _rope.Move(input.instruction).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(input.headPosition));
                Assert.That(moveResults.Last().TailPosition, Is.EqualTo(input.tailPosition));
            });
        }
    }

    [Test]
    public void Move_GivenInvalidInstruction_ThrowsInvalidArgumentException() =>
        Assert.That(
            () => _rope.Move("W 3").ToList(), 
            Throws.TypeOf<ArgumentException>());

    [Test]
    public void Move_GivenInstructionWithInvalidSteps_ThrowsInvalidArgumentException() =>
        Assert.That(
            () => _rope.Move("U").ToList(), 
            Throws.TypeOf<ArgumentException>());
    
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

        var moveResults = _rope.Move($"U {steps}").ToList();

        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
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

        var moveResults = _rope.Move($"D {steps}").ToList();

        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
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

        var moveResults = _rope.Move($"L {steps}").ToList();

        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
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

        var moveResults = _rope.Move($"R {steps}").ToList();

        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }

    [Test]
    public void Move_GivenDiagonalMovementToRightThenUp_MovesCorrectly()
    {
        var _ = _rope.Move("R 4").ToList();
        var moveResults = _rope.Move("U 2").ToList();

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
        
        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementLeftThenUp_MovesCorrectly()
    {
        var _ = _rope.Move("L 4").ToList();
        var moveResults = _rope.Move("U 2").ToList();

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
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementLeftThenDown_MovesCorrectly()
    {
        var _ = _rope.Move("L 4").ToList();
        var moveResults = _rope.Move("D 2").ToList();

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
        
        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementRightThenDown_MovesCorrectly()
    {
        var _ = _rope.Move("R 4").ToList();
        var moveResults = _rope.Move("D 2").ToList();

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
        
        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementDownThenLeft_MovesCorrectly()
    {
        var _ = _rope.Move("D 2").ToList();
        var moveResults = _rope.Move("L 4").ToList();

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
        
        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementDownThenRight_MovesCorrectly()
    {
        var _ = _rope.Move("D 2").ToList();
        var moveResults = _rope.Move("R 4").ToList();

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
        
        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementUpThenRight_MovesCorrectly()
    {
        var _ = _rope.Move("U 2").ToList();
        var moveResults = _rope.Move("R 4").ToList();

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
        
        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
    
    [Test]
    public void Move_GivenDiagonalMovementUpThenLeft_MovesCorrectly()
    {
        var _ = _rope.Move("U 2").ToList();
        var moveResults = _rope.Move("L 4").ToList();

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
        
        Assert.Multiple(() =>
        {
            Assert.That(moveResults.Last().HeadPosition, Is.EqualTo(expectedHeadPosition));
            Assert.That(moveResults.Last().TailPosition, Is.EqualTo(expectedTailPosition));
        });
    }
}