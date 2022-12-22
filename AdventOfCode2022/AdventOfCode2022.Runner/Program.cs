// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Solutions;

IEnumerable<string> GetInput(string dayName)
{
    var dayOneInputFile = $@".\Inputs\{dayName}\input.txt";

    return File.ReadAllLines(dayOneInputFile);
}

var dayOneSolution = DayOne.Solve(GetInput(nameof(DayOne)));

Console.WriteLine($"Day one solution: {dayOneSolution}");
