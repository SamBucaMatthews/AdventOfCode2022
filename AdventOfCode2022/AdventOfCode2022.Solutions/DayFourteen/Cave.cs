namespace AdventOfCode2022.Solutions.DayFourteen;

public class Cave
{
    private readonly Point _sandStartingPoint;
    private readonly int? _floor;
    private readonly int _maxRow;

    private bool _canFitMoreSand = true;

    public HashSet<Point> Rocks { get; }

    public HashSet<Point> SettledSand { get; }
    
    public Cave(IEnumerable<string> rows, Point sandStartingPoint, bool hasFloor)
    {
        Rocks = BuildRocks(rows);
        _maxRow = Rocks.Max(r => r.Row);
        SettledSand = new HashSet<Point>();
        _sandStartingPoint = sandStartingPoint;
        _floor = hasFloor ? _maxRow + 2 : null;
    }
    
    public void ProduceSand()
    {
        var currentSandPosition = _sandStartingPoint with { };
        while (true)
        {
            Point nextPosition;
            if (CanMove(currentSandPosition.Down))
            {
                nextPosition = currentSandPosition.Down;
            }
            else if (CanMove(currentSandPosition.DownAndLeft))
            {
                nextPosition = currentSandPosition.DownAndLeft;
            }
            else if (CanMove(currentSandPosition.DownAndRight))
            {
                nextPosition = currentSandPosition.DownAndRight;
            }
            else
            {
                break;
            }

            if (!_floor.HasValue && currentSandPosition.Row == _maxRow)
            {
                _canFitMoreSand = false;
                return;
            }

            currentSandPosition = nextPosition;
        }
        
        SettledSand.Add(currentSandPosition);
        
        if (_floor.HasValue && currentSandPosition == _sandStartingPoint)
        {
            _canFitMoreSand = false;
        }
    }
    
    public void Run()
    {
        while (_canFitMoreSand)
        {
            ProduceSand();
        }
    }

    private bool CanMove(Point nextPosition)
    {
        if (_floor.HasValue && nextPosition.Row == _floor.Value)
        {
            return false;
        }
        
        return !Rocks.Contains(nextPosition) && !SettledSand.Contains(nextPosition);
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
