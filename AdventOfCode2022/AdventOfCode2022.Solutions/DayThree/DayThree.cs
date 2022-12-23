namespace AdventOfCode2022.Solutions.DayThree;

/// <summary>
/// https://adventofcode.com/2022/day/3
/// </summary>
public static class DayThree
{
    public static int CalculatePriorities(IEnumerable<string> rucksackInputs)
    {
        var priority = 0;
        foreach (var rucksackInput in rucksackInputs)
        {
            var rucksack = new RuckSack(rucksackInput);
            var itemsInBothCompartments = 
                rucksack.Compartments[0].Items.Intersect(rucksack.Compartments[1].Items);

            priority += itemsInBothCompartments.Sum(i => CalculatePriority(i.Type));
        }

        return priority;
    }
    
    public static int CalculatePrioritiesOfEachElfGroup(IEnumerable<string> rucksackInputs)
    {
        const int groupSize = 3;
        
        var elfGroups = rucksackInputs
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(i => i.Index / groupSize)
            .Select(x => x.Select(v => new RuckSack(v.Value)).ToList())
            .Select(x => new ElfGroup(x))
            .ToList();

        return elfGroups.Sum(elfGroup => CalculatePriority(elfGroup.BadgeType));
    }

    private static int CalculatePriority(string itemType)
    {
        var priority = char.Parse(itemType) % 32;

        if (itemType == itemType.ToUpper())
        {
            priority += 26;
        }

        return priority;
    }
}
