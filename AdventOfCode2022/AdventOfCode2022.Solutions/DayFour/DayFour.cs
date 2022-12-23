namespace AdventOfCode2022.Solutions.DayFour;

/// <summary>
/// https://adventofcode.com/2022/day/4
/// </summary>
public static class DayFour
{
    /// <summary>
    /// Counts the number of assignments that overlap.
    /// </summary>
    /// <param name="assignmentStrings">The string format of the assignments.</param>
    /// <param name="fullyOverlapping">Whether the assignments should fully overlap.</param>
    /// <returns>The number of overlapping assignments.</returns>
    public static int CountOverlappingAssignmentPairs(IEnumerable<string> assignmentStrings, bool fullyOverlapping) =>
        assignmentStrings
            .Select(s => new AssignmentPair(s))
            .Count(p => p.Overlaps(fullyOverlapping));
}