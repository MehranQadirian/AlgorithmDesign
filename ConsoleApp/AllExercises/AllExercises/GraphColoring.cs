using System;

namespace AllExercises
{
    /// <summary>
    /// Solves the M-Coloring problem using backtracking.
    /// Determines whether it's possible to color a graph with at most M colors
    /// such that no two adjacent vertices have the same color.
    /// </summary>
    public class GraphColoring
    {
        /// <summary>
        /// Attempts to color the graph and prints the result.
        /// </summary>
        /// <param name="graph">Adjacency matrix of the graph</param>
        /// <param name="maxColors">Maximum number of colors allowed</param>
        /// <returns>True if a valid coloring exists, otherwise false</returns>
        public bool Solve(int[,] graph, int maxColors)
        {
            int numVertices = graph.GetLength(0);
            int[] colors = new int[numVertices];

            bool isSolvable = TryColoring(graph, maxColors, colors, 0);

            Console.WriteLine("\n--- Graph Coloring Result ---");
            if (isSolvable)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Success: The graph was colored using {maxColors} color(s).");
                Console.ResetColor();

                for (int i = 0; i < numVertices; i++)
                {
                    Console.WriteLine($"Vertex {i + 1}: Color {colors[i]}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failure: The graph cannot be colored using only {maxColors} color(s).");
                Console.ResetColor();
            }

            return isSolvable;
        }

        /// <summary>
        /// Recursively tries to assign colors to each vertex using backtracking.
        /// </summary>
        private bool TryColoring(int[,] graph, int maxColors, int[] colors, int vertex)
        {
            int totalVertices = graph.GetLength(0);

            // Base case: all vertices are colored
            if (vertex == totalVertices)
                return true;

            for (int color = 1; color <= maxColors; color++)
            {
                if (IsColorValid(graph, colors, vertex, color))
                {
                    colors[vertex] = color;

                    if (TryColoring(graph, maxColors, colors, vertex + 1))
                        return true;

                    // Backtrack
                    colors[vertex] = 0;
                }
            }

            // No valid color found
            return false;
        }

        /// <summary>
        /// Checks whether assigning a specific color to a vertex is valid.
        /// </summary>
        private bool IsColorValid(int[,] graph, int[] colors, int vertex, int proposedColor)
        {
            int totalVertices = graph.GetLength(0);

            for (int neighbor = 0; neighbor < totalVertices; neighbor++)
            {
                if (graph[vertex, neighbor] == 1 && colors[neighbor] == proposedColor)
                    return false;
            }

            return true;
        }
    }
}
