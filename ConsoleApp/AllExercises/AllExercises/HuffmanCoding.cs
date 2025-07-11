using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllExercises
{
    public class HuffmanCoding
    {
        class Node : IComparable<Node>
        {
            public char Character;
            public int Frequency;
            public Node Left, Right;
            public bool IsLeaf => Left == null && Right == null;

            public int CompareTo(Node other)
            {
                return Frequency.CompareTo(other.Frequency);
            }
        }

        public void EncodeAndDisplay(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("The input text is empty.!");
                return;
            }

            Console.WriteLine($"\nInput text: {text}");
            Console.WriteLine("----------------------------------------");

            var codes = Encode(text);
            DisplayStatistics(text, codes);
            Console.WriteLine("\nHuffman tree:");
            PrintHuffmanTree(GetRootNode(text));
        }

        public Dictionary<char, string> Encode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new Dictionary<char, string>();

            // محاسبه فراوانی کاراکترها
            var freq = text
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            // ساخت صف اولویت‌دار
            var queue = new PriorityQueue<Node>();
            foreach (var kvp in freq)
            {
                queue.Enqueue(new Node
                {
                    Character = kvp.Key,
                    Frequency = kvp.Value
                });
            }

            // ساخت درخت Huffman
            while (queue.Count > 1)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();

                var merged = new Node
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };

                queue.Enqueue(merged);
            }

            // تولید کدها
            var root = queue.Dequeue();
            var codes = new Dictionary<char, string>();
            AssignCodes(root, "", codes);

            return codes;
        }

        private Node GetRootNode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var freq = text
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            var queue = new PriorityQueue<Node>();
            foreach (var kvp in freq)
            {
                queue.Enqueue(new Node
                {
                    Character = kvp.Key,
                    Frequency = kvp.Value
                });
            }

            while (queue.Count > 1)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();

                var merged = new Node
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };

                queue.Enqueue(merged);
            }

            return queue.Dequeue();
        }

        private void AssignCodes(Node node, string code, Dictionary<char, string> codes)
        {
            if (node == null) return;

            if (node.IsLeaf)
            {
                codes[node.Character] = code;
                return;
            }

            AssignCodes(node.Left, code + "0", codes);
            AssignCodes(node.Right, code + "1", codes);
        }

        private void DisplayStatistics(string text, Dictionary<char, string> codes)
        {
            Console.WriteLine("\n   Character\t   Abundance\t   Huffman code\t    Code length\t    Number of bits");
            Console.WriteLine("------------------------------------------------------" +
                              "-----------------------------");

            int totalBits = 0;
            int totalChars = text.Length;

            foreach (var kvp in codes.OrderByDescending(x => x.Value.Length))
            {
                char c = kvp.Key;
                string code = kvp.Value;
                int freq = text.Count(ch => ch == c);
                int bits = freq * code.Length;
                totalBits += bits;

                Console.WriteLine($"\t{c}\t\t{freq}\t\t{code}\t\t{code.Length}\t\t  {bits}");
            }

            Console.WriteLine("------------------------------------------------------" +
                              "-----------------------------");
            Console.WriteLine($"Total number of characters: {totalChars}");
            Console.WriteLine($"Total number of bits: {totalBits}");
            Console.WriteLine($"Average code length: {(double)totalBits / totalChars:0.##} Bits per character");
            Console.WriteLine($"Savings: {totalChars * 8 - totalBits} Bit ({(1 - (double)totalBits / (totalChars * 8)):P} Reduction)");
        }

        private void PrintHuffmanTree(Node root, string indent = "", bool last = true)
        {
            if (root == null) return;

            Console.Write(indent);
            if (last)
            {
                Console.Write("└─");
                indent += "  ";
            }
            else
            {
                Console.Write("├─");
                indent += "│ ";
            }

            if (root.IsLeaf)
            {
                Console.WriteLine($"{root.Character} ({root.Frequency})");
            }
            else
            {
                Console.WriteLine($"• ({root.Frequency})");
            }

            PrintHuffmanTree(root.Left, indent, false);
            PrintHuffmanTree(root.Right, indent, true);
        }
    }
}