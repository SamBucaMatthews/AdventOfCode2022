namespace AdventOfCode2022.Solutions.DayFourteen;

public static class DayFourteen
{
    public static int CountUnitsOfSand(IEnumerable<string> input, bool hasFloor)
    {
        var cave = new Cave(input, new Point(500, 0), hasFloor);
        
        cave.Run();

        return cave.SettledSand.Count;
    }
}
