namespace AdventOfCode2022.Solutions.DayThree;

public class ElfGroup
{
    private readonly List<RuckSack> _elfRuckSacks;

    public string BadgeType => ItemsInEachCompartment(_elfRuckSacks[0])
        .Intersect(ItemsInEachCompartment(_elfRuckSacks[1]))
        .Intersect(ItemsInEachCompartment(_elfRuckSacks[2]))
        .First();

    public ElfGroup(List<RuckSack> ruckSacks)
    {
        if (ruckSacks.Count != 3)
        {
            throw new ArgumentException();
        }

        _elfRuckSacks = ruckSacks;
    }
    
    private static IEnumerable<string> ItemsInEachCompartment(RuckSack ruckSack) =>
        ruckSack.Compartments.SelectMany(i => i.Items.Select(item => item.Type));
}
