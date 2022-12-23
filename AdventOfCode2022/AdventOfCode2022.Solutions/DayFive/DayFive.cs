using System.Text.RegularExpressions;

namespace AdventOfCode2022.Solutions.DayFive;

public static class DayFive
{
    public static string GetCratesAtTopOfEachStack(List<string> input, CraneType craneType)
    {
        var stackStrings = StackStrings(input);
        var instructionStrings = InstructionStrings(input);
        var stacks = SetupEmptyStacks(stackStrings);

        SetupInitialStackLayout(stackStrings, stacks);
        ExecuteInstructions(instructionStrings, stacks, craneType);

        return string.Join("", stacks.Select(s =>
        {
            s.TryPeek(out var item);
            return item ?? " ";
        }));
    }

    private static void ExecuteInstructions(
        List<string> instructionStrings,
        IReadOnlyList<Stack<string>> stacks,
        CraneType craneType)
    {
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

            switch (craneType)
            {
                case CraneType.CrateMover9000:
                    for (var i = 0; i < countToMove; i++)
                    {
                        var toMove = stacks[fromStack - 1].Pop();
                        stacks[toStack - 1].Push(toMove);
                    }

                    break;
                case CraneType.CrateMover9001:
                    var pickedUpByCrane = new Stack<string>();

                    for (var i = 0; i < countToMove; i++)
                    {
                        var toMove = stacks[fromStack - 1].Pop();
                        pickedUpByCrane.Push(toMove);
                    }

                    for (var i = 0; i < countToMove; i++)
                    {
                        var toMove = pickedUpByCrane.Pop();
                        stacks[toStack - 1].Push(toMove);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(craneType), craneType, null);
            }
        }
    }

    private static void SetupInitialStackLayout(List<string> stackStrings, List<Stack<string>> stacks)
    {
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
    }

    private static List<Stack<string>> SetupEmptyStacks(IEnumerable<string> stackStrings) =>
        stackStrings
            .Last()
            .Split(" ")
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => new Stack<string>())
            .ToList();

    private static List<string> StackStrings(IEnumerable<string> input) =>
        input
            .Where(i => !i.StartsWith("move") && !string.IsNullOrWhiteSpace(i))
            .ToList();

    private static List<string> InstructionStrings(IEnumerable<string> input) =>
        input
            .Where(i => i.StartsWith("move"))
            .ToList();
}
