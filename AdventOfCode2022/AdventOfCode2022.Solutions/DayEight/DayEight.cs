namespace AdventOfCode2022.Solutions.DayEight;

using CommunityToolkit.HighPerformance;

public static class DayEight
{
    public static int CountVisibleTrees(string[] input)
    {
        var span2D = InputTo2DSpan(input);

        var visibleTrees = 0;
        foreach (var tree in span2D)
        {
            var treesInRowAndColumn = TreesInRowAndColumn(span2D, tree);

            var anyBlockingTreesAbove = treesInRowAndColumn.TreesAbove.Any(t => t.Height >= tree.Height);
            var anyBlockingTreesBelow = treesInRowAndColumn.TreesBelow.Any(t => t.Height >= tree.Height);
            var anyBlockingTreesToLeft = treesInRowAndColumn.TreesToLeft.Any(t => t.Height >= tree.Height);
            var anyBlockingTreesToRight = treesInRowAndColumn.TreesToRight.Any(t => t.Height >= tree.Height);

            var visibleFromAbove = !anyBlockingTreesAbove || tree.Column == 0;
            var visibleFromBelow = !anyBlockingTreesBelow || tree.Column == span2D.Height;
            var visibleFromLeft = !anyBlockingTreesToLeft || tree.Row == 0;
            var visibleFromRight = !anyBlockingTreesToRight || tree.Row == span2D.Width;

            if (visibleFromAbove || visibleFromBelow || visibleFromLeft || visibleFromRight)
            {
                visibleTrees++;
            }
        }

        return visibleTrees;
    }
    
    public static int GetMaxScenicScore(string[] input)
    {
        var span2D = InputTo2DSpan(input);

        var maxScenicScore = 0;
        foreach (var tree in span2D)
        {
            var treesInRowAndColumn = TreesInRowAndColumn(span2D, tree);

            var viewAboveScore = ViewScore(treesInRowAndColumn.TreesAbove, tree);
            var viewLeftScore = ViewScore(treesInRowAndColumn.TreesToLeft, tree);
            var viewRightScore = ViewScore(treesInRowAndColumn.TreesToRight, tree);
            var viewBelowScore = ViewScore(treesInRowAndColumn.TreesBelow, tree);
            
            var treeScenicScore = (viewAboveScore * viewLeftScore * viewRightScore * viewBelowScore);
            if (treeScenicScore > maxScenicScore)
            {
                maxScenicScore = treeScenicScore;
            }
        }

        return maxScenicScore;
    }

    private static int ViewScore(IEnumerable<Tree> potentiallyVisibleTrees, Tree tree)
    {
        var viewScore = 0;
        foreach (var potentiallyVisibleTree in potentiallyVisibleTrees)
        {
            viewScore++;
            if (potentiallyVisibleTree.Height >= tree.Height)
            {
                break;
            }
        }

        return viewScore;
    }

    private static TreesInRowAndColumn TreesInRowAndColumn(
        ReadOnlySpan2D<Tree> span2D, Tree tree)
    {
        var column = span2D.GetColumn(tree.Column).ToArray();
        var row = span2D.GetRow(tree.Row).ToArray();

        var columnSliceStart = tree.Row + 1;
        var rowSliceStart = tree.Column + 1;

        var treesAbove = column[..tree.Row].Reverse().ToArray();
        var treesBelow = column[columnSliceStart..];
        var treesToLeft = row[..tree.Column].Reverse().ToArray();
        var treesToRight = row[rowSliceStart..];

        return new TreesInRowAndColumn(treesAbove, treesBelow, treesToLeft, treesToRight);
    }

    private static ReadOnlySpan2D<Tree> InputTo2DSpan(string[] input)
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

        return new ReadOnlySpan2D<Tree>(array);
    }
}
