namespace AdventOfCode2022.Solutions;

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

    public abstract bool Beats(Type typeToBeat);
}
