namespace AdventOfCode2022.Solutions.DaySeven.Composite;

using System.Collections;

public class File : FileSystemItem
{
    private readonly int _size;

    public File(string name, int size) : base(name)
        => _size = size;

    public override int GetSize() => _size;

    public override IEnumerator GetEnumerator()
    {
        yield return this;
    }

    public override bool IsComposite() => false;
}
