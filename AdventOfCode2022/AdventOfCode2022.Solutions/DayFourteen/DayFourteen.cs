namespace AdventOfCode2022.Solutions.DayFourteen;

public static class DayFourteen
{
    public static int CountUnitsOfSand(IEnumerable<string> input)
    {
        var cave = new Cave(input, new Point(500, 0));
        
        cave.RunUntilOverflow();

        return cave.SettledSand.Count;
    }
}
