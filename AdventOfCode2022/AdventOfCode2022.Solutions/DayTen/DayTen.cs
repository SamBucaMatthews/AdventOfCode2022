namespace AdventOfCode2022.Solutions.DayTen;

public static class DayTen
{
    public static int SumOfSignalStrengths(IEnumerable<string> input, IEnumerable<int> cycles)
    {
        const string noop = "noop";
        const string addX = "addx";

        var cpu = new Cpu();

        foreach (var command in input)
        {
            if (command == noop)
            {
                cpu.Noop();
                continue;
            }

            var commandParts = command.Split(" ");

            if (commandParts[0] != addX || !int.TryParse(commandParts[1], out var xChange))
            {
                throw new ArgumentException("Invalid input provided", nameof(input));
            }

            cpu.AddX(xChange);
        }

        return cycles.Sum(cycle => cpu.SignalStrengths[cycle]);
    }

    public static void RunCrtToCompletion(IEnumerable<string> input)
        => new Crt(40, 6).Run(input);
}
