namespace AdventOfCode2022.Solutions.DayEleven;

public static class DayEleven
{
    public static ulong GetLevelOfMonkeyBusiness(int rounds, bool isPartOne)
    {
        // TODO: Improve solution by parsing monkey text (8 Monkeys wasn't too painful to hand type)
        var monkeys = new[]
        {
            new Monkey(
                new Queue<ulong>(new ulong[]{ 54, 53 }),
                old => old * 3,
                (divisor, item) => item % (ulong)divisor == 0 ? 2 : 6,
                2), // 0
            new Monkey(
                new Queue<ulong>(new ulong[]{ 95, 88, 75, 81, 91, 67, 65, 84 }),
                old => old * 11,
                (divisor, item) => item % (ulong)divisor == 0 ? 3 : 4,
                7), // 1
            new Monkey(
                new Queue<ulong>(new ulong[]{ 76, 81, 50, 93, 96, 81, 83 }),
                old => old + 6,
                (divisor, item) => item % (ulong)divisor == 0 ? 5 : 1,
                3), // 2
            new Monkey(
                new Queue<ulong>(new ulong[]{ 83, 85, 85, 63 }),
                old => old + 4,
                (divisor, item) => item % (ulong)divisor == 0 ? 7 : 4,
                11), // 3
            new Monkey(
                new Queue<ulong>(new ulong[]{ 85, 52, 64 }),
                old => old + 8,
                (divisor, item) => item % (ulong)divisor == 0 ? 0 : 7,
                17), // 4
            new Monkey(
                new Queue<ulong>(new ulong[]{ 57 }),
                old => old + 2,
                (divisor, item) => item % (ulong)divisor == 0 ? 1 : 3,
                5), // 5
            new Monkey(
                new Queue<ulong>(new ulong[]{ 60, 95, 76, 66, 91 }),
                old => old * old,
                (divisor, item) => item % (ulong)divisor == 0 ? 2 : 5,
                13), // 6
            new Monkey(
                new Queue<ulong>(new ulong[]{ 65, 84, 76, 72, 79, 65 }),
                old => old + 5,
                (divisor, item) => item % (ulong)divisor == 0 ? 6 : 0,
                19), // 7
        };

        var worryHandler = isPartOne
            ? x => x / 3
            : new Func<ulong, ulong>(x => x % (ulong)monkeys.Aggregate(1, (i, monkey) => i * monkey.Divisor));

        for (var i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                foreach (var inspectedItem in monkey.InspectItems(worryHandler))
                {
                    monkeys[inspectedItem.Recipient].CatchItem(inspectedItem.Item);
                }
            }            
        }

        var topMonkeys = monkeys.OrderByDescending(m => m.ItemsInspectedCount)
            .Take(2)
            .ToList();

        return (ulong)topMonkeys[0].ItemsInspectedCount * (ulong)topMonkeys[1].ItemsInspectedCount;
    }
}