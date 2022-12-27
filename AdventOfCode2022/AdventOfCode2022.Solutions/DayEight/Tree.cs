namespace AdventOfCode2022.Solutions.DayEight;

public class Tree
{
    public uint Height { get; }
    public int Row { get; }
    public int Column { get; }

    public Tree(uint height, int row, int column)
    {
        Height = height;
        Row = row;
        Column = column;
    }

    public override string ToString() => Height.ToString();
}
