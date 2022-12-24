namespace AdventOfCode2022.Solutions.DaySix;

public static class DaySix
{
    public static int FindStartOfPacketMarker(string input)
    {
        var sliceStart = 0;
        const int sliceLength = 4;

        while (input.Substring(sliceStart, sliceLength).Distinct().Count() != 4)
        {
            sliceStart++;
        }

        return sliceStart + sliceLength;
    }
}
