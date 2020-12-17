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

        public Form1()
        {
            InitializeComponent();

        }
    }
}
