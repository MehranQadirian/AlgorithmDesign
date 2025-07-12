using System;
using System.Collections.Generic;

namespace AllExercises
{
    /// <summary>
    /// Solves the Minimum Spanning Tree (MST) problem using Kruskal's Algorithm.
    /// Based on the greedy strategy, Kruskal's algorithm builds the MST incrementally
    /// by always choosing the next smallest edge that does not form a cycle.
    /// </summary>
    public class KruskalMST
    {
        /// <summary>
        /// Represents a weighted edge in the graph.
        /// </summary>
        private class Edge : IComparable<Edge>
        {
            public int Source;
            public int Destination;
            public int Weight;

            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }

            public override string ToString()
            {
                return $"({Source + 1} --{Weight}--> {Destination + 1})";
            }
        }

        /// <summary>
        /// Helper structure for Union-Find (Disjoint Set) data structure.
        /// </summary>
        private class Subset
        {
            public int Parent;
            public int Rank;
        }

        /// <summary>
        /// Computes the Minimum Spanning Tree (MST) of the given graph using Kruskal’s algorithm.
        /// </summary>
        /// <param name="graph">Adjacency matrix of the graph</param>
        /// <returns>Total weight of the MST</returns>
        public int FindMST(int[,] graph)
        {
            int V = graph.GetLength(0);
            List<Edge> edges = ExtractEdges(graph);
            edges.Sort(); // Step 1: Sort edges in non-decreasing order by weight

            Subset[] subsets = InitializeSubsets(V);
            List<Edge> mstEdges = new List<Edge>();
            int totalWeight = 0;

            Console.WriteLine("Building Minimum Spanning Tree using Kruskal's Algorithm:\n");

            // Step 2: Iterate through sorted edges and add them if they don’t form a cycle
            foreach (Edge edge in edges)
            {
                int root1 = Find(subsets, edge.Source);
                int root2 = Find(subsets, edge.Destination);

                // If including this edge doesn't cause a cycle, include it in MST
                if (root1 != root2)
                {
                    Union(subsets, root1, root2);
                    mstEdges.Add(edge);
                    totalWeight += edge.Weight;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" Edge Added: {edge}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" Skipped (Cycle Detected): {edge}");
                    Console.ResetColor();
                }

                if (mstEdges.Count == V - 1)
                    break;
            }

            // Output MST Result
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Minimum Spanning Tree (MST) Constructed:");
            foreach (Edge e in mstEdges)
                Console.WriteLine($"   {e}");
            Console.WriteLine($"\n Total Weight of MST: {totalWeight}");
            Console.ResetColor();

            return totalWeight;
        }

        /// <summary>
        /// Extracts edges from the upper triangle of the adjacency matrix to avoid duplicates.
        /// </summary>
        private List<Edge> ExtractEdges(int[,] graph)
        {
            int V = graph.GetLength(0);
            List<Edge> edgeList = new List<Edge>();

            for (int i = 0; i < V; i++)
            {
                for (int j = i + 1; j < V; j++)
                {
                    if (graph[i, j] > 0)
                    {
                        edgeList.Add(new Edge
                        {
                            Source = i,
                            Destination = j,
                            Weight = graph[i, j]
                        });
                    }
                }
            }

            return edgeList;
        }

        /// <summary>
        /// Initializes union-find subsets: each vertex is its own parent.
        /// </summary>
        private Subset[] InitializeSubsets(int V)
        {
            Subset[] subsets = new Subset[V];
            for (int i = 0; i < V; i++)
            {
                subsets[i] = new Subset
                {
                    Parent = i,
                    Rank = 0
                };
            }
            return subsets;
        }

        /// <summary>
        /// Finds the set representative (with path compression).
        /// </summary>
        private int Find(Subset[] subsets, int node)
        {
            if (subsets[node].Parent != node)
                subsets[node].Parent = Find(subsets, subsets[node].Parent);

            return subsets[node].Parent;
        }

        /// <summary>
        /// Performs union of two subsets (by rank).
        /// </summary>
        private void Union(Subset[] subsets, int rootX, int rootY)
        {
            if (subsets[rootX].Rank < subsets[rootY].Rank)
                subsets[rootX].Parent = rootY;
            else if (subsets[rootX].Rank > subsets[rootY].Rank)
                subsets[rootY].Parent = rootX;
            else
            {
                subsets[rootY].Parent = rootX;
                subsets[rootX].Rank++;
            }
        }
    }
}
