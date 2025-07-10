using System;
using System.Collections.Generic;

namespace AllExercises
{
    public class HuffmanCoding
    {
        class Node : IComparable<Node>
        {
            public char Character;
            public int Frequency;
            public Node Left, Right;

            public int CompareTo(Node other)
            {
                return Frequency.CompareTo(other.Frequency);
            }
        }

        public Dictionary<char, string> Encode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new Dictionary<char, string>();

            Dictionary<char, int> freq = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            PriorityQueue<Node> queue = new PriorityQueue<Node>();
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

            Node root = queue.Dequeue();
            Dictionary<char, string> codes = new Dictionary<char, string>();
            AssignCodes(root, "", codes);

            return codes;
        }

        private void AssignCodes(Node node, string code, Dictionary<char, string> codes)
        {
            if (node == null) return;

            if (node.Left == null && node.Right == null)
            {
                codes[node.Character] = code;
                return;
            }

            AssignCodes(node.Left, code + "0", codes);
            AssignCodes(node.Right, code + "1", codes);
        }
    }
}
