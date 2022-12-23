using System.Text.RegularExpressions;

namespace AdventOfCode2022.Solutions.DayFive;

public static class DayFive
{
    public static string GetCratesAtTopOfEachStack(List<string> input)
    {
        var stackStrings = input
            .Where(i => !i.StartsWith("move") && !string.IsNullOrWhiteSpace(i))
            .ToList();

        var instructionStrings = input
            .Where(i => i.StartsWith("move"))
            .ToList();

        var stacks = stackStrings
            .Last()
            .Split(" ")
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => new Stack<string>())
            .ToList();

        for (var i = stackStrings.Count - 2; i >= 0; i--)
        {
            const int groupSize = 4;

            var itemsInStacks = stackStrings[i]
                .Select((x, index) => new { Index = index, Value = x })
                .GroupBy(grouper => grouper.Index / groupSize)
                .Select(g => g.Select(x => x.Value.ToString()).ToList())
                .ToList();

            for (var j = 0; j < itemsInStacks.Count; j++)
            {
                if (string.IsNullOrWhiteSpace(itemsInStacks[j][1]))
                {
                    continue;
                }
                
                stacks[j].Push(itemsInStacks[j][1]);
            }
        }

        foreach (var instructionString in instructionStrings)
        {
            var instructions = new Regex(@" \d+").Matches(instructionString);

            if (
                !int.TryParse(instructions[0].Value, out var countToMove) ||
                !int.TryParse(instructions[1].Value, out var fromStack) ||
                !int.TryParse(instructions[2].Value, out var toStack))
            {
                throw new ArgumentException();
            }

            for (var i = 0; i < countToMove; i++)
            {
                var toMove = stacks[fromStack - 1].Pop();
                stacks[toStack - 1].Push(toMove);
            }
        }

        return string.Join("", stacks.Select(s => s.Pop()));
    }
}
