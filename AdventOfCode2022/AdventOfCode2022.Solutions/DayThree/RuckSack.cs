namespace AdventOfCode2022.Solutions.DayThree;

public class RuckSack
{
    public List<Compartment> Compartments { get; }

    public RuckSack(string input)
    {
        Compartments = TwoPartRuckSack(input);
    }

    private static List<Compartment> TwoPartRuckSack(string input)
    {
        var firstHalfLength = input.Length / 2;
        var secondHalfLength = input.Length - firstHalfLength;

        var compartmentOneString = input.Substring(0, firstHalfLength);
        var compartmentTwoString = input.Substring(firstHalfLength, secondHalfLength);

        var compartmentOneItems = compartmentOneString.Select(i => new Compartment.Item(i.ToString())).ToList();
        var compartmentTwoItems = compartmentTwoString.Select(i => new Compartment.Item(i.ToString())).ToList();

        var compartments = new List<Compartment>
        {
            new(compartmentOneItems),
            new(compartmentTwoItems)
        };
        return compartments;
    }

    public class Compartment
    {
        public Compartment(List<Item> items)
        {
            Items = items;
        }

        public List<Item> Items { get; }

        public class Item
        {
            public Item(string type) => Type = type;

            public string Type { get; }
            
            private bool Equals(Item other) => Type == other.Type;

            public override bool Equals(object? obj) =>
                !ReferenceEquals(null, obj) &&
                (ReferenceEquals(this, obj) ||
                 obj.GetType() == GetType() && Equals((Item)obj));

            public override int GetHashCode() => Type.GetHashCode();
        }
    }
}
