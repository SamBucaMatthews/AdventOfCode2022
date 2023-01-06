namespace AdventOfCode2022.Solutions.DayTwelve;

public static class DayTwelve
{
    public static int FindFewestStepsToGoal(string[] input, char[] startingLetters)
    {
        var fewestSteps = int.MaxValue;
        
        var terrainMap = new TerrainMap(input, startingLetters, 'E');
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

        foreach (var startingPosition in terrainMap.StartingPositions)
        {
            var findShortestPath = BreadthFirstSearcher.Search(graph, startingPosition);
            try
            {
                var stepsToGoal = findShortestPath(terrainMap.End!).Count() - 1;

                if (stepsToGoal < fewestSteps)
                {
                    fewestSteps = stepsToGoal;
                }
            }
            catch (EndNotReachedException)
            {
            }
        }

        return fewestSteps;
    }
}
