using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyRobot.Common;

namespace ToyRobot.Core
{
    public class CommandFactory
    {
        /// <summary>
        /// Create command using given InputCommandLine
        /// </summary>
        public ICommand CreateCommand(InputCommandLine inputCommandLine)
        {
            // If the given input is not in valid format, do not create the command
            if (inputCommandLine == null || !inputCommandLine.IsValid)
            {
                return null;
            }

            switch (inputCommandLine.CommandType)
            {
                case CommandType.PLACE:
                    return new PlaceCommand(inputCommandLine.X, inputCommandLine.Y, inputCommandLine.Orientation);

                case CommandType.MOVE:
                    return new MoveCommand();

                case CommandType.LEFT:
                    return new LeftCommand();

                case CommandType.RIGHT:
                    return new RightCommand();

                case CommandType.REPORT:
                    return new ReportCommand();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Create command using given command line string
        /// </summary>
        public ICommand CreateCommand(string command)
        {
            InputCommandLine input = InputCommandLine.ParseCommand(command);
            return this.CreateCommand(input);
        }
    }
}
