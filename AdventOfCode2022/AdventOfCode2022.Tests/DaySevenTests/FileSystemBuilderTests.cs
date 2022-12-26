namespace AdventOfCode2022.Tests.DaySevenTests;

using AdventOfCode2022.Solutions.DaySeven.Composite;

public class FileSystemBuilderTests
{
    [Test]
    public void GetSize_GivenBuildFromInputWithOnlyTopLevelFiles_ReturnsCorrectSize()
    {
        const int fileSize1 = 14848514;
        const int fileSize2 = 8504156;

        var input = new List<string>
        {
            "$ cd /",
            "$ ls",
            $"{fileSize1} b.txt",
            $"{fileSize2} c.dat",
        };

        var fileSystemBuilder = FileSystemBuilder.BuildFromInput(input);

        var directorySizes = fileSystemBuilder.GetAllDirectorySizes();

        Assert.Multiple(() =>
        {
            Assert.That(directorySizes[0].directoryName, Is.EqualTo("/"));
            Assert.That(directorySizes[0].directorySize, Is.EqualTo(fileSize1 + fileSize2));
            Assert.That(directorySizes, Has.One.Items);
        });
    }
    
    [Test]
    public void GetSize_GivenBuildFromInputWithTwoLevels_ReturnsCorrectSize()
    {
        const int rootFileSize1 = 14848514;
        const int rootFileSize2 = 8504156;
        const int dirAFileSize1 = 29116;

        var input = new List<string>
        {
            "$ cd /",
            "$ ls",
            "dir a",
            $"{rootFileSize1} b.txt",
            $"{rootFileSize2} c.dat",
            "$ cd a",
            "$ ls",
            $"{dirAFileSize1} f",
        };

        var fileSystemBuilder = FileSystemBuilder.BuildFromInput(input);

        var directorySizes = fileSystemBuilder.GetAllDirectorySizes();

        (string directoryName, int directorySize) expectedRoot = new("/",
            rootFileSize1 + rootFileSize2 + dirAFileSize1);

        (string directoryName, int directorySize) expectedA = new("a", dirAFileSize1);

        Assert.That(directorySizes, Has.Count.EqualTo(2));

        Assert.Multiple(() =>
        {
            Assert.That(directorySizes[0], Is.EqualTo(expectedRoot));
            Assert.That(directorySizes[1], Is.EqualTo(expectedA));
        });
    }
    
    [Test]
    public void GetSize_GivenBuildFromInputWithThreeLevels_ReturnsCorrectSize()
    {
        const int rootFileSize1 = 14848514;
        const int rootFileSize2 = 8504156;
        const int dirAFileSize1 = 29116;
        const int dirBFileSize1 = 23434;

        var input = new List<string>
        {
            "$ cd /",
            "$ ls",
            "dir a",
            $"{rootFileSize1} b.txt",
            $"{rootFileSize2} c.dat",
            "$ cd a",
            "$ ls",
            $"{dirAFileSize1} f",
            "dir b",
            "$ cd b",
            "$ ls",
            $"{dirBFileSize1} w.txt",
        };

        var fileSystemBuilder = FileSystemBuilder.BuildFromInput(input);

        var directorySizes = fileSystemBuilder.GetAllDirectorySizes();

        (string directoryName, int directorySize) expectedRoot = new("/",
            rootFileSize1 + rootFileSize2 + dirAFileSize1 + dirBFileSize1);

        (string directoryName, int directorySize) expectedA = new("a", dirAFileSize1 + dirBFileSize1);
        (string directoryName, int directorySize) expectedB = new("b", dirBFileSize1);

        Assert.That(directorySizes, Has.Count.EqualTo(3));

        Assert.Multiple(() =>
        {
            Assert.That(directorySizes[0], Is.EqualTo(expectedRoot));
            Assert.That(directorySizes[1], Is.EqualTo(expectedA));
            Assert.That(directorySizes[2], Is.EqualTo(expectedB));
        });
    }
}
