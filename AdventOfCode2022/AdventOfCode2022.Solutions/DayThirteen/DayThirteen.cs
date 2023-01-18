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
}
