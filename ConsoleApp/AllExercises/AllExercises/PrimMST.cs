using System;

namespace AllExercises
{
    /// <summary>
    /// Prim's Algorithm to find the Minimum Spanning Tree (MST) of a connected,
    /// undirected, weighted graph using an adjacency matrix.
    /// Greedily expands the MST by always picking the vertex with the lowest edge cost.
    /// </summary>
    public class PrimMST
    {
        /// <summary>
        /// Main method to find the total weight of MST using Prim's algorithm.
        /// </summary>
        /// <param name="graph">Adjacency matrix of the graph</param>
        /// <returns>Total weight of the MST</returns>
        public int FindMST(int[,] graph)
        {
            int V = graph.GetLength(0);
            int[] parent = new int[V];         // parent[i] holds the parent of vertex i in MST
            int[] key = new int[V];            // key[i] holds the minimum weight to connect i to MST
            bool[] inMST = new bool[V];        // inMST[i] is true if vertex i is included in MST

            // Step 1: Initialize keys to infinity and MST as empty
            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                inMST[i] = false;
            }

            key[0] = 0;        // Start from vertex 0
            parent[0] = -1;    // Root of MST has no parent

            Console.WriteLine("Building Minimum Spanning Tree using Prim's Algorithm:\n");

            // Step 2: Build MST with V-1 edges
            for (int count = 0; count < V - 1; count++)
            {
                int u = SelectMinKeyVertex(key, inMST);  // Choose vertex with min key not yet included
                inMST[u] = true;

                // Step 3: Update key and parent of neighbors of u
                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && !inMST[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Vertex {u + 1} added to MST");
                Console.ResetColor();
            }

            // Step 4: Display MST edges and total weight
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Minimum Spanning Tree (MST) Constructed:");
            int totalWeight = 0;
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine($"   ({parent[i] + 1} --{graph[i, parent[i]]}--> {i + 1})");
                totalWeight += graph[i, parent[i]];
            }
            Console.WriteLine($"\n Total Weight of MST: {totalWeight}");
            Console.ResetColor();

            return totalWeight;
        }

        /// <summary>
        /// Selects the vertex with the minimum key value from the set of vertices
        /// not yet included in the MST.
        /// </summary>
        private int SelectMinKeyVertex(int[] key, bool[] inMST)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < key.Length; v++)
            {
                if (!inMST[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}
