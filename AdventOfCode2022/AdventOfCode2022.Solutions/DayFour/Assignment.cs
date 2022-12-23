namespace AdventOfCode2022.Solutions.DayFour;

public class Assignment
{
    public int[] Sections { get; }

    public Assignment(string assignmentString)
    {
        var startEndStrings = assignmentString.Split("-");

        if (
            !int.TryParse(startEndStrings[0], out var start) ||
            !int.TryParse(startEndStrings[1], out var end))
        {
            throw new ArgumentException();
        }

        Sections = Enumerable.Range(start, end - start + 1).ToArray();
    }
}
