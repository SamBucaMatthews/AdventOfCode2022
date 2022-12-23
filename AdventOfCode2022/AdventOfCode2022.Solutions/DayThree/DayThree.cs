namespace AdventOfCode2022.Solutions.DayThree;

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
