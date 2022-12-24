namespace AdventOfCode2022.Solutions.DaySix;

public static class DaySix
{
    public static int FindStartOfMarker(string input, int distinctCharacters)
    {
        var sliceStart = 0;

        while (input.Substring(sliceStart, distinctCharacters).Distinct().Count() != distinctCharacters)
        {
            sliceStart++;
        }

        return sliceStart + distinctCharacters;
    }
}
