using System.Collections;

namespace AdventOfCode2022.Solutions.DayThirteen;

public static class PairComparer
{
    /* To avoid rewriting unit tests! */
    public static bool PairsInCorrectOrder(Tuple<List<object>, List<object>> parsedPair)
    {
        var tuple = Tuple.Create<object?, object?>(parsedPair.Item1, parsedPair.Item2);
        return PairsInCorrectOrder(tuple);
    }

    private static bool PairsInCorrectOrder(Tuple<object?, object?> pair)
    {
        while (true)
        {
            var (item1, item2) = pair;

            var list1 = ToList(item1);
            var list2 = ToList(item2);

            var longerList = list1.Count >= list2.Count ? list1 : list2;
            var shorterList = list1.Count < list2.Count ? list1 : list2;

            var countToAdd = longerList.Count - shorterList.Count;
            var fillerElements = Enumerable.Repeat<object?>(null, countToAdd);

            shorterList.AddRange(fillerElements);

            for (var i = 0; i < list2.Count; i++)
            {
                if (list1[i] is int int1 && list2[i] is int int2)
                {
                    if (int1 == int2)
                    {
                        continue;
                    }

                    return int2 >= int1;
                }

                if (list1[i] is not null && list2[i] is null)
                {
                    return false;
                }

                if (list1[i] is null && list2[i] is not null)
                {
                    return true;
                }

                return PairsInCorrectOrder(Tuple.Create(list1[i], list2[i]));
            }

            return true;
        }
    }

    private static List<object?> ToList(object? item) =>
        !IsList(item)
            ? new List<object?>
            {
                item
            }
            : ((IList)item!).Cast<object?>()
            .ToList();

    private static bool IsList(object? o) =>
        o is IList &&
        o.GetType().IsGenericType &&
        o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
}
