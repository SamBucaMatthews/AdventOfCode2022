namespace AdventOfCode2022.Solutions.DayTwelve;

public class Graph<T> where T : notnull
{
    public Graph()
    {
    }

    public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
    {
        foreach (var vertex in vertices)
        {
            AddVertex(vertex);
        }

        foreach (var edge in edges)
        {
            AddEdge(edge);
        }
    }

    public Dictionary<T, HashSet<T>> AdjacencyMatrix { get; } = new();

    public void AddVertex(T vertex)
    {
        AdjacencyMatrix[vertex] = new HashSet<T>();
    }

    public void AddEdge(Tuple<T, T> edge)
    {
        if (!AdjacencyMatrix.TryGetValue(edge.Item1, out var vertex1) ||
            !AdjacencyMatrix.TryGetValue(edge.Item2, out var vertex2))
        {
            return;
        }

        vertex1.Add(edge.Item2);
        vertex2.Add(edge.Item1);
    }
}
