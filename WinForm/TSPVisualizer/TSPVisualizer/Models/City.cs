using System.Drawing;

namespace TSPVisualizer.Models
{
    public class City
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public City(string name, Point location)
        {
            Name = name;
            Location = location;
        }

        public City()
        {
        }
    }
}
