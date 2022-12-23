using AdventOfCode2022.Solutions;

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
            PointsForWinning,
            PointsForDrawing);
    }
    
    [Test]
    public void TotalPointsForStrategy_GivenInputsFromExample_SolvesCorrectly()
    {
        const int expected = 15;
        var actual = _dayTwo.TotalPointsForStrategy(ExampleInput);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(RockPlayerOne, ScissorsPlayerTwo, PointsForPlayingScissors)]
    [TestCase(PaperPlayerOne, RockPlayerTwo, PointsForPlayingRock)]
    [TestCase(ScissorsPlayerOne, PaperPlayerTwo, PointsForPlayingPaper)]
    public void TotalPointsForStrategy_GivenAllSameChoiceAndAllLosses_ReturnsPointsForPlayingOnly(
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
        var actual = _dayTwo.TotalPointsForStrategy(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCaseSource(nameof(MoveConfigs))]
    public void TotalPointsForStrategy_GivenAllSameChoiceAndAllDraws_ReturnsPointsForPlayingAndPointsForDrawing(
        Move move)
    {
        var input = new[]
        {
            $"{move.PlayerOneInput} {move.PlayerTwoInput}",
            $"{move.PlayerOneInput} {move.PlayerTwoInput}",
            $"{move.PlayerOneInput} {move.PlayerTwoInput}",
        };
        
        var expected = (PointsForDrawing + move.PointsForPlaying) * 3;
        var actual = _dayTwo.TotalPointsForStrategy(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(RockPlayerOne, PaperPlayerTwo, PointsForPlayingPaper)]
    [TestCase(PaperPlayerOne, ScissorsPlayerTwo, PointsForPlayingScissors)]
    [TestCase(ScissorsPlayerOne, RockPlayerTwo, PointsForPlayingRock)]
    public void TotalPointsForStrategy_GivenAllSameChoiceAndAllWins_ReturnsPointsForPlayingAndPointsForWinning(
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
        var actual = _dayTwo.TotalPointsForStrategy(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
