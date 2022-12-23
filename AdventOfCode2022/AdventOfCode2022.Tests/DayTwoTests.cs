using AdventOfCode2022.Solutions.DayTwo;

namespace AdventOfCode2022.Tests;

public class DayTwoTests
{
    private const string RockPlayerOne = "A";
    private const string PaperPlayerOne = "B";
    private const string ScissorsPlayerOne = "C";
    
    private const string RockPlayerTwo = "X";
    private const string PaperPlayerTwo = "Y";
    private const string ScissorsPlayerTwo = "Z";

    private const int PointsForPlayingRock = 1;
    private const int PointsForPlayingPaper = 2;
    private const int PointsForPlayingScissors = 3;

    private const int PointsForWinning = 6;
    private const int PointsForDrawing = 3;
    private const int PointsForLosing = 0;
    
    private const string Win = "Z";
    private const string Lose = "X";
    private const string Draw = "Y";

    private static readonly Rock RockConfig = new(
        RockPlayerOne,
        RockPlayerTwo,
        PointsForPlayingRock);

    private static readonly Paper PaperConfig = new(
        PaperPlayerOne,
        PaperPlayerTwo,
        PointsForPlayingPaper);

    private static readonly Scissors ScissorsConfig = new(
        ScissorsPlayerOne,
        ScissorsPlayerTwo,
        PointsForPlayingScissors);

    private static readonly WinLoseDrawDecryptionConfig WinLoseDrawDecryptionConfig = new(
        Win,
        Lose,
        Draw);
    
    private static readonly string[] ExampleInput =
    {
        "A Y",
        "B X",
        "C Z",
    };

    private static readonly Move[] MoveConfigs =
    {
        RockConfig,
        PaperConfig,
        ScissorsConfig,
    };

    private DayTwo _dayTwo = null!;

    [SetUp]
    public void SetUp()
    {
        _dayTwo = new DayTwo(
            RockConfig,
            PaperConfig,
            ScissorsConfig,
            WinLoseDrawDecryptionConfig,
            PointsForWinning,
            PointsForDrawing);
    }
    
    [Test]
    public void CalculateTotalPointsUsingSecondColumnAsMove_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 15;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsMove(ExampleInput);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(RockPlayerOne, ScissorsPlayerTwo, PointsForPlayingScissors)]
    [TestCase(PaperPlayerOne, RockPlayerTwo, PointsForPlayingRock)]
    [TestCase(ScissorsPlayerOne, PaperPlayerTwo, PointsForPlayingPaper)]
    public void CalculateTotalPointsUsingSecondColumnAsMove_GivenAllSameChoiceAndAllLosses_ReturnsPointsForPlayingOnly(
        string playerOneChoice,
        string playerTwoChoice,
        int pointsForPlaying)
    {
        var input = new[]
        {
            $"{playerOneChoice} {playerTwoChoice}",
            $"{playerOneChoice} {playerTwoChoice}",
            $"{playerOneChoice} {playerTwoChoice}",
        };
        
        var expected = (PointsForLosing + pointsForPlaying) * 3;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsMove(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCaseSource(nameof(MoveConfigs))]
    public void CalculateTotalPointsUsingSecondColumnAsMove_GivenAllSameChoiceAndAllDraws_ReturnsPointsForPlayingAndPointsForDrawing(
        Move move)
    {
        var input = new[]
        {
            $"{move.PlayerOneInput} {move.PlayerTwoInput}",
            $"{move.PlayerOneInput} {move.PlayerTwoInput}",
            $"{move.PlayerOneInput} {move.PlayerTwoInput}",
        };
        
        var expected = (PointsForDrawing + move.PointsForPlaying) * 3;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsMove(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(RockPlayerOne, PaperPlayerTwo, PointsForPlayingPaper)]
    [TestCase(PaperPlayerOne, ScissorsPlayerTwo, PointsForPlayingScissors)]
    [TestCase(ScissorsPlayerOne, RockPlayerTwo, PointsForPlayingRock)]
    public void CalculateTotalPointsUsingSecondColumnAsMove_GivenAllSameChoiceAndAllWins_ReturnsPointsForPlayingAndPointsForWinning(
        string playerOneChoice,
        string playerTwoChoice,
        int pointsForPlaying)
    {
        var input = new[]
        {
            $"{playerOneChoice} {playerTwoChoice}",
            $"{playerOneChoice} {playerTwoChoice}",
            $"{playerOneChoice} {playerTwoChoice}",
        };
        
        var expected = (PointsForWinning + pointsForPlaying) * 3;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsMove(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void CalculateTotalPointsUsingSecondColumnAsResult_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 12;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsResult(ExampleInput);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(RockPlayerOne, PointsForPlayingScissors)]
    [TestCase(PaperPlayerOne,PointsForPlayingRock)]
    [TestCase(ScissorsPlayerOne,PointsForPlayingPaper)]
    public void CalculateTotalPointsUsingSecondColumnAsResult_GivenAllSameMovesAndAllLosses_ReturnsPointsForPlaying(
        string playerOneChoice,
        int pointsForPlaying)
    {
        var input = new[]
        {
            $"{playerOneChoice} {Lose}",
            $"{playerOneChoice} {Lose}",
            $"{playerOneChoice} {Lose}",
        };
        
        var expected = (PointsForLosing + pointsForPlaying) * 3;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsResult(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase(RockPlayerOne, PointsForPlayingPaper)]
    [TestCase(PaperPlayerOne,PointsForPlayingScissors)]
    [TestCase(ScissorsPlayerOne,PointsForPlayingRock)]
    public void CalculateTotalPointsUsingSecondColumnAsResult_GivenAllSameMovesAndAllWins_ReturnsPointsForPlaying(
        string playerOneChoice,
        int pointsForPlaying)
    {
        var input = new[]
        {
            $"{playerOneChoice} {Win}",
            $"{playerOneChoice} {Win}",
            $"{playerOneChoice} {Win}",
        };
        
        var expected = (PointsForWinning + pointsForPlaying) * 3;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsResult(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase(RockPlayerOne, PointsForPlayingRock)]
    [TestCase(PaperPlayerOne,PointsForPlayingPaper)]
    [TestCase(ScissorsPlayerOne,PointsForPlayingScissors)]
    public void CalculateTotalPointsUsingSecondColumnAsResult_GivenAllSameMovesAndAllDraws_ReturnsPointsForPlaying(
        string playerOneChoice,
        int pointsForPlaying)
    {
        var input = new[]
        {
            $"{playerOneChoice} {Draw}",
            $"{playerOneChoice} {Draw}",
            $"{playerOneChoice} {Draw}",
        };
        
        var expected = (PointsForDrawing + pointsForPlaying) * 3;
        var actual = _dayTwo.CalculateTotalPointsUsingSecondColumnAsResult(input);
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}
