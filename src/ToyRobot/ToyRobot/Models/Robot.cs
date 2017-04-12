using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Common;
using ToyRobot.Core;

namespace ToyRobot.Models
{
    public class Robot
    {
        public Robot(int startX, int startY, Orientation orientation)
        {
            this.Location = new Location(startX, startY, orientation);
        }

        public Location Location { get; set; }
    }
}
