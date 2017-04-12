using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot.Core
{
    public class ReportCommand : BaseCommand
    {
        public override void Execute(Table table, ILogger logger)
        {
            base.Execute(table, logger);
            // If the robot has not been PLACEd, ignore any commands
            if (table.Robot == null)
            {
                return;
            }

            logger.Log(table.Robot.Location.ToString());
        }
    }
}
