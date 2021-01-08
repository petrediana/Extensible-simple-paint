using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimplePaint.ObjectModel;

namespace SimplePaint.FormApplication.VisualControls
{
    public partial class InfoStatusControl : UserControl
    {
        private PaintDocument _document = ApplicationModel.Instace.PaintDocument;
        public InfoStatusControl()
        {
            InitializeComponent();

            UpdateStatusStrip();

            _document.CurrentLocationChanged += (s, e) => UpdateStatusStrip();
        }

        private void UpdateStatusStrip()
        {
            coordinatesStatusStripItem.Text = string.Format("Coordinates: ({0},{1})",
                                                _document.CurrentLocation.X, _document.CurrentLocation.Y);
            linesDrawnStatusStripItem.Text = string.Format("Lines drawn: {0}", _document.Lines.Count);
        }
    }
}
