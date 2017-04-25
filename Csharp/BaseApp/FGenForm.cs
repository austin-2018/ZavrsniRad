using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BaseApp
{
    public partial class FGenForm : Form
    {
        private string fileName;
        private string filePath;

        public FGenForm(string path)
        {
            InitializeComponent();
            filePath = path;
            fileName = TbxNameOfFile.Text;
            TbxInfo.Text = filePath;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            PBarFiles.Maximum = Decimal.ToInt32(NUDNumOfFiles.Value);
            PBarFiles.Visible = true;
            PBarFiles.Value = 1;
            PBarRecords.Maximum = Decimal.ToInt32(NUDNumOfRecords.Value);
            PBarRecords.Visible = true;
            PBarRecords.Value = 1;

            for (int i = 0; i < NUDNumOfFiles.Value; ++i)
            {
                string fullPath = Path.Combine(filePath, fileName + "_" + i + ".bin");

                for (int j = 0; j < NUDNumOfRecords.Value; j++)
                {
                    Random rnd = new Random(fullPath.GetHashCode() / (j+1));
                    byte[] data = new byte[6];
                    data[0] = 204;
                    data[1] = (byte)'%';
                    data[2] = (byte)rnd.Next(20, 126);
                    data[3] = (byte)rnd.Next(20, 126);
                    data[4] = (byte)rnd.Next(20, 126);
                    data[5] = 185;

                    Logger.Log(fullPath, data);
                    PBarRecords.PerformStep();
                }
                PBarFiles.PerformStep();
                PBarRecords.Value = 1;
            }

            PBarFiles.Visible = false;
            PBarRecords.Visible = false;
        }

        private void TbxNameOfFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                e.Handled = false;
                return;
            }

            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void TbxNameOfFile_TextChanged(object sender, EventArgs e)
        {
            if (TbxNameOfFile.Text.Length < 1)
            {
                TbxNameOfFile.BackColor = Color.Red;
                btnGenerate.Enabled = false;
                return;
            }

            TbxNameOfFile.BackColor = Color.White;
            fileName = TbxNameOfFile.Text;
            btnGenerate.Enabled = true;
        }
    }
}
