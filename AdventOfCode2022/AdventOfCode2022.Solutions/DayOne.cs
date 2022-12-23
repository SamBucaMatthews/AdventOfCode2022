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
    public static int TotalCaloriesCarriedByElfWithMost(IEnumerable<string> input)
    {
         var caloriesCarriedByEachElf = CaloriesCarriedByEachElf(input);

         var caloriesBeingCarriedByElfWithMost = caloriesCarriedByEachElf
             .Select(e => e.Sum())
             .Max();

         return caloriesBeingCarriedByElfWithMost;
    }
    
    /// <summary>
    /// Finds the total calories being carried by the top three elves.
    /// </summary>
    /// <param name="input">This list represents the Calories of the food carried by the Elves</param>
    /// <returns>The total calories carried by the top three elves.</returns>
    public static int TotalCaloriesCarriedByTopThreeElves(IEnumerable<string> input)
    {
        var caloriesCarriedByEachElf = CaloriesCarriedByEachElf(input);

        var totalCarriedByTopThree = caloriesCarriedByEachElf
            .Select(e => e.Sum())
            .OrderByDescending(e => e)
            .Take(3)
            .Sum();
        
        return totalCarriedByTopThree;
    }

    private static IEnumerable<List<int>> CaloriesCarriedByEachElf(IEnumerable<string> input)
    {
        var lines = input
            .Select(l => l.Trim())
            .ToList();

        var elves = new List<List<int>>();
        var currentElf = new List<int>();

        foreach (var currentLine in lines)
        {
            if (int.TryParse(currentLine, out var caloriesOfItem))
            {
                currentElf.Add(caloriesOfItem);
            }
            
            if (string.IsNullOrWhiteSpace(currentLine) || currentLine == lines.Last())
            {
                elves.Add(currentElf);
                currentElf = new List<int>();
            }
        }
        
        elves.Add(currentElf);

        return elves;
    }
}
