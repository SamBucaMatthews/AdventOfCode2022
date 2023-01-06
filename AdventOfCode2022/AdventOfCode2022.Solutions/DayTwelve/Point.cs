namespace AdventOfCode2022.Solutions.DayTwelve;

public record Point(int Row, int Column, int Height)
{
    public IEnumerable<Tuple<Point, Point>> GetEdges(List<Point> points)
    {
        var above = points.Find(p => p.Row == Row - 1 && p.Column == Column);
        var below = points.Find(p => p.Row == Row + 1 && p.Column == Column);
        var left = points.Find(p => p.Row == Row && p.Column == Column + 1);
        var right = points.Find(p => p.Row == Row && p.Column == Column - 1);

        var potentialNeighbours = new List<Point?> { above, below, left, right };

        var validNeighbours = potentialNeighbours.Where(p => p != null && Height + 1 >= p.Height);

        return validNeighbours.Select(n => Tuple.Create(this, n)).ToList()!;
    }

    public override string ToString() => $"Row: {Row}, Column:{Column}, Height: {Height}";
}
