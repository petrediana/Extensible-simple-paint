using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace SimplePaint.ObjectModel
{
    public abstract class Command : INotifyPropertyChanged
    {
        public Command(string name, Image image = null, bool isEnabled = true)
        {

        }

        public abstract void Execute();

        public event PropertyChangedEventHandler PropertyChanged;

        #region Private Attributes definition
        private string _name;
        private Image _image;
        private bool _isEnabled;
        #endregion

        #region Public Properties Definitions: Name, Image, IsEnabled
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public Image Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }
        #endregion

        private void OnPropertyChanged(string caller) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}
