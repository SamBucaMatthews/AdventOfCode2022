namespace AdventOfCode2022.Solutions.DayThirteen;

public static class PacketPairParser
{
    public static List<Tuple<List<object>, List<object>>> ParsePairs(string[] input)
    {
        var output = new List<Tuple<List<object>, List<object>>>();

        for (var i = 0; i < input.Length; i += 3)
        {
            var item1 = Parse(input[i]);
            var item2 = Parse(input[i + 1]);

            output.Add(Tuple.Create(item1, item2));
        }

        return output;
    }

    public static List<object> Parse(string input)
    {
        var result = new List<object>();
        var currentList = result;
        var stack = new Stack<List<object>>();
        
        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (c == '[' && i != 0)
            {
                var newList = new List<object>();
                currentList.Add(newList);
                stack.Push(currentList);
                currentList = newList;
            }
            else if (c == ']' && i != input.Length - 1)
            {
                currentList = stack.Pop();
            }
            else if (int.TryParse(c.ToString(), out var intElement))
            {
                currentList.Add(intElement);
            }
        }

        return result;
    }
}
