﻿using System;
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
        #endregion

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

        #region Implementing some basic features
        public void New()
        {
            _lines = new List<List<Point>>();
            _isDrawing = false;

            FilePath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "untitledPicture.txt"
                                    );
            IsDirty = false;
        }

        public void Save(string filePath)
        {
            BackGroundImage.Save(filePath);
        }

        public void Load(string filePath)
        {
            BackGroundImage = Image.FromFile(filePath);
            FilePath = filePath;
            IsDirty = false;
        }

        public void Save() => Save(FilePath);
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
