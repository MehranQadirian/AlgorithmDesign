using System.Drawing;
namespace GraphColoringApp.Models
{
    public class Node
    {
        public int Id { get; set; }
        public Point Position { get; set; }
        public int Color { get; set; } = -1;
    }
}
