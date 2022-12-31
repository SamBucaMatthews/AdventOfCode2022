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
}

public class Cpu
{
    private int _x = 1;
    private int _currentCycle = 1;

    public readonly Dictionary<int, int> SignalStrengths = new() { { 1, 1 }};

    public void Noop() => UpdateCycle();

    public void AddX(int change)
    {
        UpdateCycle();
        _x += change;
        UpdateCycle();
    }

    private void UpdateCycle()
    {
        _currentCycle++;
        SignalStrengths[_currentCycle] = _currentCycle * _x;
    }
}
