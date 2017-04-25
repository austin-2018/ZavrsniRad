using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace BaseApp
{
    public partial class BaseForm : Form
    {
        private Server server;
        private Thread serverThread;
        private ServerInfoForm serverInfoForm;
        private ListViewItem firstItem;
        private ListViewItem lastItem;

        private string logDirPath;
        public string LogPath
        {
            get { return logDirPath; }
        }

        public BaseForm()
        {
            InitializeComponent();
            logDirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ServerLogs\";
            serverInfoForm = new ServerInfoForm(this);
            serverInfoForm.Show();
            server = new Server(this, serverInfoForm.InfoBox);
            serverThread = new Thread(new ThreadStart(server.Start));
            serverThread.Start();
        }

        private string SetLogDir()
        {
            string logDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ServerLogs\";

            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            };
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                logDir = fbd.SelectedPath;
            }
            MessageBox.Show("Logging directory set to:\n" + logDir, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return logDir;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (serverThread != null && serverThread.IsAlive)
                {
                    serverThread.Abort();
                }
                Application.Exit();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = LogPath,
                Filter = "Binary files (*.bin)|*.bin|Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 0,
                RestoreDirectory = true,
                Multiselect = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] selectedFiles = ofd.FileNames;
                    foreach (string f in selectedFiles)
                    {
                        string name = Path.GetFileNameWithoutExtension(f);
                        ListViewItem fileItem = new ListViewItem(name)
                        {
                            Tag = f
                        };
                        FilesListView.Items.Add(fileItem);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " :: " + ex.StackTrace, "Exception!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ofd.Dispose();
        }

        private void KillServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serverThread != null && serverThread.IsAlive)
            {
                if (MessageBox.Show("Are you sure you want to abort the Server thread?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    serverThread.Abort();
                }
            }
        }

        private void SetLogDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logDirPath = SetLogDir();
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverThread != null && serverThread.IsAlive)
            {
                serverThread.Abort();
            }
        }

        private void FilesGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FGenForm genForm = new FGenForm(LogPath);
            genForm.Show();
        }

        private void FilesListView_ItemActivate(object sender, EventArgs e)
        {
            //foreach (ListViewItem fileItem in FilesListView.SelectedItems)
            //{
            //PlotForm plot = new PlotForm(fileItem.Tag.ToString());
            //plot.Show();
            //}
            string[] files = new string[FilesListView.SelectedItems.Count];
            for(int i= 0;i<files.Length;++i)
            {
                files[i] = FilesListView.SelectedItems[i].Tag.ToString();
            }
            ChartForm cf = new ChartForm(files);
            cf.Show();
        }

        private void FilesListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left && FilesListView.HitTest(e.Location).Item != null)
            {
                firstItem = FilesListView.HitTest(e.Location).Item;
                firstItem.Selected = true;
            }
        }

        private void FilesListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Left)
            {
                ListViewItem item = FilesListView.HitTest(e.Location).Item;
                if (item != null)
                {
                    if (!firstItem.Equals(item))
                    {
                        item.Selected = true;
                        lastItem = item;
                        foreach (ListViewItem lvItem in FilesListView.Items)
                        {
                            lvItem.Selected = (lvItem.Index >= firstItem.Index && lvItem.Index <= lastItem.Index) || (lvItem.Index <= firstItem.Index && lvItem.Index >= lastItem.Index);
                        }
                    }
                    else
                    {
                        if (lastItem != null) lastItem.Selected = false;
                    }
                }
            }
        }

        private void HideServerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serverInfoForm.Visible == true)
            {
                (sender as ToolStripMenuItem).Text = "Show Server Info";
                serverInfoForm.Hide();
            }
            else
            {
                (sender as ToolStripMenuItem).Text = "Hide Server Info";
                serverInfoForm.Show();
            }
        }

        private void FilesListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem lvItem in FilesListView.SelectedItems)
                {
                    lvItem.Remove();
                }
            }
        }
    }
}
