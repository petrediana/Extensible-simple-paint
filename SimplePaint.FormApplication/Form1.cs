using SimplePaint.FormApplication.Commands;
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
        private PaintDocument _doc = ApplicationModel.Instace.PaintDocument;
        private ApplicationModel _model = ApplicationModel.Instace;

        public Form1()
        {
            InitializeComponent();

            _model.Commands.Add(new NewCommand());
            _model.Commands.Add(new SaveCommand());
            _model.Commands.Add(new LoadCommand());
            _model.Commands.Add(new ChangeColorCommand());
            _model.Commands.Add(new QuitCommand());

            UpdateFormTitle();

            _doc.FilePathChanged += (s, e) => UpdateFormTitle();
            _doc.IsDirtyChanged += (s, e) => UpdateFormTitle();

            _model.LoadAvailablePlugins();

            _model.OnQuit += (s, e) => Close();
        }

        private void UpdateFormTitle()
        {
            Text = string.Format("{0}{1} - Simple Paint Editor",
                    _doc.FileName, _doc.IsDirty ? "*" : string.Empty);
        }
    }
}
