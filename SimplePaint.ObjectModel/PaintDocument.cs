using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SimplePaint.ObjectModel
{
    public class PaintDocument : INotifyPropertyChanged
    {
        public PaintDocument()
        {
            New();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Private Attributes definition
        private List<List<Point>> _lines;
        private List<Color> _colors;
        private Color _lastColorUsed;
        private Point _currentLocation;

        private bool _isDrawing;
        private Image _backGroundImage;

        private string _filePath;
        private bool _isDirty;
        #endregion

        #region Public Properties Event Handlers
        public event EventHandler IsDrawingChanged;
        public event EventHandler BackGroundImageChanged;
        public event EventHandler IsDirtyChanged;
        public event EventHandler FilePathChanged;
        public event EventHandler CurrentLocationChanged;
        #endregion

        #region Public Properties Definitions: CurrentLocation, Lines, IsDrawing, BackGroundImage, FilePath, IsDirty
        public Point CurrentLocation
        {
            get => _currentLocation;
            set
            {
                if (_currentLocation != value)
                {
                    _currentLocation = value;
                    OnPropertyChanged("CurrentLocation");
                }
            }
        }

        public List<List<Point>> Lines
        {
            get => _lines;
        }

        public bool IsDrawing
        {
            get => _isDrawing;
            set
            {
                if (_isDrawing != value)
                {
                    _isDrawing = value;
                    OnPropertyChanged("IsDrawing");
                }
            }
        }

        public Image BackGroundImage
        {
            get => _backGroundImage;
            set
            {
                if (_backGroundImage != value)
                {
                    _backGroundImage = value;
                    OnPropertyChanged("BackGroundImage");
                }
            }
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

        public string FileName
        {
            get => new FileInfo(_filePath).Name;
        }

        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    OnPropertyChanged("IsDirty");
                }
            }
        }
        #endregion

        #region Implementing some basic features
        public void New()
        {
            // TODO: load from resource
            const string testpath = @"C:\Users\Peanut\Desktop\download.png";

            _lines = new List<List<Point>>();
            _colors = new List<Color>();

            _lastColorUsed = Color.ForestGreen;

            _isDrawing = false;
            BackGroundImage = Image.FromFile(testpath);
            CurrentLocation = new Point();

            FilePath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "untitledPicture"
                                    );
            IsDirty = false;
        }

        public void Save(string filePath)
        {
            Bitmap paintedImage = new Bitmap(BackGroundImage);
            Draw(Graphics.FromImage(paintedImage));

            FilePath = filePath;
            paintedImage.Save(filePath);
            IsDirty = false;
        }

        public void Load(string filePath)
        {
            _lines = new List<List<Point>>();
            _colors = new List<Color>();
            _lastColorUsed = Color.ForestGreen;

            _isDrawing = false;

            BackGroundImage = Image.FromFile(filePath);
            CurrentLocation = new Point();
            FilePath = filePath;
            IsDirty = false;
        }

        public void DrawLastLine(Graphics graphics)
        {
            Pen pen = new Pen(_lastColorUsed, 4);
            int lastIndex = _lines.Count - 1;

            for (int i = 0; i < _lines[lastIndex].Count - 1; ++i)
            {
                graphics.DrawLine(pen, _lines[lastIndex][i], _lines[lastIndex][i + 1]);
            }
        }
        public void Draw(Graphics graphics)
        {
            int index = 0;
            foreach (var currentLine in _lines)
            {
                Pen pen = new Pen(_colors[index], 4);
                ++index;

                for (int i = 0; i < currentLine.Count - 1; ++i)
                {
                    graphics.DrawLine(pen, currentLine[i], currentLine[i + 1]);
                }
            }
        }

        public void CopyToClipboard()
        {
            DataObject dataObject = new DataObject();
            Bitmap paintedImage = new Bitmap(BackGroundImage);

            Draw(Graphics.FromImage(paintedImage));

            dataObject.SetData(typeof(Bitmap), paintedImage);
            Clipboard.SetDataObject(dataObject);
        }

        public void CopyDrawnLinesToClipboard()
        {
            DataObject dataObject = new DataObject();
            Bitmap drawnLines = new Bitmap(BackGroundImage.Width, BackGroundImage.Height);

            Draw(Graphics.FromImage(drawnLines));

            dataObject.SetData(typeof(Bitmap), drawnLines);
            Clipboard.SetDataObject(dataObject);
        }

        public void Save() => Save(FilePath);
        public void AddEmptyLine()
        {
            _lines.Add(new List<Point>());
            _colors.Add(_lastColorUsed);
            IsDirty = true;
        }
        public void AddLocationToLine(Point location) => _lines.Last().Add(location);
        public void RemoveLastLine() => _lines.RemoveAt(_lines.Count - 1);

        public void ChangeColor(Color color) => _lastColorUsed = color;
        #endregion

        #region Factory call an event - OnPropertyChanged
        private void OnPropertyChanged(string caller)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));

            var eventInfo = GetType().GetField(caller + "Changed", BindingFlags.Instance | BindingFlags.NonPublic);
            if (eventInfo != null)
            {
                var eventMember = eventInfo.GetValue(this);
                if (eventMember != null)
                {
                    eventMember.GetType().GetMethod("Invoke")
                        .Invoke(eventMember, new object[] { this, new EventArgs() });
                }
            }
        }
        #endregion
    }
}
