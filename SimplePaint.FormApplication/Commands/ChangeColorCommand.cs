using SimplePaint.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint.FormApplication.Commands
{
    public class ChangeColorCommand : Command
    {
        public ChangeColorCommand() : base("Pick Color") { }

        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;
            ColorDialog colorDialog = new ColorDialog();

            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                document.ChangeColor(colorDialog.Color);
            }
        }
    }
}
