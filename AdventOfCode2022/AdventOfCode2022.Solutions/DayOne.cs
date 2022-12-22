namespace AdventOfCode2022.Solutions;

/*
 * https://adventofcode.com/2022/day/1
 */

public static class DayOne
{
    /// <summary>
    /// Finds the total calories being carried by the Elf carrying the most calories.
    /// </summary>
    /// <param name="input">This list represents the Calories of the food carried by the Elves</param>
    /// <returns>The total calories being carried by the Elf carrying the most calories</returns>
    public static int Solve(IEnumerable<string> input)
    {
         var lines = input
             .Select(l => l.Trim())
             .ToList();

         var elves = new List<List<int>>();
         var currentElf = new List<int>();

         foreach (var currentLine in lines)
         {
             if (string.IsNullOrWhiteSpace(currentLine))
             {
                 elves.Add(currentElf);
                 currentElf = new List<int>();
                 continue;
             }

             if (int.TryParse(currentLine, out var caloriesOfItem))
             {
                 currentElf.Add(caloriesOfItem);
             }
         }

         var caloriesBeingCarriedByElfWithMost = elves
             .Select(e => e.Sum())
             .Max();

         return caloriesBeingCarriedByElfWithMost;
    }
}
