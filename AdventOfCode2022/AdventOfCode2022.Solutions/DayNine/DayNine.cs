namespace AdventOfCode2022.Solutions.DayNine;

public static class DayNine
{
    public static int CountPositionsVisitedByTail(IEnumerable<string> input, int ropeSegments)
    {
        const string up = "U";
        const string down = "D";
        const string left = "L";
        const string right = "R";

        var head = new RopeSegment();

        var currentSegment = head;
        for (var i = 0; i < ropeSegments -1; i++)
        {
            var nextSegment = new RopeSegment();
            currentSegment.Append(nextSegment);
            currentSegment = nextSegment;
        }

        foreach (var instruction in input)
        {
            var instructionParts = instruction.Split(" ");

            var movement = instructionParts[0] switch
            {
                up => new Movement(0, -1),
                down => new Movement(0, 1),
                left => new Movement(-1,  0),
                right => new Movement(1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(input))
            };

            if (instructionParts.Length != 2 ||
                !int.TryParse(instructionParts[1], out var steps))
            {
                throw new ArgumentException("Invalid instruction", nameof(input));
            }

            for (var i = 0; i < steps; i++)
            {
                head.Move(movement);
            }
        }

        var positionsVisitedByTail = currentSegment.PreviousPositions
            .Append(currentSegment.Position)
            .Distinct();

        return positionsVisitedByTail.Count();
    }
}