namespace AdventOfCode2022.Solutions.DayFour;

public class AssignmentPair
{
    private Assignment ElfOne { get; }

    private Assignment ElfTwo { get; }
    
    public AssignmentPair(string assignmentPairString)
    {
        var assignmentStrings = assignmentPairString.Split(",");

        if (assignmentStrings.Length != 2)
        {
            throw new ArgumentException();
        }
        
        ElfOne = new Assignment(assignmentStrings[0]);
        ElfTwo = new Assignment(assignmentStrings[1]);
    }

    public bool Overlaps(bool fullyOverlaps) =>
        fullyOverlaps
            ? ElfOne.Sections.All(s => ElfTwo.Sections.Contains(s)) ||
              ElfTwo.Sections.All(s => ElfOne.Sections.Contains(s))
            : ElfOne.Sections.Any(s => ElfTwo.Sections.Contains(s)) ||
              ElfTwo.Sections.Any(s => ElfOne.Sections.Contains(s));
}
