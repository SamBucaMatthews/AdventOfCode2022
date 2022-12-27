namespace AdventOfCode2022.Solutions.DayEight;

using CommunityToolkit.HighPerformance;

public class DayEight
{
    private readonly Tree[,] _array;

    public DayEight(string[] input)
        => _array = InputTo2DArray(input);
    
    public int CountVisibleTrees()
    {
        var span2D = new ReadOnlySpan2D<Tree>(_array);

        var visibleTrees = 0;
        foreach (var tree in span2D)
        {
            var column = span2D.GetColumn(tree.Column).ToArray();
            var row = span2D.GetRow(tree.Row).ToArray();

            var columnIndex = column.ToList().IndexOf(tree);
            var rowIndex = row.ToList().IndexOf(tree);

            var columnSliceStart = columnIndex + 1;
            var rowSliceStart = rowIndex + 1;

            var anyBlockingTreesAbove = column[..columnIndex].Any(t => t.Height >= tree.Height);
            var anyBlockingTreesBelow = column[columnSliceStart..].Any(t => t.Height >= tree.Height);
            var anyBlockingTreesToLeft = row[..rowIndex].Any(t => t.Height >= tree.Height);
            var anyBlockingTreesToRight = row[rowSliceStart..].Any(t => t.Height >= tree.Height);

            var visibleFromAbove = !anyBlockingTreesAbove || columnIndex == 0;
            var visibleFromBelow = !anyBlockingTreesBelow || columnIndex == span2D.Height;
            var visibleFromLeft = !anyBlockingTreesToLeft || rowIndex == 0;
            var visibleFromRight = !anyBlockingTreesToRight || rowIndex == span2D.Width;

            if (visibleFromAbove || visibleFromBelow || visibleFromLeft || visibleFromRight)
            {
                visibleTrees++;
            }
        }

        return visibleTrees;
    }

    private static Tree[,] InputTo2DArray(string[] input)
    {
        var rowLengths = input[0].Length;
        var array = new Tree[rowLengths, input.Length];

        for (var row = 0; row < input.Length; row++)
        {
            var rowString = input[row];

            for (var column = 0; column < rowString.Length; column++)
            {
                if (!uint.TryParse(rowString[column].ToString(), out var number))
                {
                    throw new ArgumentException("Argument included an invalid uint", nameof(input));
                }

                array[row, column] = new Tree(number, row, column);
            }
        }

        return array;
    }
}

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
