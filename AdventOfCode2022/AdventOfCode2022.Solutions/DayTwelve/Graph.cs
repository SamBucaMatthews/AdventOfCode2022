namespace AdventOfCode2022.Solutions.DayTwelve;

public class Graph<T> where T : notnull
{
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

    private void AddVertex(T vertex)
    {
        AdjacencyMatrix[vertex] = new HashSet<T>();
    }

    private void AddEdge(Tuple<T, T> edge)
    {
        if (!AdjacencyMatrix.TryGetValue(edge.Item1, out var vertex1))
        {
            return;
        }

        vertex1.Add(edge.Item2);
    }
}
