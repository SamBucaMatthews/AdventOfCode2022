namespace AdventOfCode2022.Solutions.DayEleven;

public class Monkey
{
    private readonly Queue<int> _items;
    private readonly Func<int, int> _operation;
    private readonly Func<int, int> _throwToTest;

    public int ItemsInspectedCount { get; private set; }

    public Monkey(
        Queue<int> items,
        Func<int, int> operation,
        Func<int, int> throwToTest)
    {
        _items = items;
        _operation = operation;
        _throwToTest = throwToTest;
    }

    public void CatchItem(int item)
        => _items.Enqueue(item);

    public IEnumerable<(int Item, int Recipient)> InspectItems()
    {
        var inspectedItems = new List<(int Item, int Recipient)>();

        while (_items.Any())
        {
            var item = _items.Dequeue();

            item = _operation(item);
            item /= 3;

            inspectedItems.Add((item, _throwToTest(item)));
            ItemsInspectedCount++;
        }

        return inspectedItems;
    }
}
