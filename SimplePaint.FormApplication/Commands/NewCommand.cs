using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;
using System.Windows.Forms;

namespace SimplePaint.FormApplication.Commands
{
    public class NewCommand : Command
    {
        public NewCommand() : base("New", Resource1.NewImage) { }

        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;
            if (document.IsDirty)
            {
                DialogResult dialogResult =
                    MessageBox.Show("Document was modified. You will lose changes. Want to save?",
                        "Paint!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            document.New();
        }
    }
}
