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

            Console.WriteLine("\nMultiplying large numbers:");
            Console.Write("Enter the first number : ");
            string num1 = Console.ReadLine();

            Console.Write("Enter the second number : ");
            string num2 = Console.ReadLine();

            // روش ساده
            string result = multiplier.Multiply(num1, num2);
            Console.WriteLine($"\nFinal result: {result}");
            Console.Write("\nDo you need me to show you the steps of multiplication step by step? [y/n] ");
            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case 'y':
                    multiplier.PrettyMultiply(num1, num2);
                    break;
                case 'n':
                    Console.WriteLine("\n\tYou skipped.");
                    break;
                case 'Y':
                    multiplier.PrettyMultiply(num1, num2);
                    break;
                case 'N':
                    Console.WriteLine("\n\tYou skipped.");
                    break;
                default:
                    Console.WriteLine("You entered an incorrect character, please enter either y or n.");
                    break;
            }
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
            Console.Write("\nEnter text to compress : ");
            string text = Console.ReadLine();

            var huffman = new HuffmanCoding();
            huffman.EncodeAndDisplay(text);
        }

        static void RunNQueens()
        {
            var solver = new NQueensSolver();

            Console.WriteLine("\n=== N-Queens Problem Solver ===");
            Console.WriteLine("Enter the number of queens (n) between 1 and 20:");

            // دریافت ورودی با اعتبارسنجی پیشرفته
            int n;
            while (true)
            {
                Console.Write("n = ");
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    if (n >= 1 && n <= 20) break;
                    Console.WriteLine("Please enter a number between 1 and 20.");
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer.");
                }
            }

            // نمایش منوی گزینه‌ها
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Find first solution (fastest)");
            Console.WriteLine("2. Find all solutions");
            Console.WriteLine("3. Benchmark performance");
            Console.Write("Your choice (1-3): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.Write("Invalid choice. Please enter 1, 2 or 3: ");
            }

            // پردازش بر اساس انتخاب کاربر
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nFinding first solution...");
                    solver.Solve(n, findAllSolutions: false, printBoards: true);
                    break;

                case 2:
                    if (n > 10)
                    {
                        Console.WriteLine("\nWarning: Finding all solutions for n > 10 may take significant time.");
                        Console.WriteLine("Do you want to continue? (y/n)");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            Console.WriteLine("Operation canceled.");
                            return;
                        }
                    }
                    Console.WriteLine("\nFinding all solutions...");
                    solver.Solve(n, findAllSolutions: true, printBoards: n <= 10);
                    break;

                case 3:
                    Console.WriteLine("\nRunning benchmark...");
                    solver.Benchmark();
                    break;
            }

            // نمایش اطلاعات تکمیلی
            if (choice != 3 && n > 1)
            {
                Console.WriteLine("\nAdditional information:");
                solver.DisplaySolutionCountsUpTo(Math.Min(n, 10));

                if (n > 8)
                {
                    Console.WriteLine("\nTip: For n > 8, consider using the benchmark option");
                    Console.WriteLine("to compare performance across different board sizes.");
                }
            }

            Console.WriteLine("\nOperation completed. Press any key to continue...");
            Console.ReadKey();
        }

        static void RunSubsetSum()
        {
            // مجموعه اعداد پیش‌فرض
            int[] defaultSet = { 3, 34, 4, 12, 5, 2 };

            Console.WriteLine("\n=== Subset Sum Problem Solver ===");

            // انتخاب مجموعه اعداد
            Console.WriteLine("\nCurrent number set: " + string.Join(", ", defaultSet));
            Console.Write("Do you want to use a custom set? (y/n): ");

            int[] workingSet = defaultSet;
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Enter numbers separated by commas (e.g., 3,34,4,12,5,2):");
                string input = Console.ReadLine();
                try
                {
                    workingSet = input.Split(',')
                                     .Select(x => int.Parse(x.Trim()))
                                     .ToArray();
                }
                catch
                {
                    Console.WriteLine("Invalid input! Using default set instead.");
                    workingSet = defaultSet;
                }
            }

            // دریافت جمع هدف
            int targetSum;
            while (true)
            {
                Console.Write("\nEnter target sum (non-negative integer): ");
                if (int.TryParse(Console.ReadLine(), out targetSum) && targetSum >= 0)
                    break;
                Console.WriteLine("Invalid input! Please enter a non-negative integer.");
            }

            var subsetSum = new SubsetSum();

            // بررسی وجود زیرمجموعه
            bool exists = subsetSum.IsSubsetSum(workingSet, targetSum);
            Console.WriteLine($"\nDoes a subset with sum {targetSum} exist? {(exists ? "YES" : "NO")}");

            // اگر زیرمجموعه‌ای وجود دارد، نمایش همه موارد
            if (exists)
            {
                Console.WriteLine("\nFinding all possible subsets...");
                var allSubsets = subsetSum.FindAllSubsets(workingSet, targetSum);

                Console.WriteLine($"\nFound {allSubsets.Count} subset(s):");
                foreach (var subset in allSubsets)
                {
                    Console.WriteLine($"- {string.Join(" + ", subset)} = {subset.Sum()}");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
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
            if (!int.TryParse(Console.ReadLine(), out int m))
            {
                Console.WriteLine("Invalid input");
                return;
            }


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

