// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Solutions.DayEight;
using AdventOfCode2022.Solutions.DayFive;
using AdventOfCode2022.Solutions.DayFour;
using AdventOfCode2022.Solutions.DayNine;
using AdventOfCode2022.Solutions.DayOne;
using AdventOfCode2022.Solutions.DaySeven;
using AdventOfCode2022.Solutions.DaySix;
using AdventOfCode2022.Solutions.DayThree;
using AdventOfCode2022.Solutions.DayTwo;

IEnumerable<string> GetInput(string dayName)
{
    var dayOneInputFile = $@".\Inputs\{dayName}\input.txt";

    return File.ReadAllLines(dayOneInputFile);
}

void SolveDayOne()
{
    var dayOneSolutionPartOne = DayOne.TotalCaloriesCarriedByElfWithMost(GetInput(nameof(DayOne)));
    var dayOneSolutionPartTwo = DayOne.TotalCaloriesCarriedByTopThreeElves(GetInput(nameof(DayOne)));

    Console.WriteLine($"Day one solution (Part One): {dayOneSolutionPartOne}");
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

void SolveDayThree()
{
    var dayThreeSolutionPartOne = DayThree.CalculatePriorities(GetInput(nameof(DayThree)));
    var dayThreeSolutionPartTwo = DayThree.CalculatePrioritiesOfEachElfGroup(GetInput(nameof(DayThree)));

    Console.WriteLine($"Day three solution (Part One): {dayThreeSolutionPartOne}");
    Console.WriteLine($"Day three solution (Part Two): {dayThreeSolutionPartTwo}");
}

void SolveDayFour()
{
    var dayFourSolutionPartOne = DayFour.CountOverlappingAssignmentPairs(
        GetInput(nameof(DayFour)),
        true);

    var dayFourSolutionPartTwo = DayFour.CountOverlappingAssignmentPairs(
        GetInput(nameof(DayFour)),
        false);

    Console.WriteLine($"Day four solution (Part One): {dayFourSolutionPartOne}");
    Console.WriteLine($"Day four solution (Part Two): {dayFourSolutionPartTwo}");
}

void SolveDayFive()
{
    var dayFiveSolutionPartOne = DayFive.GetCratesAtTopOfEachStack(
        GetInput(nameof(DayFive)).ToList(),
        CraneType.CrateMover9000);
    
    var dayFiveSolutionPartTwo = DayFive.GetCratesAtTopOfEachStack(
        GetInput(nameof(DayFive)).ToList(),
        CraneType.CrateMover9001);

    Console.WriteLine($"Day five solution (Part One): {dayFiveSolutionPartOne}");
    Console.WriteLine($"Day five solution (Part Two): {dayFiveSolutionPartTwo}");
}

void SolveDaySix()
{
    var daySixSolutionPartOne = DaySix.FindStartOfMarker(
        GetInput(nameof(DaySix)).First(),
        4);
    
    var daySixSolutionPartTwo = DaySix.FindStartOfMarker(
        GetInput(nameof(DaySix)).First(),
        14);

    Console.WriteLine($"Day six solution (Part One): {daySixSolutionPartOne}");
    Console.WriteLine($"Day six solution (Part Two): {daySixSolutionPartTwo}");
}

void SolveDaySeven()
{
    var daySevenSolutionPartOne = DaySeven.FindSumOfTotalMatchingDirectories(GetInput(nameof(DaySeven)));
    var daySevenSolutionPartTwo = DaySeven.FindSizeOfDirectoryToDelete(GetInput(nameof(DaySeven)));
    
    Console.WriteLine($"Day seven solution (Part One): {daySevenSolutionPartOne}");
    Console.WriteLine($"Day seven solution (Part Two): {daySevenSolutionPartTwo}");
}

void SolveDayEight()
{
    var dayEightSolutionPartOne = DayEight.CountVisibleTrees(GetInput(nameof(DayEight)).ToArray());
    var dayEightSolutionPartTwo = DayEight.GetMaxScenicScore(GetInput(nameof(DayEight)).ToArray());
    
    Console.WriteLine($"Day eight solution (Part One): {dayEightSolutionPartOne}");
    Console.WriteLine($"Day eight solution (Part Two): {dayEightSolutionPartTwo}");
}

void SolveDayNine()
{
    var dayNineSolutionPartOne = DayNine.CountPositionsVisitedByTail(GetInput(nameof(DayNine)));
    
    Console.WriteLine($"Day nine solution (Part One): {dayNineSolutionPartOne}");
}

SolveDayOne();
SolveDayTwo();
SolveDayThree();
SolveDayFour();
SolveDayFive();
SolveDaySix();
SolveDaySeven();
SolveDayEight();
SolveDayNine();
