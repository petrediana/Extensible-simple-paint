using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePaint.ObjectModel
{
    public class ApplicationModel
    {
        private ApplicationModel()
        {
            _paintDocument = new PaintDocument();
            _commands = new CommandCollection();
        }
        static ApplicationModel()
        {
            _instace = new ApplicationModel();
        }

        public event EventHandler OnQuit;

        #region Private Attributes definition
        private static readonly ApplicationModel _instace;
        private PaintDocument _paintDocument;
        private CommandCollection _commands;
        #endregion

        #region Public Properties Definitions: Instace, PaintDocument, Commands
        public static ApplicationModel Instace
        {
            get => _instace;
        }

        public PaintDocument PaintDocument
        {
            get => _paintDocument;
        }

        public CommandCollection Commands
        {
            get => _commands;
        }
        #endregion

        public void Quit() => OnQuit?.Invoke(this, new EventArgs());
    }
}
