namespace AdventOfCode2022.Solutions.DayEleven;

public class Monkey
{
    private readonly Queue<ulong> _items;
    private readonly Func<ulong, ulong> _operation;
    private readonly Func<int, ulong, int> _throwToTest;

    public int Divisor { get; }

    public int ItemsInspectedCount { get; private set; }

    public Monkey(
        Queue<ulong> items,
        Func<ulong, ulong> operation,
        Func<int, ulong, int> throwToTest,
        int divisor)
    {
        _items = items;
        _operation = operation;
        _throwToTest = throwToTest;
        Divisor = divisor;
    }

    public void CatchItem(ulong item)
        => _items.Enqueue(item);

    public IEnumerable<(ulong Item, int Recipient)> InspectItems(Func<ulong, ulong> worryHandler)
    {
        var inspectedItems = new List<(ulong Item, int Recipient)>();

        while (_items.Any())
        {
            var item = _items.Dequeue();

            item = _operation(item);
            item = worryHandler(item);

            inspectedItems.Add((item, _throwToTest(Divisor, item)));
            ItemsInspectedCount++;
        }

        return inspectedItems;
    }
}
