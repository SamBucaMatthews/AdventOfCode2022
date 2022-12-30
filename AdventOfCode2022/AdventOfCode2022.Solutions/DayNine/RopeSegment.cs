namespace AdventOfCode2022.Solutions.DayNine;

public class RopeSegment
{
    private RopeSegment? _nextSegment;

    /// <summary>
    /// Gets the position of this <see cref="RopeSegment"/>.
    /// </summary>
    public Coordinate Position { get; private set; } = new(0, 0);
    
    /// <summary>
    /// Appends a <see cref="RopeSegment"/> to the end of this one.
    /// </summary>
    /// <param name="nextSegment">The <see cref="RopeSegment"/> to append.</param>
    public void Append(RopeSegment nextSegment)
        => _nextSegment = nextSegment;

    /// <summary>
    /// Gets a list of <see cref="Coordinate"/>s that indicate where this <see cref="RopeSegment"/> has previously been.
    /// </summary>
    public List<Coordinate> PreviousPositions { get; } = new();

    /// <summary>
    /// Moves the <see cref="RopeSegment"/>.
    /// </summary>
    public void Move(Movement movement)
    {
        PreviousPositions.Add(Position);

        Position = new Coordinate(Position.X + movement.X, Position.Y + movement.Y);

        if (_nextSegment is null)
        {
            return;
        }
        
        var distanceFromThisToNextX = Position.X - _nextSegment.Position.X;
        var distanceFromThisToNextY = Position.Y - _nextSegment.Position.Y;

        if (Math.Abs(distanceFromThisToNextX) <= 1 && Math.Abs(distanceFromThisToNextY) <= 1)
        {
            return;
        }

        var nextSegmentMovement = new Movement(
            Math.Sign(distanceFromThisToNextX),
            Math.Sign(distanceFromThisToNextY));

        _nextSegment.Move(nextSegmentMovement);
    }
}
