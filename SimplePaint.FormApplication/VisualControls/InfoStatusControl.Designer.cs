namespace SimplePaint.FormApplication.VisualControls
{
    partial class InfoStatusControl
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.coordinatesStatusStripItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.linesDrawnStatusStripItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinatesStatusStripItem,
            this.linesDrawnStatusStripItem});
            this.statusStrip1.Location = new System.Drawing.Point(0, 28);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(427, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // coordinatesStatusStripItem
            // 
            this.coordinatesStatusStripItem.Name = "coordinatesStatusStripItem";
            this.coordinatesStatusStripItem.Size = new System.Drawing.Size(100, 17);
            this.coordinatesStatusStripItem.Text = "Coordinates: (x,y)";
            // 
            // linesDrawnStatusStripItem
            // 
            this.linesDrawnStatusStripItem.Name = "linesDrawnStatusStripItem";
            this.linesDrawnStatusStripItem.Size = new System.Drawing.Size(118, 17);
            this.linesDrawnStatusStripItem.Text = "Lines drawn: number";
            // 
            // InfoStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "InfoStatusControl";
            this.Size = new System.Drawing.Size(427, 50);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel coordinatesStatusStripItem;
        private System.Windows.Forms.ToolStripStatusLabel linesDrawnStatusStripItem;
    }
}
