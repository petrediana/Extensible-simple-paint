using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint.ObjectModel
{
    public class PaintDocument
    {
        public PaintDocument()
        {

        }

        #region Private Attributes definition
        private List<List<Point>> _lines;
        private bool _isDrawing;

        private string _filePath;
        private bool _isDirty;
        #endregion

        public List<List<Point>> Lines
        {
            get => _lines;
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }

        public void New()
        {
            _lines = new List<List<Point>>();
        }
    }
}
