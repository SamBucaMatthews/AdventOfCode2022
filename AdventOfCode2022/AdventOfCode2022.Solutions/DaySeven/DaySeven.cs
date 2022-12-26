namespace AdventOfCode2022.Solutions.DaySeven;

using AdventOfCode2022.Solutions.DaySeven.Composite;

public static class DaySeven
{
    public static int FindSumOfTotalMatchingDirectories(IEnumerable<string> input)
    {
        const int maximumSize = 100000;
        var fileSystemBuilder = FileSystemBuilder.BuildFromInput(input);

        var allDirectorySizes = fileSystemBuilder.GetAllDirectorySizes();

        return allDirectorySizes
            .Where(d => d.directorySize < maximumSize)
            .Sum(d => d.directorySize);
    }
}
