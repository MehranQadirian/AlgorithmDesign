using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercises
{
    public class FloydWarshall
    {
        public void FindShortestPaths(int[,] graph)
        {
            int V = graph.GetLength(0);
            int[,] dist = new int[V, V];

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    dist[i, j] = graph[i, j];
                }
            }

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

            PrintSolution(dist);
        }

        private void PrintSolution(int[,] dist)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int V = dist.GetLength(0);
            Console.WriteLine("The shortest path between any pair of vertices:");

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
