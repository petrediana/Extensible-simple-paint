﻿namespace SimplePaint.FormApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.commandsControl1 = new SimplePaint.FormApplication.VisualControls.CommandsControl();
            this.editorControl1 = new SimplePaint.FormApplication.VisualControls.EditorControl();
            this.infoStatusControl1 = new SimplePaint.FormApplication.VisualControls.InfoStatusControl();
            this.SuspendLayout();
            // 
            // commandsControl1
            // 
            this.commandsControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandsControl1.Location = new System.Drawing.Point(0, 0);
            this.commandsControl1.Name = "commandsControl1";
            this.commandsControl1.Size = new System.Drawing.Size(583, 43);
            this.commandsControl1.TabIndex = 2;
            // 
            // editorControl1
            // 
            this.editorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorControl1.Location = new System.Drawing.Point(0, 0);
            this.editorControl1.Name = "editorControl1";
            this.editorControl1.Size = new System.Drawing.Size(583, 358);
            this.editorControl1.TabIndex = 1;
            // 
            // infoStatusControl1
            // 
            this.infoStatusControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoStatusControl1.Location = new System.Drawing.Point(0, 338);
            this.infoStatusControl1.Name = "infoStatusControl1";
            this.infoStatusControl1.Size = new System.Drawing.Size(583, 20);
            this.infoStatusControl1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 358);
            this.Controls.Add(this.infoStatusControl1);
            this.Controls.Add(this.commandsControl1);
            this.Controls.Add(this.editorControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private VisualControls.EditorControl editorControl1;
        private VisualControls.CommandsControl commandsControl1;
        private VisualControls.InfoStatusControl infoStatusControl1;
    }
}

