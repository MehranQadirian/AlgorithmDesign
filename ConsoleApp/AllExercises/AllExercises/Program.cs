using System;
using System.Linq;

namespace AllExercises
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                PrintMenu();

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
                        Console.WriteLine("\nExiting program. Goodbye!");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option! Please select a number from 0 to 8.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n*** Algorithms Menu ***");
            Console.WriteLine("1. Multiplying Large Numbers");
            Console.WriteLine("2. Prim's Algorithm (Minimum Spanning Tree)");
            Console.WriteLine("3. Kruskal's Algorithm (Minimum Spanning Tree)");
            Console.WriteLine("4. Huffman Algorithm (Compression)");
            Console.WriteLine("5. N-Queens Problem");
            Console.WriteLine("6. Subset Sum Problem");
            Console.WriteLine("7. Graph Coloring");
            Console.WriteLine("8. Floyd-Warshall Algorithm");
            Console.WriteLine("0. Exit");
            Console.ResetColor();
        }

        static void RunBigNumberMultiplication()
        {
            var multiplier = new BigNumberMultiplier();

            Console.WriteLine("=== Multiplying Large Numbers ===");
            Console.Write("Enter the first number: ");
            string num1 = Console.ReadLine();
            Console.Write("Enter the second number: ");
            string num2 = Console.ReadLine();

            string result = multiplier.Multiply(num1, num2);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nResult:\n{num1} × {num2} = {result}");
            Console.ResetColor();
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

            Console.WriteLine("=== Prim's Algorithm: Minimum Spanning Tree ===");
            Console.WriteLine("Input graph (adjacency matrix):");
            PrintGraph(graph);

            int totalWeight = prim.FindMST(graph);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTotal weight of the MST: {totalWeight}");
            Console.ResetColor();
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

            Console.WriteLine("=== Kruskal's Algorithm: Minimum Spanning Tree ===");
            Console.WriteLine("Input graph (adjacency matrix):");
            PrintGraph(graph);

            int totalWeight = kruskal.FindMST(graph);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTotal weight of the MST: {totalWeight}");
            Console.ResetColor();
        }

        static void RunHuffmanCoding()
        {
            Console.WriteLine("=== Huffman Coding (Compression) ===");
            Console.Write("Enter text to compress: ");
            string text = Console.ReadLine();

            var huffman = new HuffmanCoding();
            var codes = huffman.Encode(text);

            Console.WriteLine("\nHuffman codes for each character:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var kvp in codes)
            {
                string key = kvp.Key == ' ' ? "[space]" : kvp.Key.ToString();
                Console.WriteLine($"'{key}': {kvp.Value}");
            }
            Console.ResetColor();
        }

        static void RunNQueens()
        {
            Console.WriteLine("=== N-Queens Problem ===");
            Console.Write("Enter number of queens (N): ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. N must be a positive integer.");
                Console.ResetColor();
                return;
            }

            var solver = new NQueensSolver();
            Console.WriteLine($"\nA solution for {n}-Queens:");
            solver.Solve(n);
        }

        static void RunSubsetSum()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Subset Sum Problem Solver ===");
            Console.ResetColor();

            int[] set;

            Console.WriteLine("\nChoose input method:");
            Console.WriteLine("1. Enter your own set");
            Console.WriteLine("2. Generate random set");
            Console.Write("Your choice (1 or 2): ");

            var choice = Console.ReadKey();

            Random rnd = new Random();
            switch (choice.KeyChar)
            {
                case '1':
                    Console.Write("\nEnter integers separated by spaces: ");
                    string input = Console.ReadLine();
                    try
                    {
                        set = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .Where(x => x > 0)
                                   .ToArray();

                        if (set.Length == 0)
                            throw new Exception("No valid positive integers entered.");
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter only positive integers.");
                        Console.ResetColor();
                        return;
                    }
                    break;
                default:
                    // Generate a random set of positive integers
                    
                    int size = rnd.Next(5, 10); // Length of the set between 5 and 9
                    set = new int[size];
                    for (int i = 0; i < size; i++)
                        set[i] = rnd.Next(1, 20); // Numbers between 1 and 19

                    Console.WriteLine($"\nGenerated random set: {{ {string.Join(", ", set)} }}");
                    break;
            }
            Console.Write("\nEnter the target sum: ");
            if (!int.TryParse(Console.ReadLine(), out int target) || target < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Target sum must be a non-negative integer.");
                Console.ResetColor();
                return;
            }

            var solver = new SubsetSum();
            bool result = solver.IsSubsetSum(set, target);

            Console.ForegroundColor = result ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"\nResult: {(result ? "YES" : "NO")}, a subset " +
                              $"{(result ? "DOES" : "does NOT")} exist with sum = {target}.");
            Console.ResetColor();
        }




        static void RunGraphColoring()
        {
            Console.WriteLine("=== Graph Coloring Problem (Random Graph Mode) ===\n");

            // Step 1: Parameters for graph generation
            Console.Write("To make your graph multi-by-multi, enter an integer between 2 and 20 : ");
            int vertices = int.Parse(Console.ReadLine()); // You can change this for larger graphs
            double edgeProbability = 0.3; // Chance that an edge exists between two vertices (0 to 1)
            int maxColors = 20; // Number of colors to test

            Console.WriteLine($"Generating a random graph with {vertices} vertices...");
            int[,] graph = GenerateRandomGraph(vertices, edgeProbability);

            // Step 2: Display adjacency matrix
            Console.WriteLine("\nGenerated Adjacency Matrix:");
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                    Console.Write(graph[i, j] + " ");
                Console.WriteLine();
            }

            // Step 3: Run the coloring algorithm
            Console.WriteLine($"\nTrying to color the graph with {maxColors} color(s)...\n");

            var solver = new GraphColoring();
            bool success = solver.Solve(graph, maxColors);

            // Step 4: Display result
            Console.WriteLine("\n--------------------------------------");
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Result: ✅ The graph CAN be colored using {maxColors} color(s).");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Result: ❌ The graph CANNOT be colored using only {maxColors} color(s).");
            }
            Console.ResetColor();
            Console.WriteLine("--------------------------------------\n");
        }

        static int[,] GenerateRandomGraph(int V, double edgeProbability)
        {
            Random rand = new Random();
            int[,] graph = new int[V, V];

            for (int i = 0; i < V; i++)
            {
                for (int j = i + 1; j < V; j++)
                {
                    if (rand.NextDouble() < edgeProbability)
                    {
                        graph[i, j] = graph[j, i] = 1;
                    }
                }
            }

            return graph;
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
            int[,] dist = floyd.FindShortestPaths(graph); // اکنون خروجی متد را می‌گیریم

            Console.WriteLine("\nShortest paths matrix:");
            PrintGraph(dist);
        }

        static void PrintGraph(int[,] graph)
        {
            int V = graph.GetLength(0);

            // جدول مرتب با سربرگ شماره رئوس برای خوانایی بهتر
            Console.Write("\t");
            for (int i = 0; i < V; i++)
                Console.Write($"[{i}]\t");
            Console.WriteLine();

            for (int i = 0; i < V; i++)
            {
                Console.Write($"[{i}]\t");
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
