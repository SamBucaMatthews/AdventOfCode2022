namespace AdventOfCode2022.Solutions.DayThirteen;

public static class DayThirteen
{
    public static int SumIndicesOfCorrectlyOrderedPairs(string[] input)
    {
        var comparer = new PairComparer();
        var parsedPairs = PacketPairParser.ParsePairs(input);
        var correctlyOrderedPairs = new List<int>();

        for (var i = 0; i < parsedPairs.Count; i++)
        {
            var pair = parsedPairs[i];
            if (comparer.Compare(pair.Item1, pair.Item2) == 1)
            {
                correctlyOrderedPairs.Add(i + 1);
            }
        }

        return correctlyOrderedPairs.Sum();
    }

    public static int GetDecoderKey(IEnumerable<string> input)
    {
        var divider1 = new List<object> { new List<object> { 2 } };
        var divider2 = new List<object> { new List<object> { 6 } };

        var lists = input
            .Where(i => !string.IsNullOrWhiteSpace(i))
            .Select(PacketPairParser.Parse)
            .Append(divider1)
            .Append(divider2)
            .ToList();

        var sorter = new BubbleSorter(new PairComparer());
        
        sorter.Sort(lists);

        var indexOfDivider1 = lists.IndexOf(divider1) + 1;
        var indexOfDivider2 = lists.IndexOf(divider2) + 1;

        return indexOfDivider1 * indexOfDivider2;
    }
}
