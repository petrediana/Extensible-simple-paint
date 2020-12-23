using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;
using System.Windows.Forms;

namespace SimplePaint.FormApplication.Commands
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base("Quit") { }
        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;

            if (document.IsDirty)
            {
                DialogResult dialogResult =
                    MessageBox.Show("Document was modified. Are you sure you want to quit and lose changes?",
                        "Quit - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            ApplicationModel.Instace.Quit();
        }
    }
}
