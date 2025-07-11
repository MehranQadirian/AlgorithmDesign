using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllExercises
{
    class Program
    {

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n*** Algorithms Menu ***");
                Console.WriteLine("1. Multiplying Large Numbers");
                Console.WriteLine("2. Prim's Algorithm (Minimum Spanning Tree)");
                Console.WriteLine("3. Kruskal's Algorithm (Minimum Spanning Tree)");
                Console.WriteLine("4. Huffman Algorithm (Compression)");
                Console.WriteLine("5. N-Minister's Problem");
                Console.WriteLine("6. Subset Sum");
                Console.WriteLine("7. Graph Coloring");
                Console.WriteLine("8. Floyd-Warshall Algorithm");
                Console.WriteLine("0. Exit");
                Console.ForegroundColor = ConsoleColor.White;


                Console.Write("\nPlease enter the number of the desired algorithm: ");
                var key = Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                switch (key.KeyChar)
                {
                    case '1':
                        RunBigNumberMultiplication();
                        break;
                    case '2':
                        RunPrimMST();
                        break;
                    case '3':
                        RunKruskalMST();
                        break;
                    case '4':
                        RunHuffmanCoding();
                        break;
                    case '5':
                        RunNQueens();
                        break;
                    case '6':
                        RunSubsetSum();
                        break;
                    case '7':
                        RunGraphColoring();
                        break;
                    case '8':
                        RunFloydWarshall();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Invalid option!Please select a number from 0 to 8.");
                        break;
                }

                Console.WriteLine("\nPress a key to return to the main menu...");
                Console.ReadLine();
                int total = 100;
                Console.WriteLine("Processing...");
                for (int i = 0; i <= total; i++)
                {
                    Console.Write($"\rProgress: {i}% [");
                    int progress = (i * 50) / total;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string('#', progress));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(new string('-', 50 - progress));
                    Console.Write("]");
                    Thread.Sleep(5);
                }
                Console.WriteLine("\nDone!");
            }
        }

        static void RunBigNumberMultiplication()
        {
            var multiplier = new BigNumberMultiplier();

            Console.WriteLine("\nMultiplying big numbers:");
            Console.Write("Enter first number: ");
            string num1 = Console.ReadLine();
            Console.Write("Enter second number: ");
            string num2 = Console.ReadLine();

            Console.WriteLine($"\nResult: {num1} × {num2} = {multiplier.Multiply(num1, num2)}");
        }
        static void RunPrimMST()
        {
            int[,] graph = {
            {0, 2, 0, 6, 0},
            {2, 0, 3, 8, 5},
            {0, 3, 0, 0, 7},
            {6, 8, 0, 0, 9},
            {0, 5, 7, 9, 0}
        };

            var prim = new PrimMST();
            Console.WriteLine("\n Total weight of minimum spanning tree (prime): " + prim.FindMST(graph));
        }

        static void RunKruskalMST()
        {
            int[,] graph = {
            {0, 2, 0, 6, 0},
            {2, 0, 3, 8, 5},
            {0, 3, 0, 0, 7},
            {6, 8, 0, 0, 9},
            {0, 5, 7, 9, 0}
        };

            var kruskal = new KruskalMST();
            Console.WriteLine("\nTotal weight of the minimum spanning tree (Kruskal): " + kruskal.FindMST(graph));
        }

        static void RunHuffmanCoding()
        {
            Console.Write("\nEnter the text to be Huffman-compressed: ");
            string text = Console.ReadLine();

            var huffman = new HuffmanCoding();
            var codes = huffman.Encode(text);

            Console.WriteLine("\nHuffman codes:");
            foreach (var code in codes)
            {
                Console.WriteLine($"'{code.Key}': {code.Value}");
            }
        }

        static void RunNQueens()
        {
            Console.Write("Enter the number of queens (N): ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            var solver = new NQueensSolver();

            Console.WriteLine($"\nA solution to the {n} queen problem:");
            solver.Solve(n);
        }

        static void RunSubsetSum()
        {
            int[] set = { 3, 34, 4, 12, 5, 2 };
            Console.WriteLine("\nSet of numbers: " + string.Join(", ", set));

            Console.Write("Enter the target sum: ");
            int sum = int.Parse(Console.ReadLine());

            var subsetSum = new SubsetSum();
            Console.WriteLine($"\nIs there a subset with sum {sum}? {subsetSum.IsSubsetSum(set, sum)}");
        }

        static void RunGraphColoring()
        {
            int[,] graph = {
            {0, 1, 1, 1},
            {1, 0, 1, 0},
            {1, 1, 0, 1},
            {1, 0, 1, 0}
        };

            Console.Write("\nEnter the number of available colors: ");
            int m = int.Parse(Console.ReadLine());

            var coloring = new GraphColoring();
            coloring.CanColor(graph, m);
        }

        static void RunFloydWarshall()
        {
            int[,] graph = {
            {0, 5, int.MaxValue, 10},
            {int.MaxValue, 0, 3, int.MaxValue},
            {int.MaxValue, int.MaxValue, 0, 1},
            {int.MaxValue, int.MaxValue, int.MaxValue, 0}
        };

            Console.WriteLine("\nInput graph:");
            PrintGraph(graph);

            var floyd = new FloydWarshall();
            floyd.FindShortestPaths(graph);
        }

        static void PrintGraph(int[,] graph)
        {
            int V = graph.GetLength(0);
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (graph[i, j] == int.MaxValue)
                        Console.Write("INF\t");
                    else
                        Console.Write(graph[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

