namespace AdventOfCode2022.Solutions.DayNine;

public class Rope
{
    private const string Up = "U";
    private const string Down = "D";
    private const string Left = "L";
    private const string Right = "R";

    private Coordinate HeadPosition { get; } = new();

    private Coordinate TailPosition { get; } = new();

    public IEnumerable<(Coordinate HeadPosition, Coordinate TailPosition)> Move(string instruction)
    {
        var instructionParts = instruction.Split(" ");

        if (instructionParts.Length != 2 ||
            !int.TryParse(instructionParts[1], out var steps))
        {
            throw new ArgumentException("Invalid instruction", nameof(instruction));
        }

        switch (instructionParts[0])
        {
            case Up:
                for (var i = 0; i < steps; i++)
                {
                    HeadPosition.Y--;
                    UpdateTailPosition(Up);
                    yield return (HeadPosition, TailPosition);
                }

                break;

            case Down:
                for (var i = 0; i < steps; i++)
                {
                    HeadPosition.Y++;
                    UpdateTailPosition(Down);
                    yield return (HeadPosition, TailPosition);
                }

                break;
            
            case Left:
                for (var i = 0; i < steps; i++)
                {
                    HeadPosition.X--;
                    UpdateTailPosition(Left);
                    yield return (HeadPosition, TailPosition);
                }

                break;

            case Right:
                for (var i = 0; i < steps; i++)
                {
                    HeadPosition.X++;
                    UpdateTailPosition(Right);
                    yield return (HeadPosition, TailPosition);
                }

                break;

            default:
                throw new ArgumentException("Invalid instruction", nameof(instruction));
        }
    }

    private void UpdateTailPosition(string headDirection)
    {
        if (HeadAndTailAreInContact())
        {
            return;
        }

        switch (headDirection)
        {
            case Up:
                TailPosition.X = HeadPosition.X;
                TailPosition.Y = HeadPosition.Y + 1;

                break;
            case Down:
                TailPosition.X = HeadPosition.X;
                TailPosition.Y = HeadPosition.Y - 1;

                break;
            case Left:
                TailPosition.X = HeadPosition.X + 1;
                TailPosition.Y = HeadPosition.Y;

                break;
            case Right:
                TailPosition.X = HeadPosition.X - 1;
                TailPosition.Y = HeadPosition.Y;

                break;
        }
    }

    private bool HeadAndTailAreInContact()
    {
        if (HeadPosition.Equals(TailPosition))
        {
            return true;
        }
        
        // Tail to left of head
        if (HeadPosition.X - TailPosition.X == 1 && HeadPosition.Y == TailPosition.Y)
        {
            return true;
        }
        
        // Tail to right of head
        if (HeadPosition.X - TailPosition.X == -1 && HeadPosition.Y == TailPosition.Y)
        {
            return true;
        }
        
        // Tail above head
        if (HeadPosition.Y - TailPosition.Y == 1 && HeadPosition.X == TailPosition.X)
        {
            return true;
        }
        
        // Tail below head
        if (HeadPosition.Y - TailPosition.Y == -1 && HeadPosition.X == TailPosition.X)
        {
            return true;
        }
        
        // Tail upper left diagonal
        if (HeadPosition.Y - TailPosition.Y == 1 && HeadPosition.X - TailPosition.X == 1)
        {
            return true;
        }
        
        // Tail upper right diagonal
        if (HeadPosition.Y - TailPosition.Y == -1 && HeadPosition.X - TailPosition.X == -1)
        {
            return true;
        }

        // Tail lower left diagonal
        if (HeadPosition.Y - TailPosition.Y == -1 && HeadPosition.X - TailPosition.X == 1)
        {
            return true;
        }

        // Tail lower right diagonal
        return HeadPosition.Y - TailPosition.Y == 1 && HeadPosition.X - TailPosition.X == -1;
    }
}