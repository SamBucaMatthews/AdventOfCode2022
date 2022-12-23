namespace AdventOfCode2022.Solutions.DayTwo;

/// <summary>
/// https://adventofcode.com/2022/day/2
/// </summary>
public class DayTwo
{
    private readonly WinLoseDrawDecryptionConfig _winLoseDrawDecryptionConfig;
    private readonly int _pointsForWinning;
    private readonly int _pointsForDrawing;
    private readonly List<Move> _moves;

    public DayTwo(
        Move rock,
        Move paper,
        Move scissors,
        WinLoseDrawDecryptionConfig winLoseDrawDecryptionConfig,
        int pointsForWinning,
        int pointsForDrawing)
    {
        _winLoseDrawDecryptionConfig = winLoseDrawDecryptionConfig;
        _pointsForWinning = pointsForWinning;
        _pointsForDrawing = pointsForDrawing;
        _moves = new List<Move>
        {
            rock,
            paper,
            scissors,
        };
    }

    
    /// <summary>
    /// Calculates the total amount of points for the strategy if the second column is
    /// used to indicate what shape should be played.
    /// </summary>
    /// <param name="input">The list of player moves.</param>
    /// <returns>The total amount of points for the strategy.</returns>
    public int CalculateTotalPointsUsingSecondColumnAsMove(IEnumerable<string> input)
    {
        var movePairs = input.Select(m => m.Split(" ")).ToList();

        var totalPoints = 0;
        foreach (var movePair in movePairs)
        {
            var playerOneMove = GetPlayerMove(movePair[0], 1);
            var playerTwoMove = GetPlayerMove(movePair[1], 2);

            totalPoints = TotalPoints(totalPoints, playerTwoMove, playerOneMove);
        }
        
        return totalPoints;
    }

    /// <summary>
    /// Calculates the total amount of points for the strategy if the second column is
    /// used to indicate whether the second player should win, lose, or draw.
    /// </summary>
    /// <param name="input">The list of player moves.</param>
    /// <returns>The total amount of points for the strategy.</returns>
    public int CalculateTotalPointsUsingSecondColumnAsResult(IEnumerable<string> input)
    {
        var movePairs = input.Select(m => m.Split(" ")).ToList();

        var totalPoints = 0;
        foreach (var movePair in movePairs)
        {
            var playerOneMove = GetPlayerMove(movePair[0], 1);
            var winLoseDraw = GetWinLoseDraw(movePair[1]);

            var playerTwoMove = winLoseDraw switch
            {
                WinLoseDraw.Win => GetWinningMove(playerOneMove),
                WinLoseDraw.Lose => GetLosingMove(playerOneMove),
                WinLoseDraw.Draw => playerOneMove,
                _ => throw new ArgumentOutOfRangeException()
            };

            totalPoints = TotalPoints(totalPoints, playerTwoMove, playerOneMove);
        }
        
        return totalPoints;
    }

    private Move GetLosingMove(Move moveToLoseTo) =>
        _moves.Find(m => m.GetType() == moveToLoseTo.Beats()) ?? throw new InvalidOperationException();

    private Move GetWinningMove(Move moveToBeat) =>
        _moves.Find(m => m.GetType() == moveToBeat.LosesTo()) ?? throw new InvalidOperationException();

    private WinLoseDraw GetWinLoseDraw(string winLoseDrawString)
    {
        if (winLoseDrawString == _winLoseDrawDecryptionConfig.Win)
        {
            return WinLoseDraw.Win;
        }
        
        if (winLoseDrawString == _winLoseDrawDecryptionConfig.Lose)
        {
            return WinLoseDraw.Lose;
        }
        
        if (winLoseDrawString == _winLoseDrawDecryptionConfig.Draw)
        {
            return WinLoseDraw.Draw;
        }

        throw new InvalidOperationException();
    }
    
    private int TotalPoints(int totalPoints, Move playerTwoMove, Move playerOneMove)
    {
        totalPoints += playerTwoMove.PointsForPlaying;

        if (playerOneMove.GetType() == playerTwoMove.GetType())
        {
            totalPoints += _pointsForDrawing;
            return totalPoints;
        }

        if (playerTwoMove.Beats() == playerOneMove.GetType())
        {
            totalPoints += _pointsForWinning;
        }

        return totalPoints;
    }

    private Move GetPlayerMove(string playerMoveString, int player) =>
        player switch
        {
            1 => _moves.Find(c => c.PlayerOneInput == playerMoveString) ?? throw new InvalidOperationException(),
            2 => _moves.Find(c => c.PlayerTwoInput == playerMoveString) ?? throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
}
