using SimplePaint.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SimplePaint.FormApplication.Commands
{
    public class RubberCommand : Command
    {
        public RubberCommand() : base("Rubber", Resource1.RubberImage) { }
        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;
            document.ChangeColor(Color.White);
        }
    }
}
