using SimplePaint.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePaint.FormApplication.Commands
{
    public class DrawElipseCommand : Command
    {
        public DrawElipseCommand() : base("Elipse", Resource1.ElipseImage) { }

        public override void Execute()
        {
            PaintDocument _doc = ApplicationModel.Instace.PaintDocument;
            _doc.IsDrawingElipse = true;
        }
    }
}
