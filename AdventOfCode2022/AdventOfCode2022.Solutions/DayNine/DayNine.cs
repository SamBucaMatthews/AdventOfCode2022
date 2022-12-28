namespace AdventOfCode2022.Solutions.DayNine;

public static class DayNine
{
    public static int CountPositionsVisitedByTail(IEnumerable<string> input)
    {
        var rope = new Rope();

        var pointsTouchedByTail = new List<Coordinate>();
        foreach (var instruction in input)
        {
            foreach (var (_, (x, y)) in rope.Move(instruction))
            {
                pointsTouchedByTail.Add(new Coordinate { X = x, Y = y } );
            }
        }

        return pointsTouchedByTail.Distinct().Count();
    }
}
