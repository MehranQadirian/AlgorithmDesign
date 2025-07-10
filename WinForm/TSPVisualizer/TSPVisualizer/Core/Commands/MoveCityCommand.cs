using System.Drawing;
using TSPVisualizer.Models;
using TSPVisualizer.Core.Interfaces;

namespace TSPVisualizer.Core.Commands
{
    public class MoveCityCommand : ICommand
    {
        private City city;
        private Point oldPos;
        private Point newPos;

        public MoveCityCommand(City city, Point oldPos, Point newPos)
        {
            this.city = city;
            this.oldPos = oldPos;
            this.newPos = newPos;
        }

        public void Execute()
        {
            city.Location = newPos;
        }

        public void Undo()
        {
            city.Location = oldPos;
        }
    }
}
