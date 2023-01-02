namespace AdventOfCode2022.Solutions.DayEleven;

public static class DayEleven
{
    public static int GetLevelOfMonkeyBusiness()
    {
        // TODO: Parse from input (Manually writing 8 Monkeys wasn't too painful)
        var monkeys = new[]
        {
            new Monkey(
                new Queue<int>(new []{ 54, 53 }),
                old => old * 3,
                item => item % 2 == 0 ? 2 : 6), // 0
            new Monkey(
                new Queue<int>(new []{ 95, 88, 75, 81, 91, 67, 65, 84 }),
                old => old * 11,
                item => item % 7 == 0 ? 3 : 4), // 1
            new Monkey(
                new Queue<int>(new []{ 76, 81, 50, 93, 96, 81, 83 }),
                old => old + 6,
                item => item % 3 == 0 ? 5 : 1), // 2
            new Monkey(
                new Queue<int>(new []{ 83, 85, 85, 63 }),
                old => old + 4,
                item => item % 11 == 0 ? 7 : 4), // 3
            new Monkey(
                new Queue<int>(new []{ 85, 52, 64 }),
                old => old + 8,
                item => item % 17 == 0 ? 0 : 7), // 4
            new Monkey(
                new Queue<int>(new []{ 57 }),
                old => old + 2,
                item => item % 5 == 0 ? 1 : 3), // 5
            new Monkey(
                new Queue<int>(new []{ 60, 95, 76, 66, 91 }),
                old => old * old,
                item => item % 13 == 0 ? 2 : 5), // 6
            new Monkey(
                new Queue<int>(new []{ 65, 84, 76, 72, 79, 65 }),
                old => old + 5,
                item => item % 19 == 0 ? 6 : 0), // 7
        };

        for (var i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                foreach (var inspectedItem in monkey.InspectItems())
                {
                    monkeys[inspectedItem.Recipient].CatchItem(inspectedItem.Item);
                }
            }            
        }

        var topMonkeys = monkeys.OrderByDescending(m => m.ItemsInspectedCount)
            .Take(2)
            .ToList();

        return topMonkeys[0].ItemsInspectedCount * topMonkeys[1].ItemsInspectedCount;
    }
}