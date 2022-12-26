namespace AdventOfCode2022.Solutions.DaySeven.Composite;

public class FileSystemBuilder
{
    private readonly Directory _root;

    private FileSystemBuilder(string rootDirectory)
    {
        _root = new Directory(rootDirectory);
        CurrentDirectory = _root;
    }

    private Directory CurrentDirectory { get; set; }
    
    public static FileSystemBuilder BuildFromInput(IEnumerable<string> input)
    {
        var fileSystemBuilder = new FileSystemBuilder("/");
        foreach (var line in input.Skip(1))
        {
            var parts = line.Split(" ");

            if (parts[0] == "$")
            {
                if (parts[1] == "cd")
                {
                    fileSystemBuilder.SetCurrentDirectory(parts[2]);
                }

                continue;
            }

            if (parts[0] =="dir")
            {
                fileSystemBuilder.AddDirectory(parts[1]);
                continue;
            }

            fileSystemBuilder.AddFile(parts[1], int.Parse(parts[0]));
        }

        return fileSystemBuilder;
    }

    public List<(string directoryName, int directorySize)> GetAllDirectorySizes()
    {
        var directoriesWithSizes = new List<(string directoryName, int directorySize)>();

        foreach (FileSystemItem item in _root)
        {
            if (item.IsComposite())
            {
                directoriesWithSizes.Add((item.Name, item.GetSize()));
            }
        }

        return directoriesWithSizes;
    }

    private void SetCurrentDirectory(string directoryName)
    {
        if (directoryName == "..")
        {
            CurrentDirectory = CurrentDirectory.Parent as Directory ?? throw new InvalidOperationException();
            return;
        }
        
        CurrentDirectory = CurrentDirectory.Items
                               .First(i => i.Name == directoryName) as Directory ??
                           throw new InvalidOperationException();
    }

    private Directory AddDirectory(string name)
    {
        var dir = new Directory(name);
        CurrentDirectory.Add(dir);
        return dir;
    }

    private File AddFile(string name, int size)
    {
        var file = new File(name, size);
        CurrentDirectory.Add(file);
        return file;
    }
}
