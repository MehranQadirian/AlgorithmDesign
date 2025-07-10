using System;
using System.Collections.Generic;
using TSPVisualizer.Models;

namespace TSPVisualizer.Core
{
    // مدیریت لیست شهرها و ارتباطات بین آنها
    public class GraphManager
    {
        public List<City> Cities { get; private set; } = new List<City>();

        public void AddCity(City city)
        {
            Cities.Add(city);
        }

        public void RemoveCity(City city)
        {
            Cities.Remove(city);
        }

        public void ClearAll()
        {
            Cities.Clear();
        }
        public List<(City, City, double)> GetAllEdges()
        {
            var edges = new List<(City, City, double)>();
            for (int i = 0; i < Cities.Count; i++)
            {
                for (int j = i + 1; j < Cities.Count; j++)
                {
                    double dist = CalculateDistance(Cities[i], Cities[j]);
                    edges.Add((Cities[i], Cities[j], dist));
                }
            }
            return edges;
        }

        public static double CalculateDistance(City c1, City c2)
        {
            double dx = c1.Location.X - c2.Location.X;
            double dy = c1.Location.Y - c2.Location.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

    }
}
