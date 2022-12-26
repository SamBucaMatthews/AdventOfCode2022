namespace AdventOfCode2022.Solutions.DaySeven.Composite;

using System.Collections;

public class Directory : FileSystemItem
{
    public List<FileSystemItem> Items { get; } = new();

    public Directory(string name) : base(name)
    {
    }
    
    public void Add(FileSystemItem component)
    {
        component.SetParent(this);
        Items.Add(component);
    }

    public void Remove(FileSystemItem component)
    {
        component.SetParent(null);
        Items.Remove(component);
    }

    public override int GetSize() =>
        Items.Sum(i => i.GetSize());

    public override IEnumerator GetEnumerator()
    {
        yield return this;

        foreach (var fileSystemItem in Items)
        {
            foreach (var subfolder in fileSystemItem)
            {
                yield return subfolder;
            }
        }
    }

    public override bool IsComposite() => true;
}