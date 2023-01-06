namespace AdventOfCode2022.Solutions.DayTwelve;

/// <summary>
/// Inspired by https://www.koderdojo.com/blog/breadth-first-search-and-shortest-path-in-csharp-and-net-core
/// </summary>
public static class DayTwelve
{
    public static int FindFewestStepsToGoal(string[] input)
    {
        var terrainMap = new TerrainMap(input, 'S', 'E');
        var edges = new List<Tuple<Point, Point>>();
        
        foreach (var point in terrainMap.Points)
        {
            edges.AddRange(point.GetEdges(terrainMap.Points));
        }
        
        var graph = new Graph<Point>(terrainMap.Points, edges);

        var shortestPath = BreadthFirstSearcher.Search(graph, terrainMap.Start!);

        foreach (var vertex in terrainMap.Points)
        {
            Console.WriteLine("shortest path to {0,2}: {1}", vertex, string.Join(", ", shortestPath(vertex)));
        }

        return shortestPath(terrainMap.End!).Count();
    }

    public static void TestThing()
    {
        var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var edges = new[]
        {
            Tuple.Create(1, 2), Tuple.Create(1, 3),
            Tuple.Create(2, 4), Tuple.Create(3, 5), Tuple.Create(3, 6),
            Tuple.Create(4, 7), Tuple.Create(5, 7), Tuple.Create(5, 8),
            Tuple.Create(5, 6), Tuple.Create(8, 9), Tuple.Create(9, 10)
        };

        var graph = new Graph<int>(vertices, edges);

        var shortestPath = BreadthFirstSearcher.Search(graph, 1);
        foreach (var vertex in vertices)
        {
            Console.WriteLine("shortest path to {0,2}: {1}", vertex, string.Join(", ", shortestPath(vertex)));
        }

    }
}
