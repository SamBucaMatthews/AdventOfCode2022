namespace AdventOfCode2022.Solutions.DayTwo;

public abstract class Move
{
    public string PlayerOneInput { get; }
    public string PlayerTwoInput { get; }
    public int PointsForPlaying { get; }

    protected Move(
        string playerOneInput,
        string playerTwoInput,
        int pointsForPlaying)
    {
        PlayerOneInput = playerOneInput;
        PlayerTwoInput = playerTwoInput;
        PointsForPlaying = pointsForPlaying;
    }

    public abstract Type Beats();

    public abstract Type LosesTo();
}
