namespace AdventOfCode2022.Solutions.DayThirteen;

public static class PacketPairParser
{
    public static List<Tuple<List<object>, List<object>>> ParsePairs(string[] input)
    {
        var output = new List<Tuple<List<object>, List<object>>>();

        return output;
    }

    public static List<object> Parse(string input)
    {
        var list = new List<object>();
        var currentList = list;
        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (int.TryParse(c.ToString(), out var intElement))
            {
                currentList.Add(intElement);
            }
            else if (c == '[' && i != 0)
            {
                currentList = new List<object>();
            }
            else if (c == ']' && i != input.Length - 1)
            {
                list.Add(currentList);
                currentList = list;
            }
        }

        return list;
    }
}
