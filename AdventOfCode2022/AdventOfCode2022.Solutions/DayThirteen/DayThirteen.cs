namespace AdventOfCode2022.Solutions.DayThirteen;

public static class DayThirteen
{
    public static int SumIndicesOfCorrectlyOrderedPairs(string[] input)
    {
        var parsedPairs = PacketPairParser.ParsePairs(input);
        var correctlyOrderedPairs = new List<int>();

        for (var i = 0; i < parsedPairs.Count; i++)
        {
            if (PairComparer.PairsInCorrectOrder(parsedPairs[i]))
            {
                correctlyOrderedPairs.Add(i + 1);
            }
        }

        return correctlyOrderedPairs.Sum();
    }
}
