using System;
using System.Collections.Generic;
using System.Linq;
using TSPVisualizer.Models;

namespace TSPVisualizer.Core.Algorithms
{
    public class GeneticSolver : ITspSolver
    {
        public string Name => "Genetic Algorithm";

        private Random rand = new Random();
        private int populationSize = 100;
        private int generations = 500;
        private double mutationRate = 0.05;

        public List<City> FindPath(List<City> cities)
        {
            if (cities.Count <= 1) return cities;

            var population = GenerateInitialPopulation(cities);
            List<City> best = null;

            for (int gen = 0; gen < generations; gen++)
            {
                population = population.OrderBy(GetPathLength).ToList();
                best = population[0];

                var newPop = new List<List<City>>();
                newPop.Add(best); 

                while (newPop.Count < populationSize)
                {
                    var parent1 = TournamentSelection(population);
                    var parent2 = TournamentSelection(population);

                    var child = Crossover(parent1, parent2);
                    if (rand.NextDouble() < mutationRate)
                        Mutate(child);

                    newPop.Add(child);
                }

                population = newPop;
            }

            return best;
        }

        private List<List<City>> GenerateInitialPopulation(List<City> cities)
        {
            var pop = new List<List<City>>();
            for (int i = 0; i < populationSize; i++)
            {
                var shuffled = cities.ToList();
                shuffled = shuffled.OrderBy(x => rand.Next()).ToList();
                pop.Add(shuffled);
            }
            return pop;
        }

        private List<City> TournamentSelection(List<List<City>> pop)
        {
            var candidates = new List<List<City>>();
            for (int i = 0; i < 5; i++)
                candidates.Add(pop[rand.Next(pop.Count)]);

            return candidates.OrderBy(GetPathLength).First();
        }

        private List<City> Crossover(List<City> parent1, List<City> parent2)
        {
            int start = rand.Next(parent1.Count);
            int end = rand.Next(start, parent1.Count);

            var child = new List<City>();
            var segment = parent1.GetRange(start, end - start);

            child.AddRange(segment);

            foreach (var city in parent2)
            {
                if (!child.Contains(city))
                    child.Add(city);
            }

            return child;
        }

        private void Mutate(List<City> path)
        {
            int i = rand.Next(path.Count);
            int j = rand.Next(path.Count);
            (path[i], path[j]) = (path[j], path[i]);
        }

        private double GetPathLength(List<City> path)
        {
            double total = 0;
            for (int i = 0; i < path.Count - 1; i++)
                total += GraphManager.CalculateDistance(path[i], path[i + 1]);
            total += GraphManager.CalculateDistance(path[path.Count - 1], path[0]); 
            return total;
        }
    }
}
