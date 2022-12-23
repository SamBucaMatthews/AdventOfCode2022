namespace AdventOfCode2022.Solutions.DayFour;

public static class DayFour
{
    public static int CountFullyOverlappingAssignmentPairs(IEnumerable<string> assignmentStrings) =>
        assignmentStrings
            .Select(s => new AssignmentPair(s))
            .Count(p => p.FullyOverlaps());
}