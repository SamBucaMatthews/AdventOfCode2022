namespace AdventOfCode2022.Solutions.DayNine;

public static class DayNine
{
    public static int CountPositionsVisitedByTail(IEnumerable<string> input)
    {
        const string up = "U";
        const string down = "D";
        const string left = "L";
        const string right = "R";

        var head = new RopeSegment();
        var tail = new RopeSegment();

        head.Append(tail);

        foreach (var instruction in input)
        {
            var instructionParts = instruction.Split(" ");

            MovementDirection? movementDirection = instructionParts[0] switch
            {
                up => MovementDirection.Up,
                down => MovementDirection.Down,
                left => MovementDirection.Left,
                right => MovementDirection.Right,
                _ => throw new ArgumentOutOfRangeException(nameof(input))
            };

            if (instructionParts.Length != 2 ||
                !int.TryParse(instructionParts[1], out var steps))
            {
                throw new ArgumentException("Invalid instruction", nameof(input));
            }

            head.Move(movementDirection.Value, steps);
        }

        var lastSegment = head;
        while (lastSegment.NextSegment != null)
        {
            lastSegment = lastSegment.NextSegment;
        }

        return lastSegment.PreviousPositions.Append(lastSegment.Position).Distinct().Count();
    }
}
