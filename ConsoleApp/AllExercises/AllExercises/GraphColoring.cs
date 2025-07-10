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
            int V = graph.GetLength(0);
            int[] color = new int[V];

            if (GraphColoringUtil(graph, m, color, 0, V))
            {
                Console.WriteLine("راه حل رنگ‌آمیزی:");
                for (int i = 0; i < V; i++)
                    Console.WriteLine($"رأس {i + 1}: رنگ {color[i]}");
                return true;
            }

            Console.WriteLine("راه حلی وجود ندارد");
            return false;
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
