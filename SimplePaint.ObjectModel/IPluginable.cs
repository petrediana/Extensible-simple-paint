using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePaint.ObjectModel
{
    public interface IPluginable
    {
        void Initialize();
        List<Command> GetCommands();
    }
}
