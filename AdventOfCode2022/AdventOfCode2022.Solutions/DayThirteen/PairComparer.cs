using System.Collections;

namespace AdventOfCode2022.Solutions.DayThirteen;

public static class PairComparer
{
    public static bool PairsInCorrectOrder(Tuple<List<object>, List<object>> parsedPair)
    {
        var tuple = Tuple.Create<object, object>(parsedPair.Item1, parsedPair.Item2);
        return PairsInCorrectOrder(tuple);
    }

    private static bool PairsInCorrectOrder(Tuple<object, object> pair)
    {
        while (true)
        {
            if (pair is { Item1: int firstInt, Item2: int secondInt })
            {
                return CompareInts(firstInt, secondInt);
            }

            if (IsList(pair.Item1) && !IsList(pair.Item2))
            {
                pair = Tuple.Create(pair.Item1, (object)new List<object> { pair.Item2 });
                continue;
            }

            if (!IsList(pair.Item1) && IsList(pair.Item2))
            {
                pair = Tuple.Create((object)new List<object> { pair.Item1 }, pair.Item2);
                continue;
            }

            if (IsList(pair.Item1) || IsList(pair.Item2))
            {
                var list1 = ((IList)pair.Item1).Cast<object?>().ToList();
                var list2 = ((IList)pair.Item2).Cast<object?>().ToList();

                if (list1.Count < list2.Count)
                {
                    var countToAdd = list2.Count - list1.Count;
                    list1.AddRange(Enumerable.Repeat<object>(null!, countToAdd));
                }
                else if (list2.Count < list1.Count)
                {
                    var countToAdd = list1.Count - list2.Count;
                    list2.AddRange(Enumerable.Repeat<object>(null!, countToAdd));
                }

                for (var i = 0; i < list2.Count; i++)
                {
                    if (list1[i] is not null && list1[i]!.Equals(list2[i]))
                    {
                        continue;
                    }

                    if (list2[i] is null && list1[i] is not null)
                    {
                        return false;
                    }

                    return PairsInCorrectOrder(Tuple.Create(list1[i], list2[i])!);
                }
            }

            return true;
        }
    }

    private static bool CompareInts(int? first, int? second) => second >= first;

    private static bool IsList(object? o) =>
        o is IList &&
        o.GetType().IsGenericType &&
        o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
}