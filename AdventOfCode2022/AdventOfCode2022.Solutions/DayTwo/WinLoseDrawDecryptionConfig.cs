namespace AdventOfCode2022.Solutions.DayTwo;


public record WinLoseDrawDecryptionConfig(string Win, string Lose, string Draw)
{
    public readonly string Win = Win;
    public readonly string Lose = Lose;
    public readonly string Draw = Draw;
}