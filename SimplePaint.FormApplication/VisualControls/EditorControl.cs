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
    public partial class EditorControl : UserControl
    {
        private PaintDocument _doc = ApplicationModel.Instace.PaintDocument;
        private Graphics _panelGraphics;

        const string testImgPath = @"C:\Users\Peanut\Desktop\c25ca8a50647885986e62037962fb6d6.jpg";
        public EditorControl()
        {
            InitializeComponent();

            _doc.BackGroundImageChanged += PaintDocument_BackGroundImageChanged;

            InitializeCanvasProperties();

            KeyDown += EditorControl_KeyDown;
            Resize += EditorControl_Resize;

        }

        private void PaintDocument_BackGroundImageChanged(object sender, EventArgs e)
        {
            drawingCanvasPanel.BackgroundImage = _doc.BackGroundImage;
            drawingCanvasPanel.Refresh();
            
            _panelGraphics = drawingCanvasPanel.CreateGraphics();
            _doc.Draw(_panelGraphics);
        }

        private void EditorControl_Resize(object sender, EventArgs e)
        {
            _panelGraphics = drawingCanvasPanel.CreateGraphics();
        }

        private void EditorControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                _doc.CopyToClipboard();
            }
        }

        private void InitializeCanvasProperties()
        {
            drawingCanvasPanel.Cursor = Cursors.Cross;
            _panelGraphics = drawingCanvasPanel.CreateGraphics();
            _panelGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            drawingCanvasPanel.BackgroundImage = _doc.BackGroundImage;

            #region DrawingCanvasPanel Events needed to draw lines on it
            drawingCanvasPanel.Paint += DrawingCanvasPanel_Paint;

            drawingCanvasPanel.MouseDown += DrawingCanvasPanel_MouseDown;
            drawingCanvasPanel.MouseUp += DrawingCanvasPanel_MouseUp;
            drawingCanvasPanel.MouseMove += DrawingCanvasPanel_MouseMove;
            #endregion
        }

        private void DrawingCanvasPanel_Paint(object sender, PaintEventArgs e)
        {
            _doc.Draw(e.Graphics);
            Invalidate();
        }

        private void DrawingCanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_doc.IsDrawing)
            {
                _doc.AddLocationToLine(e.Location);
                _doc.DrawLastLine(_panelGraphics);
                _doc.CurrentLocation = e.Location;
                Invalidate();
            }
        }

        private void DrawingCanvasPanel_MouseUp(object sender, MouseEventArgs e)
        {
            _doc.IsDrawing = false;
        }

        private void DrawingCanvasPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _doc.IsDrawing = true;
            _doc.AddEmptyLine();
        }
    }
}
