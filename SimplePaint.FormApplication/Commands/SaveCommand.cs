using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;
using System.Windows.Forms;

namespace SimplePaint.FormApplication.Commands
{
    public class SaveCommand : Command
    {
        public SaveCommand() : base("Save") { }
        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter 
                = "bmp (*.bmp)|*.bmp|jpeg (*.jpeg)|*.jpeg|png (*.png)|*.png|tiff (*.tiff)|*.tiff";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
            }
        }
    }
}
