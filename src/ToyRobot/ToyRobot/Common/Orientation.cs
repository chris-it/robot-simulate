using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Common
{
    public enum Orientation : int
    {
        UNKNOWN = -1,
        NORTH = 0,
        EAST = 90,
        SOUTH = 180,
        WEST = 270
    }
}
