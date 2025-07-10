using System.Collections.Generic;
using TSPVisualizer.Models;

namespace TSPVisualizer.Core.Algorithms
{
    public interface ITspSolver
    {
        List<City> FindPath(List<City> cities);
        string Name { get; }
    }
}
