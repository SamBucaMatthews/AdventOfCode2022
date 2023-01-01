namespace AdventOfCode2022.Solutions.DayTen;

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
