using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot.Core
{
    /// <summary>
    /// Command interface
    /// </summary>
    public interface ICommand
    {
        void Execute(Table table, ILogger logger);
    }
}
