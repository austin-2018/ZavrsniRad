namespace BaseApp
{
    partial class PlotForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbxPlot = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.pbxPlot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 526);
            this.panel1.TabIndex = 0;
            // 
            // pbxPlot
            // 
            this.pbxPlot.BackColor = System.Drawing.Color.Black;
            this.pbxPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxPlot.Location = new System.Drawing.Point(0, 0);
            this.pbxPlot.Name = "pbxPlot";
            this.pbxPlot.Size = new System.Drawing.Size(837, 526);
            this.pbxPlot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxPlot.TabIndex = 1;
            this.pbxPlot.TabStop = false;
            this.pbxPlot.Paint += new System.Windows.Forms.PaintEventHandler(this.PbxPlot_Paint);
            // 
            // PlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 526);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "PlotForm";
            this.Text = "PlotForm";
            this.Resize += new System.EventHandler(this.PlotForm_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbxPlot;
    }
}