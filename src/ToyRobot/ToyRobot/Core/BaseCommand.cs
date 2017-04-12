using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot.Core
{
    /// <summary>
    /// Base for all the commands. Any common command logic may be added here.
    /// </summary>
    public abstract class BaseCommand: ICommand
    {
        public virtual void Execute(Table table, ILogger logger)
        {
            if (table == null)
            {
                throw TableNullException();
            }
        }

        ArgumentNullException TableNullException()
        {
            string description = "Table is not initialized";
            return new ArgumentNullException(description);
        }
    }
}
