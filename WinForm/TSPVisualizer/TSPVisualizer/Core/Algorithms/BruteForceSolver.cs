using System;
using System.Collections.Generic;
using System.Linq;
using TSPVisualizer.Models;

namespace TSPVisualizer.Core.Algorithms
{
    public class BruteForceSolver : ITspSolver
    {
        public string Name => "Brute Force";

        public List<City> FindPath(List<City> cities)
        {
            if (cities.Count <= 1)
                return cities;

            var bestPath = new List<City>();
            double minLength = double.MaxValue;

            foreach (var perm in GetPermutations(cities.Skip(1).ToList()))
            {
                var currentPath = new List<City> { cities[0] };
                currentPath.AddRange(perm);
                double length = GetPathLength(currentPath);

                if (length < minLength)
                {
                    minLength = length;
                    bestPath = new List<City>(currentPath);
                }
            }

            return bestPath;
        }

        private double GetPathLength(List<City> path)
        {
            double total = 0;
            for (int i = 0; i < path.Count - 1; i++)
                total += GraphManager.CalculateDistance(path[i], path[i + 1]);

            total += GraphManager.CalculateDistance(path[path.Count - 1], path[0]); 
            return total;
        }

        private IEnumerable<List<City>> GetPermutations(List<City> list)
        {
            if (list.Count == 1)
                yield return new List<City>(list);
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var first = list[i];
                    var remaining = new List<City>(list);
                    remaining.RemoveAt(i);

                    foreach (var perm in GetPermutations(remaining))
                    {
                        perm.Insert(0, first);
                        yield return perm;
                    }
                }
            }
        }
    }
}
