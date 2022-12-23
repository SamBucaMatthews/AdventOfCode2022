namespace AdventOfCode2022.Solutions;

public class DayTwo
{
    private readonly Rock _rock;
    private readonly Paper _paper;
    private readonly Scissors _scissors;
    private readonly int _pointsForWinning;
    private readonly int _pointsForDrawing;

    public DayTwo(
        Rock rock,
        Paper paper,
        Scissors scissors,
        int pointsForWinning,
        int pointsForDrawing)
    {
        _rock = rock;
        _paper = paper;
        _scissors = scissors;
        _pointsForWinning = pointsForWinning;
        _pointsForDrawing = pointsForDrawing;
    }

    public int TotalPointsForStrategy(IEnumerable<string> input)
    {
        var movePairs = input.Select(m => m.Split(" ")).ToList();

        var totalPoints = 0;
        foreach (var movePair in movePairs)
        {
            var playerOneMove = GetPlayerMove(movePair[0], 1);
            var playerTwoMove = GetPlayerMove(movePair[1], 2);

            totalPoints += playerTwoMove.PointsForPlaying;

            if (playerOneMove.GetType() == playerTwoMove.GetType())
            {
                totalPoints += _pointsForDrawing;
                continue;
            }

            if (playerTwoMove.Beats(playerOneMove.GetType()))
            {
                totalPoints += _pointsForWinning;
            }
        }
        
        return totalPoints;
    }
    
    private Move GetPlayerMove(string playerMoveString, int player)
    {
        var moves = new List<Move>
        {
            _rock,
            _paper,
            _scissors,
        };

        return player switch
        {
            1 => moves.Find(c => c.PlayerOneInput == playerMoveString) ?? throw new InvalidOperationException(),
            2 => moves.Find(c => c.PlayerTwoInput == playerMoveString) ?? throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
