namespace AdventOfCode2022.Solutions.DayTwelve;

public class TerrainMap
{
    public Point? Start { get; }

    public Point? End { get; }

    public List<Point> Points { get; }

    public TerrainMap(string[] input, char startChar, char endChar)
    {
        var rowCount = input.Length;
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

                if (letter == startChar)
                {
                    Start = point;
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
