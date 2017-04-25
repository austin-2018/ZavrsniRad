namespace BaseApp
{
    partial class ServerInfoForm
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
            this.TbxSrvInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TbxSrvInfo
            // 
            this.TbxSrvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbxSrvInfo.Location = new System.Drawing.Point(0, 0);
            this.TbxSrvInfo.Multiline = true;
            this.TbxSrvInfo.Name = "TbxSrvInfo";
            this.TbxSrvInfo.ReadOnly = true;
            this.TbxSrvInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbxSrvInfo.Size = new System.Drawing.Size(284, 261);
            this.TbxSrvInfo.TabIndex = 0;
            // 
            // ServerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TbxSrvInfo);
            this.Name = "ServerInfoForm";
            this.Text = "Server Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerInfoForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbxSrvInfo;
    }
}