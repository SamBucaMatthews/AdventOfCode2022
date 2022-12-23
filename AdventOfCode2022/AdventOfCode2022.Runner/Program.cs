// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Solutions.DayOne;
using AdventOfCode2022.Solutions.DayTwo;

IEnumerable<string> GetInput(string dayName)
{
    var dayOneInputFile = $@".\Inputs\{dayName}\input.txt";

    return File.ReadAllLines(dayOneInputFile);
}

void SolveDayOne()
{
    var i = DayOne.TotalCaloriesCarriedByElfWithMost(GetInput(nameof(DayOne)));
    var dayOneSolutionPartTwo = DayOne.TotalCaloriesCarriedByTopThreeElves(GetInput(nameof(DayOne)));

    Console.WriteLine($"Day one solution (Part One): {i}");
    Console.WriteLine($"Day one solution (Part Two): {dayOneSolutionPartTwo}");
}

void SolveDayTwo()
{
    var rockConfig = new Rock(
        "A",
        "X",
        1);

    var paperConfig = new Paper(
        "B",
        "Y",
        2);

    var scissorsConfig = new Scissors(
        "C",
        "Z",
        3);

    var winLoseDrawDecryptionConfig = new WinLoseDrawDecryptionConfig(
        "Z",
        "X",
        "Y");

    var dayTwo = new DayTwo(
        rockConfig,
        paperConfig,
        scissorsConfig,
        winLoseDrawDecryptionConfig,
        6,
        3);

    var dayTwoSolutionPartOne = dayTwo.CalculateTotalPointsUsingSecondColumnAsMove(GetInput(nameof(DayTwo)));
    var dayTwoSolutionPartTwo = dayTwo.CalculateTotalPointsUsingSecondColumnAsResult(GetInput(nameof(DayTwo)));

    Console.WriteLine($"Day two solution (Part One): {dayTwoSolutionPartOne}");
    Console.WriteLine($"Day two solution (Part Two): {dayTwoSolutionPartTwo}");
}

SolveDayOne();
SolveDayTwo();
