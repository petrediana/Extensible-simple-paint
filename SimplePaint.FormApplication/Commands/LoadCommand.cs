using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;
using System.Windows.Forms;

namespace SimplePaint.FormApplication.Commands
{
    public class LoadCommand : Command
    {
        public LoadCommand() : base("Load") { }

        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;
            if (document.IsDirty)
            {
                DialogResult result =
                    MessageBox.Show("Document was modified. Are you sure you want to open another file and lose changes?",
                    "Open Document - Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter
                = "bmp (*.bmp)|*.bmp|jpeg (*.jpeg)|*.jpeg|png (*.png)|*.png|tiff (*.tiff)|*.tiff";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Load(dialog.FileName);
            }
        }
    }
}
