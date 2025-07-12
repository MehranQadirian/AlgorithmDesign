using System;

namespace AllExercises
{
    /// <summary>
    /// Implements Floyd-Warshall algorithm to find the shortest paths
    /// between all pairs of vertices in a weighted graph.
    /// </summary>
    public class FloydWarshall
    {
        /// <summary>
        /// Finds shortest paths using Floyd-Warshall algorithm and prints the result.
        /// </summary>
        /// <param name="graph">Adjacency matrix where graph[i,j] is the weight of edge i→j,
        /// or int.MaxValue if there is no direct edge.</param>
        public int[,] FindShortestPaths(int[,] graph)
        {
            int V = graph.GetLength(0);
            int[,] dist = new int[V, V];

            // Initialize distance matrix from input graph
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }

            // Floyd-Warshall core
            for (int k = 0; k < V; k++)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        if (dist[i, k] != int.MaxValue &&
                            dist[k, j] != int.MaxValue &&
                            dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            return dist;
        }

        /// <summary>
        /// Prints the shortest path matrix.
        /// </summary>
        /// <param name="dist">Final distance matrix</param>
        private void PrintSolution(int[,] dist)
        {
            int V = dist.GetLength(0);
            Console.WriteLine("The shortest path between any pair of vertices :");

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (dist[i, j] == int.MaxValue)
                        Console.Write("INF ");
                    else
                        Console.Write(dist[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
