namespace AdventOfCode2022.Solutions.DaySeven.Composite;

using System.Collections;

public abstract class FileSystemItem : IEnumerable
{
    public string Name { get; }

    public FileSystemItem? Parent { get; private set; }

    protected FileSystemItem(string name)
    {
        Name = name;
    }

    public abstract int GetSize();

    public abstract IEnumerator GetEnumerator();

    public abstract bool IsComposite();

    public void SetParent(FileSystemItem? parent)
    {
        Parent = parent;
    }
}
