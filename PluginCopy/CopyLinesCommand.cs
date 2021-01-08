using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;

namespace PluginCopy
{
    public class CopyLinesCommand : Command
    {
        public CopyLinesCommand() : base("Copy Lines", ResourceImages.CopyDrawnLinesImage) { }
        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;
            document.CopyDrawnLinesToClipboard();
        }
    }
}
