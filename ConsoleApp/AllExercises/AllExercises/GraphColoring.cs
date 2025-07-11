using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercises
{
    public class GraphColoring
    {

        public bool CanColor(int[,] graph, int m)
        {
            PrintGraph(graph);
            Console.OutputEncoding = Encoding.UTF8;

            if (m < 1)
            {
                Console.WriteLine("Number of colors must be at least 1");
                return false;
            }

            int V = graph.GetLength(0);
            int[] color = new int[V];

            if (GraphColoringUtil(graph, m, color, 0, V))
            {

                Console.WriteLine("Coloring solution:");
                for (int i = 0; i < V; i++)
                    Console.WriteLine($"Vertex {i + 1}: color {color[i]}");
                return true;
            }

            Console.WriteLine("There is no solution");
            return false;
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
                Console.Write($"{j + 1}\t");
            }
            Console.WriteLine("\n" + new string('-', (V + 1) * 8));

            // Print rows
            for (int i = 0; i < V; i++)
            {
                Console.Write($"  |\t" + '\n');
                Console.Write($"{i + 1} |\t");
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
        private bool GraphColoringUtil(int[,] graph, int m, int[] color, int v, int V)
        {
            if (v == V)
                return true;

            for (int c = 1; c <= m; c++)
            {
                if (IsSafe(graph, color, v, c, V))
                {
                    color[v] = c;

                    if (GraphColoringUtil(graph, m, color, v + 1, V))
                        return true;

                    color[v] = 0;
                }
            }

            return false;
        }

        private bool IsSafe(int[,] graph, int[] color, int v, int c, int V)
        {
            for (int i = 0; i < V; i++)
            {
                if (graph[v, i] == 1 && color[i] == c)
                    return false;
            }
            return true;
        }
    }
}
