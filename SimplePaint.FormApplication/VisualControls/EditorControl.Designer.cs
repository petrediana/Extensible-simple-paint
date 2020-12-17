namespace SimplePaint.FormApplication.VisualControls
{
    partial class EditorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawingCanvasPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // drawingCanvasPanel
            // 
            this.drawingCanvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingCanvasPanel.Location = new System.Drawing.Point(0, 0);
            this.drawingCanvasPanel.Name = "drawingCanvasPanel";
            this.drawingCanvasPanel.Size = new System.Drawing.Size(433, 261);
            this.drawingCanvasPanel.TabIndex = 0;
            // 
            // EditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drawingCanvasPanel);
            this.Name = "EditorControl";
            this.Size = new System.Drawing.Size(433, 261);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawingCanvasPanel;
    }
}
