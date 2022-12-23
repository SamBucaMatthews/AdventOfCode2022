namespace AdventOfCode2022.Solutions;

public class Rock : Move
{
    public Rock(
        string playerOneInput,
        string playerTwoInput,
        int pointsForPlaying):
        base(playerOneInput, playerTwoInput, pointsForPlaying)
    {
    }

    public override bool Beats(Type typeToBeat) => typeToBeat == typeof(Scissors);
}
