namespace AdventOfCode2022.Solutions.DayTwelve;

public static class DayTwelve
{
    public static int FindFewestStepsToGoal(string[] input)
    {
        var terrainMap = new TerrainMap(input, 'S', 'E');
        var edges = new List<Tuple<Point, Point>>();
        
        foreach (var point in terrainMap.Points)
        {
            var potentialEdges = point.GetNeighbours(terrainMap.Points);
            
            foreach (var potentialEdge in potentialEdges)
            {
                if (potentialEdge?.Height <= point.Height + 1)
                {
                    edges.Add(Tuple.Create(point, potentialEdge));
                }
            }
        }
        
        var graph = new Graph<Point>(terrainMap.Points, edges);
        var findShortestPath = BreadthFirstSearcher.Search(graph, terrainMap.Start!);

        return findShortestPath(terrainMap.End!).Count() - 1;
    }
}
