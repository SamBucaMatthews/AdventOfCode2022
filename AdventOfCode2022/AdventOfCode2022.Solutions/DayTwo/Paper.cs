namespace AdventOfCode2022.Solutions.DayTwo;

public class Paper : Move
{
    public Paper(
        string playerOneInput,
        string playerTwoInput,
        int pointsForPlaying):
        base(playerOneInput, playerTwoInput, pointsForPlaying)
    {
    }

    public override Type Beats() => typeof(Rock);

    public override Type LosesTo() => typeof(Scissors);
}
