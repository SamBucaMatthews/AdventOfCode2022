namespace AdventOfCode2022.Solutions;

public class Paper : Move
{
    public Paper(
        string playerOneInput,
        string playerTwoInput,
        int pointsForPlaying):
        base(playerOneInput, playerTwoInput, pointsForPlaying)
    {
    }

    public override bool Beats(Type typeToBeat) => typeToBeat == typeof(Rock);
}
