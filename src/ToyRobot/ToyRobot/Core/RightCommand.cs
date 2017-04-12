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
    /// <summary>
    /// Command to turn the robot to the right
    /// </summary>
    public class RightCommand : BaseCommand
    {
        public override void Execute(Table table, ILogger logger)
        {
            base.Execute(table, logger);
            // If the robot has not been PLACEd, ignore any commands
            if (table.Robot == null)
            {
                return;
            }

            int newOrientation = (int)table.Robot.Location.Orientation + 90;
            // If the orientation is 360, reset to 0.
            if (newOrientation == 360)
            {
                table.Robot.Location.Orientation = Orientation.NORTH;
            }
            else
            {
                // Rotate 90 degrees clock wise
                table.Robot.Location.Orientation = (Orientation)newOrientation;
            }
        }
    }
}
