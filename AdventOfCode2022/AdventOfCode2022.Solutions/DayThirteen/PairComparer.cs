namespace AdventOfCode2022.Solutions.DayThirteen;

public static class PairComparer
{
    public static bool PairsInCorrectOrder(Tuple<List<object>, List<object>> pair)
    {
        if (pair.Item2.Count < pair.Item1.Count)
        {
            return false;
        }

        var zippedElements = pair.Item1.Zip(pair.Item2);

        foreach (var elementPair in zippedElements)
        {
            if (elementPair is { First: List<object> firstList, Second: List<object> secondList })
            {
                if (firstList.Zip(secondList).Any(e => !CompareInts((int)e.First, (int)e.Second)))
                {
                    return false;
                }
            }
            else if (elementPair is { First: int firstInt, Second: int secondInt })
            {
                if (!CompareInts(firstInt, secondInt))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static bool CompareInts(int first, int second) => second >= first;
}