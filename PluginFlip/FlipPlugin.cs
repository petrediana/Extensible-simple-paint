using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;

namespace PluginFlip
{
    public class FlipPlugin : IPluginable
    {
        public List<Command> GetCommands()
        {
            List<Command> commands = new List<Command>
            {
                new FlipRightCommand(),
                new FlipOneEightyCommand()
            };

            return commands;
        }

        public void Initialize()
        {
            Console.WriteLine("Flip plugin enabled!");
        }
    }
}
