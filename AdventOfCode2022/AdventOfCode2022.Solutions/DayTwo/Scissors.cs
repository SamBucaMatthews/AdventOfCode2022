namespace AdventOfCode2022.Solutions.DayTwo;

public class Scissors : Move
{
    public Scissors(
        string playerOneInput,
        string playerTwoInput,
        int pointsForPlaying):
        base(playerOneInput, playerTwoInput, pointsForPlaying)
    {
    }

    public override Type Beats() => typeof(Paper);

    public override Type LosesTo() => typeof(Rock);
}
