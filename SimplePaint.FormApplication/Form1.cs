using SimplePaint.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint.FormApplication
{
    public partial class Form1 : Form
    {
        private PaintDocument _doc;
        private Graphics _panelGraphics;

        const string testImgPath = @"C:\Users\Peanut\Desktop\c25ca8a50647885986e62037962fb6d6.jpg";
        public Form1()
        {
            InitializeComponent();

            _doc = new PaintDocument();
            _doc.BackGroundImage = Image.FromFile(testImgPath);
            
            _panelGraphics = drawingCanvasPanel.CreateGraphics();
            _panelGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            InitializeCanvasProperties();
            KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject dataObject = new DataObject();
                dataObject.SetData(typeof(string), _doc.Lines.Count + " linii");

                Bitmap b = new Bitmap(_doc.BackGroundImage);
                Draw(Graphics.FromImage(b));

                dataObject.SetData(typeof(Bitmap), b);
                Clipboard.SetDataObject(dataObject);
            }
        }

        private void InitializeCanvasProperties()
        {
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
            Draw(e.Graphics);
        }

        private void DrawingCanvasPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_doc.IsDrawing)
            {
                _doc.AddLocationToLine(e.Location);
                Draw(_panelGraphics);
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

        private void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.ForestGreen, 4);
            
            foreach (var currentLine in _doc.Lines)
            {
                for (int i = 0; i < currentLine.Count - 1; ++i)
                {
                    graphics.DrawLine(pen, currentLine[i], currentLine[i + 1]);
                }
            }
        }
    }
}
