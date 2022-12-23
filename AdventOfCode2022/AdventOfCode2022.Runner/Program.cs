// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Solutions;

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

    var dayTwo = new DayTwo(
        rockConfig,
        paperConfig,
        scissorsConfig,
        6,
        3);

    var dayTwoSolutionPartOne = dayTwo.TotalPointsForStrategy(GetInput(nameof(DayTwo)));

    Console.WriteLine($"Day two solution (Part One): {dayTwoSolutionPartOne}");
}


SolveDayOne();
SolveDayTwo();
