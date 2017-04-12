using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Common;
using ToyRobot.Models;

namespace ToyRobot.Core
{
    public class MoveCommand : BaseCommand
    {
        public override void Execute(Table table, ILogger logger)
        {
            base.Execute(table, logger);
            // If the robot has not been PLACEd, ignore any commands
            if (table.Robot == null)
            {
                return;
            }

            // Create a new point to modify
            Point latestPoint = new Point(table.Robot.Location.Position.X, table.Robot.Location.Position.Y);

            if (table.Robot.Location.Orientation ==  Orientation.NORTH)
            {
                latestPoint.Offset(0, 1);
            }
            else if (table.Robot.Location.Orientation == Orientation.EAST)
            {
                latestPoint.Offset(1, 0);
            }
            else if (table.Robot.Location.Orientation == Orientation.SOUTH)
            {
                latestPoint.Offset(0, -1);
            }
            else if (table.Robot.Location.Orientation == Orientation.WEST)
            {
                latestPoint.Offset(-1, 0);
            }

            // Check if the latest point is inside the table, if so move the robot. Otherwise, ignore the command.
            if (table.IsValidPoint(latestPoint))
            {
                table.Robot.Location.Position = latestPoint;
            }
        }
    }
}
