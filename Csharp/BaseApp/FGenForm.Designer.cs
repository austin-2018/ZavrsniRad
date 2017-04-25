namespace BaseApp
{
    partial class FGenForm
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
            this.TbxInfo = new System.Windows.Forms.TextBox();
            this.NUDNumOfFiles = new System.Windows.Forms.NumericUpDown();
            this.NUDNumOfRecords = new System.Windows.Forms.NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNameOfFile = new System.Windows.Forms.Label();
            this.TbxNameOfFile = new System.Windows.Forms.TextBox();
            this.lblNumOfRecords = new System.Windows.Forms.Label();
            this.lblNumOfFiles = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.PBarFiles = new System.Windows.Forms.ProgressBar();
            this.PBarRecords = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDNumOfFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDNumOfRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PBarRecords);
            this.panel1.Controls.Add(this.PBarFiles);
            this.panel1.Controls.Add(this.TbxInfo);
            this.panel1.Controls.Add(this.NUDNumOfFiles);
            this.panel1.Controls.Add(this.NUDNumOfRecords);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.lblNameOfFile);
            this.panel1.Controls.Add(this.TbxNameOfFile);
            this.panel1.Controls.Add(this.lblNumOfRecords);
            this.panel1.Controls.Add(this.lblNumOfFiles);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 176);
            this.panel1.TabIndex = 0;
            // 
            // TbxInfo
            // 
            this.TbxInfo.Location = new System.Drawing.Point(109, 126);
            this.TbxInfo.Multiline = true;
            this.TbxInfo.Name = "TbxInfo";
            this.TbxInfo.ReadOnly = true;
            this.TbxInfo.Size = new System.Drawing.Size(239, 50);
            this.TbxInfo.TabIndex = 10;
            // 
            // NUDNumOfFiles
            // 
            this.NUDNumOfFiles.Location = new System.Drawing.Point(181, 61);
            this.NUDNumOfFiles.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDNumOfFiles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDNumOfFiles.Name = "NUDNumOfFiles";
            this.NUDNumOfFiles.Size = new System.Drawing.Size(100, 20);
            this.NUDNumOfFiles.TabIndex = 9;
            this.NUDNumOfFiles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDNumOfRecords
            // 
            this.NUDNumOfRecords.Location = new System.Drawing.Point(181, 87);
            this.NUDNumOfRecords.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDNumOfRecords.Name = "NUDNumOfRecords";
            this.NUDNumOfRecords.Size = new System.Drawing.Size(100, 20);
            this.NUDNumOfRecords.TabIndex = 8;
            this.NUDNumOfRecords.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.Location = new System.Drawing.Point(57, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 19);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Random Data File Generator";
            // 
            // lblNameOfFile
            // 
            this.lblNameOfFile.AutoSize = true;
            this.lblNameOfFile.Location = new System.Drawing.Point(12, 35);
            this.lblNameOfFile.Name = "lblNameOfFile";
            this.lblNameOfFile.Size = new System.Drawing.Size(80, 13);
            this.lblNameOfFile.TabIndex = 6;
            this.lblNameOfFile.Text = "Enter file name:";
            // 
            // TbxNameOfFile
            // 
            this.TbxNameOfFile.Location = new System.Drawing.Point(181, 35);
            this.TbxNameOfFile.Name = "TbxNameOfFile";
            this.TbxNameOfFile.Size = new System.Drawing.Size(100, 20);
            this.TbxNameOfFile.TabIndex = 5;
            this.TbxNameOfFile.Text = "DummyFile";
            this.TbxNameOfFile.TextChanged += new System.EventHandler(this.TbxNameOfFile_TextChanged);
            this.TbxNameOfFile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxNameOfFile_KeyPress);
            // 
            // lblNumOfRecords
            // 
            this.lblNumOfRecords.AutoSize = true;
            this.lblNumOfRecords.Location = new System.Drawing.Point(12, 87);
            this.lblNumOfRecords.Name = "lblNumOfRecords";
            this.lblNumOfRecords.Size = new System.Drawing.Size(157, 13);
            this.lblNumOfRecords.TabIndex = 4;
            this.lblNumOfRecords.Text = "Enter number of records per file:";
            // 
            // lblNumOfFiles
            // 
            this.lblNumOfFiles.AutoSize = true;
            this.lblNumOfFiles.Location = new System.Drawing.Point(12, 61);
            this.lblNumOfFiles.Name = "lblNumOfFiles";
            this.lblNumOfFiles.Size = new System.Drawing.Size(106, 13);
            this.lblNumOfFiles.TabIndex = 3;
            this.lblNumOfFiles.Text = "Enter number of files:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(3, 126);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // PBarFiles
            // 
            this.PBarFiles.ForeColor = System.Drawing.Color.DarkGreen;
            this.PBarFiles.Location = new System.Drawing.Point(109, 150);
            this.PBarFiles.Minimum = 1;
            this.PBarFiles.Name = "PBarFiles";
            this.PBarFiles.Size = new System.Drawing.Size(236, 23);
            this.PBarFiles.Step = 1;
            this.PBarFiles.TabIndex = 11;
            this.PBarFiles.Value = 1;
            this.PBarFiles.Visible = false;
            // 
            // PBarRecords
            // 
            this.PBarRecords.Location = new System.Drawing.Point(109, 126);
            this.PBarRecords.Minimum = 1;
            this.PBarRecords.Name = "PBarRecords";
            this.PBarRecords.Size = new System.Drawing.Size(236, 23);
            this.PBarRecords.Step = 1;
            this.PBarRecords.TabIndex = 12;
            this.PBarRecords.Value = 1;
            this.PBarRecords.Visible = false;
            // 
            // FGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 176);
            this.Controls.Add(this.panel1);
            this.Name = "FGenForm";
            this.Text = "Generator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDNumOfFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDNumOfRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNameOfFile;
        private System.Windows.Forms.TextBox TbxNameOfFile;
        private System.Windows.Forms.Label lblNumOfRecords;
        private System.Windows.Forms.Label lblNumOfFiles;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown NUDNumOfFiles;
        private System.Windows.Forms.NumericUpDown NUDNumOfRecords;
        private System.Windows.Forms.TextBox TbxInfo;
        private System.Windows.Forms.ProgressBar PBarRecords;
        private System.Windows.Forms.ProgressBar PBarFiles;
    }
}