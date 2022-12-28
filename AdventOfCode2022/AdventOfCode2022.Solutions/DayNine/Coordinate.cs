namespace AdventOfCode2022.Solutions.DayNine;

public class Coordinate : IEquatable<Coordinate>
{
    public int X { get; set; }

    public int Y { get; set; }

    public bool Equals(Coordinate? other) =>
        !ReferenceEquals(null,
            other) &&
        (ReferenceEquals(this,
             other) ||
         X == other.X && Y == other.Y);

    public override bool Equals(object? obj) =>
        !ReferenceEquals(null,
            obj) &&
        (ReferenceEquals(this,
             obj) ||
         obj.GetType() == GetType() && Equals((Coordinate)obj));

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public override string ToString() => $"({X}, {Y})";

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }
}
