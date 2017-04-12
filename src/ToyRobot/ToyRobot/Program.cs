using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Core;
using ToyRobot.Models;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new  CommandLineLogger();
            CommandFactory factory = new CommandFactory();
            
            string fileName = args[0];
            if (!File.Exists(fileName))
            {
                logger.Log(
                    string.Format("Input file does not exists in the path '{0}'", fileName));
                
                return;
            }

            string[] stringCommandLines = File.ReadAllLines(fileName);

            Table table = new Table(5);

            foreach (var commandLine in stringCommandLines)
            {
                // Filter any empty command. We have validations inside, but this is faster.
                if (string.IsNullOrEmpty(commandLine))
                {
                    continue;
                }

                ICommand command = factory.CreateCommand(commandLine);
                command.Execute(table, logger);
            }

            Console.Read();
        }
    }
}
