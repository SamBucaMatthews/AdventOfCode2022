// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Solutions;

IEnumerable<string> GetInput(string dayName)
{
    var dayOneInputFile = $@".\Inputs\{dayName}\input.txt";

    return File.ReadAllLines(dayOneInputFile);
}

var dayOneSolutionPartOne = DayOne.TotalCaloriesCarriedByElfWithMost(GetInput(nameof(DayOne)));
var dayOneSolutionPartTwo = DayOne.TotalCaloriesCarriedByTopThreeElves(GetInput(nameof(DayOne)));

Console.WriteLine($"Day one solution (Part One): {dayOneSolutionPartOne}");
Console.WriteLine($"Day one solution (Part Two): {dayOneSolutionPartTwo}");
