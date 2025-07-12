using System;
using System.Collections.Generic;

namespace AllExercises
{
    /// <summary>
    /// Implements Huffman coding algorithm for lossless text compression.
    /// </summary>
    public class HuffmanCoding
    {
        /// <summary>
        /// Represents a node in the Huffman tree.
        /// </summary>
        private class Node : IComparable<Node>
        {
            public char Character;        // Character stored (for leaf nodes)
            public int Frequency;        // Frequency of character
            public Node Left, Right;     // Left and right children

            public int CompareTo(Node other)
            {
                return Frequency.CompareTo(other.Frequency);
            }

            public bool IsLeaf()
            {
                return Left == null && Right == null;
            }
        }

        /// <summary>
        /// Generates Huffman codes for a given input string.
        /// </summary>
        /// <param name="text">Input string to be encoded</param>
        /// <returns>Dictionary of characters to their Huffman codes</returns>
        public Dictionary<char, string> Encode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new Dictionary<char, string>();

            // Step 1: Count frequency of each character
            Dictionary<char, int> freq = BuildFrequencyTable(text);

            // Step 2: Build priority queue (min-heap) of nodes
            PriorityQueue<Node> queue = new PriorityQueue<Node>();
            foreach (var entry in freq)
            {
                queue.Enqueue(new Node
                {
                    Character = entry.Key,
                    Frequency = entry.Value
                });
            }

            // Step 3: Build Huffman tree
            while (queue.Count > 1)
            {
                Node left = queue.Dequeue();
                Node right = queue.Dequeue();

                Node merged = new Node
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };

                queue.Enqueue(merged);
            }

            // Step 4: Generate codes from the tree
            Node root = queue.Dequeue();
            Dictionary<char, string> codes = new Dictionary<char, string>();
            GenerateCodes(root, "", codes);

            return codes;
        }

        /// <summary>
        /// Builds frequency table from input text.
        /// </summary>
        private Dictionary<char, int> BuildFrequencyTable(string text)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            return freq;
        }

        /// <summary>
        /// Recursively generates Huffman codes by traversing the tree.
        /// </summary>
        private void GenerateCodes(Node node, string code, Dictionary<char, string> codes)
        {
            if (node == null)
                return;

            if (node.IsLeaf())
            {
                codes[node.Character] = code;
                return;
            }

            GenerateCodes(node.Left, code + "0", codes);
            GenerateCodes(node.Right, code + "1", codes);
        }
    }
}
