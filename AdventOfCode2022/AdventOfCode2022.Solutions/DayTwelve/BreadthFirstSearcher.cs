namespace AdventOfCode2022.Solutions.DayTwelve;

/// <summary>
/// Inspired by https://www.koderdojo.com/blog/breadth-first-search-and-shortest-path-in-csharp-and-net-core
/// </summary>
public static class BreadthFirstSearcher
{
    public static Func<T, IEnumerable<T>> Search<T>(Graph<T> graph, T start) where T : notnull
    {
        var previous = new Dictionary<T, T>();

        var queue = new Queue<T>();
        queue.Enqueue(start);

        while (queue.Any())
        {
            var vertex = queue.Dequeue();

            foreach (var neighbour in graph.AdjacencyMatrix[vertex])
            {
                if (previous.ContainsKey(neighbour))
                {
                    continue;
                }

                previous[neighbour] = vertex;
                queue.Enqueue(neighbour);
            }
        }

        IEnumerable<T> SolveShortestPath(T v)
        {
            var path = new List<T>();

            var current = v;

            while (!current.Equals(start))
            {
                path.Add(current);
                current = previous[current];
            }

            path.Add(start);
            path.Reverse();

            return path;
        }

        return SolveShortestPath;
    }
}
