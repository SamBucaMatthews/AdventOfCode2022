namespace AdventOfCode2022.Solutions.DayThirteen;

using System.Collections;

public class BubbleSorter
{
    private readonly IComparer _comparer;

    public BubbleSorter(IComparer comparer)
    {
        _comparer = comparer;
    }

    public void Sort(List<List<object>> input)
    {
        var size = input.Count;

        for (var i = 0; i < size - 1; i++)
        {
            for (var j = 0; j < size - i - 1; j++)
            {
                if (_comparer.Compare(input[j], input[j + 1]) == -1)
                {
                    (input[j], input[j + 1]) = (input[j + 1], input[j]);
                }
            }
        }
    }
}
