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
    /// Command to turn the robot to the left
    /// </summary>
    public class LeftCommand : BaseCommand
    {
        public override void Execute(Table table, ILogger logger)
        {
            base.Execute(table, logger);
            // If the robot has not been PLACEd, ignore any commands
            if (table.Robot == null)
            {
                return;
            }

            int newOrientation = (int)table.Robot.Location.Orientation - 90;
            // If the orientation is -90, reset to 270.
            if (newOrientation == -90)
            {
                table.Robot.Location.Orientation = Orientation.WEST;
            }
            else
            {
                // Rotate 90 degrees counter clock wise
                table.Robot.Location.Orientation = (Orientation)newOrientation;
            }
        }
    }
}
