using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ToyRobot.Common;

namespace ToyRobot.Models
{
    public class Table
    {
        public Table()
        {
        }

        public Table(int length)
            : this()
        {
            this.Start = new Point(0, 0);
            this.End = new Point(length, length);
        }

        public Point Start { get; private set; }
        public Point End { get; private set; }
        public virtual Robot Robot { get; set; }

        /// <summary>
        /// Check if a given coordinate is inside the table
        /// </summary>
        public virtual bool IsValidPoint(int x, int y)
        {
            return x <= this.End.X && x >= this.Start.X &&
                y <= this.End.Y && y >= this.Start.Y;
        }

        /// <summary>
        /// Check if a given coordinate is inside the table
        /// </summary>
        public virtual bool IsValidPoint(Point point)
        {
            return IsValidPoint(point.X, point.Y);
        }

        public virtual Robot CreateRobot(int startX, int startY, Orientation orientation)
        {
            // Check if the given point is inside the world
            if(!this.IsValidPoint(startX, startY))
            {
                throw CannotCreateOutsideTableException();
            }

            // Create new robot and add to the robots collection
            this.Robot = new Robot(startX, startY, orientation);
            return this.Robot;
        }

        InvalidOperationException CannotCreateOutsideTableException()
        {
            return new InvalidOperationException("Cannot create robots outside the Table");
        }
    }
}
