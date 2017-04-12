using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ToyRobot.Common;

namespace ToyRobot.Models
{
    public class Location
    {
        public Location() { }

        public Location(int x, int y, Orientation orientation)
        {
            this.Position = new Point(x, y);
            this.Orientation = orientation;
        }

        public Location(Location location)
            : this(location.Position.X, location.Position.Y, location.Orientation)
        {
        }

        public Point Position { get; set; }
        public Orientation Orientation { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0},{1},{2}",
                this.Position.X, this.Position.Y, this.Orientation.ToString());
        }
    }

}
