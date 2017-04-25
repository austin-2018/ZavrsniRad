namespace BaseApp
{
    partial class ChartForm
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
            this.TabContainer = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // TabContainer
            // 
            this.TabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabContainer.Location = new System.Drawing.Point(0, 0);
            this.TabContainer.Name = "TabContainer";
            this.TabContainer.SelectedIndex = 0;
            this.TabContainer.Size = new System.Drawing.Size(284, 261);
            this.TabContainer.TabIndex = 0;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TabContainer);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabContainer;
    }
}