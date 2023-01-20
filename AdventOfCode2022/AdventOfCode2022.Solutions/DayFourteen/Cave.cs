namespace AdventOfCode2022.Solutions.DayFourteen;

public class Cave
{
    private readonly Point _sandStartingPoint;

    public HashSet<Point> Rocks { get; }
    
    public Cave(IEnumerable<string> rows, Point sandStartingPoint)
    {
        Rocks = BuildRocks(rows);
        _sandStartingPoint = sandStartingPoint;
    }

    private static HashSet<Point> BuildRocks(IEnumerable<string> rows)
    {
        var rocks = new HashSet<Point>();
        foreach (var row in rows)
        {
            var points = row.Split(" -> ");
            var startPoint = Point.Parse(points[0]);

            for (var i = 1; i < points.Length; i++)
            {
                var endPoint = Point.Parse(points[i]);

                if (startPoint.Column == endPoint.Column || startPoint.Row != endPoint.Row)
                {
                    for (var j = Math.Min(startPoint.Row, endPoint.Row);
                         j <= Math.Max(startPoint.Row, endPoint.Row);
                         j++)
                    {
                        rocks.Add(startPoint with { Row = j });
                    }
                }
                else
                {
                    for (var j = Math.Min(startPoint.Column, endPoint.Column);
                         j <= Math.Max(startPoint.Column, endPoint.Column);
                         j++)
                    {
                        rocks.Add(startPoint with { Column = j });
                    }
                }

                startPoint = endPoint;
            }
        }

        return rocks;
    }
}
