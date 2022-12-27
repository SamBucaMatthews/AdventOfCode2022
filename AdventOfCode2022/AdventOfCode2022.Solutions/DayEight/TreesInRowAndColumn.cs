namespace AdventOfCode2022.Solutions.DayEight;

public class TreesInRowAndColumn
{
    public Tree[] TreesAbove { get; }
    public Tree[] TreesBelow { get; }
    public Tree[] TreesToLeft { get; }
    public Tree[] TreesToRight { get; }

    public TreesInRowAndColumn(
        Tree[] treesAbove,
        Tree[] treesBelow,
        Tree[] treesToLeft,
        Tree[] treesToRight)
    {
        TreesAbove = treesAbove;
        TreesBelow = treesBelow;
        TreesToLeft = treesToLeft;
        TreesToRight = treesToRight;
    }
}
