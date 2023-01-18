using System.Collections;

namespace AdventOfCode2022.Solutions.DayThirteen;

public class PairComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        while (true)
        {
            var list1 = ToList(x);
            var list2 = ToList(y);

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

                    return int2 >= int1 ? 1 : -1;
                }

                if (list1[i] is not null && list2[i] is null)
                {
                    return -1;
                }

                if (list1[i] is null && list2[i] is not null)
                {
                    return 1;
                }

                return Compare(list1[i], list2[i]);
            }

            return 1;
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
