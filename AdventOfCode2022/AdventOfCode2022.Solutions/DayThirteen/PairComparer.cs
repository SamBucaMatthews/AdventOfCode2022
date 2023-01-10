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
            if (elementPair is { First: int firstInt, Second: int secondInt })
            {
                if (!CompareInts(firstInt, secondInt))
                {
                    return false;
                }
            }
            else if (elementPair.First is List<object> || elementPair.Second is List<object>)
            {
                var firstList = elementPair.First as List<object> ?? new List<object> { elementPair.First };
                var secondList = elementPair.Second as List<object> ?? new List<object> { elementPair.Second };

                if (!PairsInCorrectOrder(Tuple.Create(firstList, secondList)))
                {
                    return false;
                }
            }
            else
            {
                // TODO: Remove this block (only here as the else if above is broken for PairsInCorrectOrder_GivenMixedListsInCorrectOrder_ReturnsTrue)
                return false;
            }
        }

        return true;
    }

    private static bool CompareInts(int first, int second) => second >= first;
}