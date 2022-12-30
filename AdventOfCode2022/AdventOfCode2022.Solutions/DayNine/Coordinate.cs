namespace AdventOfCode2022.Solutions.DayNine;

public record Coordinate(int X, int Y)
{
    public override string ToString() => $"({X}, {Y})";
}
