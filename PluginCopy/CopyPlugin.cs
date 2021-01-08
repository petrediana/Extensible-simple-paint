using SimplePaint.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginCopy
{
    public class CopyPlugin : IPluginable
    {
        public List<Command> GetCommands()
        {
            List<Command> commands = new List<Command>
            {
                new CopyCommand()
            };

            return commands;
        }

        public void Initialize()
        {
            Console.WriteLine("Copy plugin enabled!");
        }
    }
}
