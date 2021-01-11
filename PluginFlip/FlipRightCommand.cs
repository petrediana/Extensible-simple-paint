using SimplePaint.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginFlip
{
    public class FlipRightCommand : Command
    {
        public FlipRightCommand() : base("Flip right", Resource1.RotateRightImage) { }
        public override void Execute()
        {
            PaintDocument _document = ApplicationModel.Instace.PaintDocument;
            _document.RotateImageRight();
        }
    }
}
