using TSPVisualizer.Models;
using TSPVisualizer.Core.Interfaces;

namespace TSPVisualizer.Core.Commands
{
    public class AddCityCommand : ICommand
    {
        private GraphManager graph;
        private City city;

        public AddCityCommand(GraphManager graph, City city)
        {
            this.graph = graph;
            this.city = city;
        }

        public void Execute()
        {
            graph.AddCity(city);
        }

        public void Undo()
        {
            graph.RemoveCity(city);
        }
    }
}
