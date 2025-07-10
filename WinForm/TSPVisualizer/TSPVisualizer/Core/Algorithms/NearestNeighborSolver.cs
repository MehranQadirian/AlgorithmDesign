using System.Collections.Generic;
using TSPVisualizer.Core;
using TSPVisualizer.Core.Algorithms;
using TSPVisualizer.Models;

public class NearestNeighborSolver : ITspSolver
{
    public string Name => "Nearest Neighbor";

    public List<City> FindPath(List<City> cities)
    {
        if (cities.Count == 0) return new List<City>();

        var visited = new HashSet<City>();
        var path = new List<City>();
        var current = cities[0];
        path.Add(current);
        visited.Add(current);

        while (visited.Count < cities.Count)
        {
            City nearest = null;
            double minDist = double.MaxValue;

            foreach (var c in cities)
            {
                if (!visited.Contains(c))
                {
                    double dist = GraphManager.CalculateDistance(current, c);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        nearest = c;
                    }
                }
            }

            if (nearest != null)
            {
                path.Add(nearest);
                visited.Add(nearest);
                current = nearest;
            }
        }

        return path;
    }
}
