namespace AdventOfCode2022.Solutions.DayTwelve;

public class TerrainMap
{
    public List<Point> StartingPositions { get; } = new();

    public Point? End { get; }

    public List<Point> Points { get; }

    public TerrainMap(IReadOnlyList<string> input, char[] startChars, char endChar)
    {
        var rowCount = input.Count;
        var columnCount = input[0].Length;

        Points = new List<Point>();

        for (var rowNumber = 0; rowNumber < rowCount; rowNumber++)
        {
            for (var columnNumber = 0; columnNumber < columnCount; columnNumber++)
            {
                var letter = input[rowNumber][columnNumber];

                var point = new Point(
                    rowNumber,
                    columnNumber,
                    LetterToHeight(letter));

                if (startChars.Contains(letter))
                {
                    StartingPositions.Add(point);
                }

                if (letter == endChar)
                {
                    End = point;
                }

                Points.Add(point);
            }
        }
    }


    private static int LetterToHeight(char letter) =>
        letter switch
        {
            'S' => 0,
            'E' => 'z' - 'a',
            _ => letter - 'a'
        };
}
