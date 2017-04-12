using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ToyRobot.Common
{
    public class InputCommandLine
    {
        public virtual CommandType CommandType { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual Orientation Orientation { get; set; }

        public virtual bool IsValid { get; set; }

        /// <summary>
        /// This will convert given string command to a InputCommandLine
        /// </summary>
        public static InputCommandLine ParseCommand(string command)
        {
            InputCommandLine input = new InputCommandLine() { IsValid = true };

            List<string> args = SplitCommand(command);

            // Parse the command type
            CommandType commandEnum;
            if (Enum.TryParse<CommandType>(args[0], true, out commandEnum))
            {
                input.CommandType = commandEnum;
            }
            else
            {
                input.IsValid = false;
            }

            // Parse any X,Y coordinates
            int x;
            if (!string.IsNullOrEmpty(args[1]) && int.TryParse(args[1], out x))
            {
                input.X = x;
            }
            int y;
            if (!string.IsNullOrEmpty(args[2]) && int.TryParse(args[2], out y))
            {
                input.Y = y;
            }

            // Parse any orientation
            if (!string.IsNullOrEmpty(args[3]))
            {
                Orientation orientationEnum;
                if (Enum.TryParse<Orientation>(args[3], true, out orientationEnum))
                {
                    input.Orientation = orientationEnum;
                }
                else
                {
                    input.IsValid = false;
                }
            }

            return input;
        }

        /// <summary>
        /// Split the command into arguments
        /// </summary>
        private static List<string> SplitCommand(string command)
        {
            // Parse the command line and split the arguments
            var match = Regex.Match(command.ToUpper().Trim(), "([^ ]+) *([0-9]*) *,? *([0-9]*) *((, *)([^\r\n ]+))?");

            // Initialize the arguments
            return new List<string>(){
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value,
                match.Groups[6].Value
            };
        }
    }
}