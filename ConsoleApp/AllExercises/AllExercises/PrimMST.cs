using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercises
{
    public class PrimMST
    {
        public int FindMST(int[,] graph)
        {
            PrintGraph(graph);
            int V = graph.GetLength(0);
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            int totalWeight = 0;
            for (int i = 1; i < V; i++)
            {
                totalWeight += graph[i, parent[i]];
            }

            return totalWeight;
        }

        public static void PrintGraph(int[,] graph)
        {
            int V = graph.GetLength(0);
            Console.WriteLine("Graph Matrix (Row: Source, Column: Destination):");
            Console.WriteLine("================================================\n\n");

            // Print column headers
            Console.Write("\t");
            for (int j = 0; j < V; j++)
            {
                Console.Write($"{j+1}\t");
            }
            Console.WriteLine("\n" + new string('-', (V + 1) * 8));

            // Print rows
            for (int i = 0; i < V; i++)
            {
                Console.Write($"  |\t" + '\n');
                Console.Write($"{i+1} |\t");
                for (int j = 0; j < V; j++)
                {
                    if (graph[i, j] == int.MaxValue)
                        Console.Write("INF\t");
                    else
                        Console.Write(graph[i, j] + "\t");
                }
                Console.WriteLine('\n' + $"  |\t" + '\n' + $"  |\t");
            }
        }
        private int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < key.Length; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}
