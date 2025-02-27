﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplePaint.ObjectModel;

namespace PluginCopy
{
    public class CopyCommand : Command
    {
        public CopyCommand() : base("Copy All", ResourceImages.CopyAllImage) { }
        public override void Execute()
        {
            PaintDocument document = ApplicationModel.Instace.PaintDocument;
            document.CopyToClipboard();
        }
    }
}
