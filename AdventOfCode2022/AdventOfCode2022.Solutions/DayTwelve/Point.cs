namespace AdventOfCode2022.Solutions.DayTwelve;

public record Point(int Row, int Column, int Height)
{
    public IEnumerable<Point?> GetNeighbours(List<Point> points)
    {
        var above = points.Find(p => p.Row == Row - 1 && p.Column == Column);
        var below = points.Find(p => p.Row == Row + 1 && p.Column == Column);
        var left = points.Find(p => p.Row == Row && p.Column == Column - 1);
        var right = points.Find(p => p.Row == Row && p.Column == Column + 1);

        return new List<Point?> { above, below, left, right };
    }

    public override string ToString() => $"Row: {Row}, Column:{Column}, Height: {Height}";
}
