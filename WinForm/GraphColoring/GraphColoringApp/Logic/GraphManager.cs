using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraphColoringApp.Models;

namespace GraphColoringApp.Logic
{
    public class GraphManager
    {
        public List<Node> Nodes { get; private set; } = new List<Node>();
        public List<Edge> Edges { get; private set; } = new List<Edge>();

        private int nextNodeId = 0;

        public void AddNode(int x, int y)
        {
            Nodes.Add(new Node
            {
                Id = nextNodeId++,
                Position = new Point(x, y),
                Color = -1
            });
        }

        public void RemoveNode(int id)
        {
            Nodes.RemoveAll(n => n.Id == id);
            Edges.RemoveAll(e => e.FromId == id || e.ToId == id);
        }

        public void AddEdge(int fromId, int toId, bool directed)
        {
            if (fromId == toId) return; // No self-loop
            if (Edges.Any(e => e.FromId == fromId && e.ToId == toId && e.IsDirected == directed)) return;

            Edges.Add(new Edge
            {
                FromId = fromId,
                ToId = toId,
                IsDirected = directed
            });
        }

        public void Clear()
        {
            Nodes.Clear();
            Edges.Clear();
            nextNodeId = 0;
        }

        public void SetNextNodeId()
        {
            nextNodeId = Nodes.Any() ? Nodes.Max(n => n.Id) + 1 : 0;
        }

        public void GreedyColor(List<Color> colorPalette)
        {
            // مرحله 1: پاک کردن رنگ‌های قبلی
            foreach (var node in Nodes)
                node.Color = -1;

            // مرحله 2: مرتب‌سازی گره‌ها بر اساس درجه (بهینه‌تر برای greedy coloring)
            var sortedNodes = Nodes
                .OrderByDescending(n => GetNeighbors(n.Id).Count)
                .ToList();

            foreach (var node in sortedNodes)
            {
                // مرحله 3: یافتن رنگ‌های استفاده‌شده توسط همسایه‌ها
                var usedColors = GetNeighbors(node.Id)
                    .Select(n => n.Color)
                    .Where(color => color != -1)
                    .ToHashSet();

                // مرحله 4: اختصاص کمترین رنگ ممکن
                for (int c = 0; c < colorPalette.Count; c++)
                {
                    if (!usedColors.Contains(c))
                    {
                        node.Color = c;
                        break;
                    }
                }
            }
        }
        private List<Node> GetNeighbors(int nodeId)
        {
            var neighborIds = new HashSet<int>();

            foreach (var edge in Edges)
            {
                if (edge.IsDirected)
                {
                    if (edge.FromId == nodeId)
                        neighborIds.Add(edge.ToId);
                    else if (edge.ToId == nodeId)
                        continue; // ورودی‌ها در گراف جهت‌دار همسایه محسوب نمی‌شوند
                }
                else
                {
                    if (edge.FromId == nodeId)
                        neighborIds.Add(edge.ToId);
                    else if (edge.ToId == nodeId)
                        neighborIds.Add(edge.FromId);
                }
            }

            return Nodes.Where(n => neighborIds.Contains(n.Id)).ToList();
        }


    }
}
