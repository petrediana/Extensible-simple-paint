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
            this.editorControl1 = new SimplePaint.FormApplication.VisualControls.EditorControl();
            this.SuspendLayout();
            // 
            // editorControl1
            // 
            this.editorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorControl1.Location = new System.Drawing.Point(0, 0);
            this.editorControl1.Name = "editorControl1";
            this.editorControl1.Size = new System.Drawing.Size(583, 360);
            this.editorControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 360);
            this.Controls.Add(this.editorControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private VisualControls.EditorControl editorControl1;
    }
}

