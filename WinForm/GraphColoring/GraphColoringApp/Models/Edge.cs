namespace GraphColoringApp.Models
{
    public class Edge
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public bool IsDirected { get; set; }
    }
}