using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Common;
using ToyRobot.Models;

namespace ToyRobot.Core
{
    public class PlaceCommand : BaseCommand
    {
        public PlaceCommand()
            : this(0, 0, 0)
        {
        }

        public PlaceCommand(int x, int y, Orientation orientation)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }

        public override void Execute(Table table, ILogger logger)
        {
            base.Execute(table, logger);

            // Check if the initial position is outside the table. Otherwise, robot will not be created.
            if (table.IsValidPoint(this.X, this.Y))
            {
                // Spawn robot
                table.CreateRobot(this.X, this.Y, this.Orientation);
            }
        }
    }
}
