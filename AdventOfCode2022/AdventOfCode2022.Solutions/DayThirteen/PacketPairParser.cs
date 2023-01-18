namespace AdventOfCode2022.Solutions.DayThirteen;

public static class PacketPairParser
{
    public static List<Tuple<List<object>, List<object>>> ParsePairs(string[] input)
    {
        var output = new List<Tuple<List<object>, List<object>>>();

        for (var i = 0; i < input.Length; i += 3)
        {
            if (string.IsNullOrEmpty(input[i]) || string.IsNullOrEmpty(input[i + 1]))
            {
                continue;
            }

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
        var number = "";

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            if (c == '[' && i != 0)
            {
                if (!string.IsNullOrEmpty(number))
                {
                    AddAndResetNumber(currentList, ref number);
                }

                var newList = new List<object>();
                currentList.Add(newList);
                stack.Push(currentList);
                currentList = newList;
            }
            else if (c == ',')
            {
                if (string.IsNullOrEmpty(number))
                {
                    continue;
                }

                AddAndResetNumber(currentList, ref number);
            }
            else if (c == ']')
            {
                if (!string.IsNullOrEmpty(number))
                {
                    AddAndResetNumber(currentList, ref number);
                }

                if (stack.Count > 0)
                {
                    currentList = stack.Pop();
                }
            }
            else if (char.IsDigit(c))
            {
                number += c;
            }
        }

        if (!string.IsNullOrEmpty(number))
        {
            currentList.Add(int.Parse(number));
        }

        return result;
    }

    private static void AddAndResetNumber(ICollection<object> currentList, ref string number)
    {
        currentList.Add(int.Parse(number));
        number = "";
    }
}
