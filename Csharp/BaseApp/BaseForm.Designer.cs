namespace BaseApp
{
    partial class BaseForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLogDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideServerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilesListPanel = new System.Windows.Forms.Panel();
            this.FilesListView = new System.Windows.Forms.ListView();
            this.filesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.FilesListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(377, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.setLogDirectoryToolStripMenuItem,
            this.killServerToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.openToolStripMenuItem.Text = "Open File(s)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // setLogDirectoryToolStripMenuItem
            // 
            this.setLogDirectoryToolStripMenuItem.Name = "setLogDirectoryToolStripMenuItem";
            this.setLogDirectoryToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.setLogDirectoryToolStripMenuItem.Text = "Set Log Directory";
            this.setLogDirectoryToolStripMenuItem.Click += new System.EventHandler(this.SetLogDirectoryToolStripMenuItem_Click);
            // 
            // killServerToolStripMenuItem
            // 
            this.killServerToolStripMenuItem.Name = "killServerToolStripMenuItem";
            this.killServerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.killServerToolStripMenuItem.Text = "Kill Server";
            this.killServerToolStripMenuItem.Click += new System.EventHandler(this.KillServerToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesGeneratorToolStripMenuItem,
            this.hideServerInfoToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // filesGeneratorToolStripMenuItem
            // 
            this.filesGeneratorToolStripMenuItem.Name = "filesGeneratorToolStripMenuItem";
            this.filesGeneratorToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.filesGeneratorToolStripMenuItem.Text = "Files Generator";
            this.filesGeneratorToolStripMenuItem.Click += new System.EventHandler(this.FilesGeneratorToolStripMenuItem_Click);
            // 
            // hideServerInfoToolStripMenuItem
            // 
            this.hideServerInfoToolStripMenuItem.Name = "hideServerInfoToolStripMenuItem";
            this.hideServerInfoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.hideServerInfoToolStripMenuItem.Text = "Hide Server Info";
            this.hideServerInfoToolStripMenuItem.Click += new System.EventHandler(this.HideServerInfoToolStripMenuItem_Click);
            // 
            // FilesListPanel
            // 
            this.FilesListPanel.Controls.Add(this.FilesListView);
            this.FilesListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesListPanel.Location = new System.Drawing.Point(0, 24);
            this.FilesListPanel.Name = "FilesListPanel";
            this.FilesListPanel.Size = new System.Drawing.Size(377, 238);
            this.FilesListPanel.TabIndex = 4;
            // 
            // FilesListView
            // 
            this.FilesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filesColumnHeader});
            this.FilesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilesListView.FullRowSelect = true;
            this.FilesListView.GridLines = true;
            this.FilesListView.Location = new System.Drawing.Point(0, 0);
            this.FilesListView.Name = "FilesListView";
            this.FilesListView.Size = new System.Drawing.Size(377, 238);
            this.FilesListView.TabIndex = 0;
            this.FilesListView.UseCompatibleStateImageBehavior = false;
            this.FilesListView.View = System.Windows.Forms.View.Details;
            this.FilesListView.ItemActivate += new System.EventHandler(this.FilesListView_ItemActivate);
            this.FilesListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilesListView_KeyUp);
            this.FilesListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FilesListView_MouseDown);
            this.FilesListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FilesListView_MouseMove);
            // 
            // filesColumnHeader
            // 
            this.filesColumnHeader.Text = "Files";
            this.filesColumnHeader.Width = 192;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 262);
            this.Controls.Add(this.FilesListPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BaseForm";
            this.Text = "Base";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.FilesListPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem killServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setLogDirectoryToolStripMenuItem;
        private System.Windows.Forms.Panel FilesListPanel;
        private System.Windows.Forms.ListView FilesListView;
        private System.Windows.Forms.ColumnHeader filesColumnHeader;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideServerInfoToolStripMenuItem;
    }
}

