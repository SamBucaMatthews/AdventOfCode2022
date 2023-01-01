namespace AdventOfCode2022.Solutions.DayTen;

public class Crt
{
    private readonly int _columns;
    private readonly int _rows;
    private readonly char[] _screen;
    private int _x = 1;

    public Crt(int columns, int rows)
    {
        _columns = columns;
        _rows = rows;
        _screen = new char[columns * rows];
    }

    public void Run(IEnumerable<string> input)
    {
        var output = UpdateSpritePositionFromInstructions(input)
            .Select((position, tick) => (position, tick));

        foreach (var (position, tick) in output)
        {
            var index = tick % _screen.Length;
            var col = index % _columns;
            if (col >= position - 1 && col <= position + 1)
            {
                _screen[index] = '#';
            }
            else
            {
                _screen[index] = '.';
            }
        }
        
        for (var row = 0; row < _rows; row++)
        {
            Console.WriteLine(new string(_screen, row * _columns, _columns));
        }
    }

    private IEnumerable<int> UpdateSpritePositionFromInstructions(IEnumerable<string> input)
    {
        foreach (var instruction in input)
        {
            var commandParts = instruction.Split(" ");
            switch (commandParts[0])
            {
                case "noop":
                    yield return _x;
                    break;
                case "addx" when int.TryParse(commandParts[1], out var xChange):
                    yield return _x;
                    yield return _x;
                    _x += xChange;
                    break;
            }
        }
    }
}
