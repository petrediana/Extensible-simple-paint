using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;

namespace PluginFlip
{
    public class FlipOneEightyCommand : Command
    {
        public FlipOneEightyCommand() : base("Flip 180", Resource1.RotateOneEightyImage) { }
        public override void Execute()
        {
            PaintDocument _document = ApplicationModel.Instace.PaintDocument;
            _document.RotateImage180();
        }
    }
}
