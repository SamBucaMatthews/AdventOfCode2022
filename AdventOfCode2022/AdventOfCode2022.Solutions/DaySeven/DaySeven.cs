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

    public static int FindSizeOfDirectoryToDelete(IEnumerable<string> input)
    {
        const int totalFileSystemSpace = 70000000;
        const int spaceRequiredForUpdate = 30000000;

        var fileSystemBuilder = FileSystemBuilder.BuildFromInput(input);

        var allDirectorySizes = fileSystemBuilder.GetAllDirectorySizes();

        var rootSize = allDirectorySizes.First(d => d.directoryName =="/").directorySize;
        var totalUnused = totalFileSystemSpace - rootSize;
        var spaceRequiredToFreeUp = spaceRequiredForUpdate - totalUnused;

        return allDirectorySizes
            .Select(d => d.directorySize)
            .Where(s => s >= spaceRequiredToFreeUp)
            .MinBy(s => s);
    }
}
