namespace AdventOfCode2022.Solutions.DayTwo;

public class Rock : Move
{
    public Rock(
        string playerOneInput,
        string playerTwoInput,
        int pointsForPlaying):
        base(playerOneInput, playerTwoInput, pointsForPlaying)
    {
    }

    public override Type Beats() => typeof(Scissors);

    public override Type LosesTo() => typeof(Paper);
}
