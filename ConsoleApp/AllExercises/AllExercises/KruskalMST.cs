﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercises
{
    public class KruskalMST
    {
        class Edge : IComparable<Edge>
        {
            public int Source, Destination, Weight;

            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }
        }

        class Subset
        {
            public int Parent, Rank;
        }

        public int FindMST(int[,] graph)
        {
            int V = graph.GetLength(0);
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < V; i++)
            {
                for (int j = i + 1; j < V; j++)
                {
                    if (graph[i, j] != 0)
                    {
                        edges.Add(new Edge
                        {
                            Source = i,
                            Destination = j,
                            Weight = graph[i, j]
                        });
                    }
                }
            }

            edges.Sort();

            Subset[] subsets = new Subset[V];
            for (int i = 0; i < V; i++)
            {
                subsets[i] = new Subset { Parent = i, Rank = 0 };
            }

            int totalWeight = 0;
            foreach (Edge edge in edges)
            {
                int x = Find(subsets, edge.Source);
                int y = Find(subsets, edge.Destination);

                if (x != y)
                {
                    totalWeight += edge.Weight;
                    Union(subsets, x, y);
                }
            }

            return totalWeight;
        }

        private int Find(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
                subsets[i].Parent = Find(subsets, subsets[i].Parent);

            return subsets[i].Parent;
        }

        private void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].Rank < subsets[yroot].Rank)
                subsets[xroot].Parent = yroot;
            else if (subsets[xroot].Rank > subsets[yroot].Rank)
                subsets[yroot].Parent = xroot;
            else
            {
                subsets[yroot].Parent = xroot;
                subsets[xroot].Rank++;
            }
        }
    }
}
