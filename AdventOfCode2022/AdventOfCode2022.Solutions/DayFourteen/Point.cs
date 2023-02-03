namespace AdventOfCode2022.Solutions.DayFourteen;

public record Point(int Column, int Row)
{
    public Point Down => this with { Row = Row + 1 };

    public Point DownAndLeft => new(Row: Row + 1, Column: Column -1);

    public Point DownAndRight => new(Row: Row + 1, Column: Column +1);

    public static Point Parse(string input)
    {
        var parts = input.Split(",");

        if (parts.Length != 2 || !int.TryParse(parts[0], out var column) ||!int.TryParse(parts[1], out var row))
        {
            throw new ArgumentException(input);
        }
        
        return new Point(column, row);
    }

    public override string ToString() => $" Column: {Column}. Row: {Row}.";
}
