using System;
using System.Linq;
using System.Text;

namespace AllExercises
{
    public class FloydWarshall
    {
        public void FindShortestPaths(int[,] graph)
        {
            Console.WriteLine("\n=== Input Graph ===");
            PrintGraph(graph);

            // Validate input
            if (graph == null)
            {
                Console.WriteLine("Error: Graph is null");
                return;
            }

            int V = graph.GetLength(0);

            if (V == 0 || V != graph.GetLength(1))
            {
                Console.WriteLine("Error: Invalid graph dimensions");
                return;
            }

            // Initialize distance matrix and path tracking
            int[,] dist = new int[V, V];
            int[,] next = new int[V, V];

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dist[i, j] = graph[i, j];
                    if (graph[i, j] != int.MaxValue && i != j)
                        next[i, j] = j;
                    else
                        next[i, j] = -1;
                }
            }

            // Floyd-Warshall algorithm
            for (int k = 0; k < V; k++)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, k] != int.MaxValue &&
                            dist[k, j] != int.MaxValue &&
                            (dist[i, j] > dist[i, k] + dist[k, j]))
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            // Check for negative cycles
            for (int i = 0; i < V; i++)
            {
                if (dist[i, i] < 0)
                {
                    Console.WriteLine("\nWarning: Graph contains negative weight cycle");
                    return;
                }
            }

            Console.WriteLine("\n=== Shortest Path Distances ===");
            PrintSolution(dist);

            Console.WriteLine("\n=== Path Reconstruction ===");
            PrintAllPaths(next, dist);
        }

        public static void PrintGraph(int[,] graph)
        {
            int V = graph.GetLength(0);
            Console.WriteLine("Vertex\t" + string.Join("\t", Enumerable.Range(1, V)));
            Console.WriteLine(new string('-', 8 * (V + 1)));

            for (int i = 0; i < V; i++)
            {
                Console.Write($"{i + 1}\t");
                for (int j = 0; j < V; j++)
                {
                    Console.Write(graph[i, j] == int.MaxValue ? "INF\t" : $"{graph[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        private void PrintSolution(int[,] dist)
        {
            int V = dist.GetLength(0);
            Console.WriteLine("Vertex\t" + string.Join("\t", Enumerable.Range(1, V)));
            Console.WriteLine(new string('-', 8 * (V + 1)));

            for (int i = 0; i < V; i++)
            {
                Console.Write($"{i + 1}\t");
                for (int j = 0; j < V; j++)
                {
                    Console.Write(dist[i, j] == int.MaxValue ? "INF\t" : $"{dist[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        private void PrintAllPaths(int[,] next, int[,] dist)
        {
            int V = next.GetLength(0);

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (i != j && next[i, j] != -1)
                    {
                        Console.Write($"Path from {i + 1} to {j + 1} (Distance: ");
                        Console.Write(dist[i, j] == int.MaxValue ? "INF): " : $"{dist[i, j]}): ");
                        PrintPath(i, j, next);
                        Console.WriteLine();
                    }
                }
            }
        }

        private void PrintPath(int i, int j, int[,] next)
        {
            if (next[i, j] == -1)
            {
                Console.Write("No path");
                return;
            }

            Console.Write($"{i + 1} -> ");
            while (i != j)
            {
                i = next[i, j];
                Console.Write($"{i + 1}");
                if (i != j) Console.Write(" -> ");
            }
        }
    }
}