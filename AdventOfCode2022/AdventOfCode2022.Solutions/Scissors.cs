namespace AdventOfCode2022.Solutions;

public class Scissors : Move
{
    public Scissors(
        string playerOneInput,
        string playerTwoInput,
        int pointsForPlaying):
        base(playerOneInput, playerTwoInput, pointsForPlaying)
    {
    }

    public override bool Beats(Type typeToBeat) => typeToBeat == typeof(Paper);
}
