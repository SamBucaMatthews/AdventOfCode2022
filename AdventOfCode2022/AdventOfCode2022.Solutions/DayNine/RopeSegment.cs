namespace AdventOfCode2022.Solutions.DayNine;

public class RopeSegment
{
    /// <summary>
    /// Gets the next <see cref="RopeSegment"/> in the chain (i.e. closer to the tail), or null if this is the tail.
    /// </summary>
    public RopeSegment? NextSegment { get; private set; }

    /// <summary>
    /// Gets the position of this <see cref="RopeSegment"/>.
    /// </summary>
    public Coordinate Position { get; } = new();
    
    /// <summary>
    /// Appends a <see cref="RopeSegment"/> to the end of this one.
    /// </summary>
    /// <param name="nextSegment">The <see cref="RopeSegment"/> to append.</param>
    public void Append(RopeSegment nextSegment)
        => NextSegment = nextSegment;

    /// <summary>
    /// Gets a list of <see cref="Coordinate"/>s that indicate where this <see cref="RopeSegment"/> has previously been.
    /// </summary>
    public List<Coordinate> PreviousPositions { get; } = new();

    /// <summary>
    /// Moves the <see cref="RopeSegment"/>.
    /// </summary>
    /// <param name="direction">The <see cref="MovementDirection"/> to move.</param>
    /// <param name="steps">The number of steps to move.</param>
    /// <param name="recordPreviousPosition">Whether the movement should be recorded (false if diagonal)</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if an invalid <see cref="MovementDirection"/> is provided.</exception>
    public void Move(MovementDirection direction, int steps, bool recordPreviousPosition = true)
    {
        Func<int> movement = direction switch
        {
            MovementDirection.Up => () => Position.Y--,
            MovementDirection.Down => () => Position.Y++,
            MovementDirection.Left => () => Position.X--,
            MovementDirection.Right => () => Position.X++,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

        for (var i = 0; i < steps; i++)
        {
            if (recordPreviousPosition)
            {
                PreviousPositions.Add(new Coordinate
                {
                    X = Position.X,
                    Y = Position.Y
                });                
            }

            movement();

            if (NextSegment == null || IsInContactWithNext())
            {
                continue;
            }

            var distanceFromThisToNextY = Position.Y - NextSegment.Position.Y;
            var distanceFromThisToNextX = Position.X - NextSegment.Position.X;

            if (distanceFromThisToNextY == -2 &&
                distanceFromThisToNextX == 1 &&
                direction == MovementDirection.Up)
            {
                NextSegment.Move(MovementDirection.Right, 1);
                NextSegment.Move(MovementDirection.Up, 1, false);
            }
            else if (distanceFromThisToNextY == -1 &&
                     distanceFromThisToNextX == 2 &&
                     direction == MovementDirection.Right)
            {
                NextSegment.Move(MovementDirection.Right, 1);
                NextSegment.Move(MovementDirection.Up, 1);
            }
            else if (distanceFromThisToNextY == -1 &&
                     distanceFromThisToNextX == -2 &&
                     direction == MovementDirection.Left)
            {
                NextSegment.Move(MovementDirection.Left, 1);
                NextSegment.Move(MovementDirection.Up, 1);
            }
            else if (distanceFromThisToNextY == -2 &&
                     distanceFromThisToNextX == -1 &&
                     direction == MovementDirection.Up)
            {
                NextSegment.Move(MovementDirection.Left, 1);
                NextSegment.Move(MovementDirection.Up, 1);
            }
            else if (distanceFromThisToNextY == 1 &&
                     distanceFromThisToNextX == -2 &&
                     direction == MovementDirection.Left)
            {
                NextSegment.Move(MovementDirection.Left, 1);
                NextSegment.Move(MovementDirection.Down, 1);
            }
            else if (distanceFromThisToNextY == 2 &&
                     distanceFromThisToNextX == -1 &&
                     direction == MovementDirection.Down)
            {
                NextSegment.Move(MovementDirection.Left, 1);
                NextSegment.Move(MovementDirection.Down, 1, false);
            }
            else if (distanceFromThisToNextY == 1 &&
                     distanceFromThisToNextX == 2 &&
                     direction == MovementDirection.Right)
            {
                NextSegment.Move(MovementDirection.Right, 1);
                NextSegment.Move(MovementDirection.Down, 1);
            }
            else if (distanceFromThisToNextY == 2 &&
                     distanceFromThisToNextX == 1 &&
                     direction == MovementDirection.Down)
            {
                NextSegment.Move(MovementDirection.Right, 1);
                NextSegment.Move(MovementDirection.Down, 1, false);
            }
            else
            {
                NextSegment.Move(direction, 1);
            }
        }
    }

    private bool IsInContactWithNext() =>
        NextIsSamePositionAsThis() ||
        NextIsToLeftOfThis() ||
        NextIsToRightOfThis() ||
        NextIsAboveThis() ||
        NextIsBelowThis() ||
        NextIsToUpperLeftOfThis() ||
        NextIsToUpperRightOfThis() ||
        NextIsToLowerLeftOfThis() ||
        NextIsToLowerRightOfThis();

    private bool NextIsToLowerRightOfThis() =>
        Position.Y - NextSegment?.Position.Y == 1 && Position.X - NextSegment?.Position.X == -1;

    private bool NextIsToLowerLeftOfThis() =>
        Position.Y - NextSegment?.Position.Y == -1 && Position.X - NextSegment?.Position.X == 1;

    private bool NextIsToUpperRightOfThis() =>
        Position.Y - NextSegment?.Position.Y == -1 && Position.X - NextSegment?.Position.X == -1;

    private bool NextIsToUpperLeftOfThis() =>
        Position.Y - NextSegment?.Position.Y == 1 && Position.X - NextSegment?.Position.X == 1;

    private bool NextIsBelowThis() =>
        Position.Y - NextSegment?.Position.Y == -1 && Position.X == NextSegment?.Position.X;

    private bool NextIsAboveThis() =>
        Position.Y - NextSegment?.Position.Y == 1 && Position.X == NextSegment?.Position.X;

    private bool NextIsToRightOfThis() =>
        Position.X - NextSegment?.Position.X == -1 && Position.Y == NextSegment?.Position.Y;

    private bool NextIsToLeftOfThis() =>
        Position.X - NextSegment?.Position.X == 1 && Position.Y == NextSegment?.Position.Y;

    private bool NextIsSamePositionAsThis() => Position.Equals(NextSegment?.Position);
}