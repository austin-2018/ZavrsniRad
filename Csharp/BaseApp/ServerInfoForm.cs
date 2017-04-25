using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaseApp
{
    public partial class ServerInfoForm : Form
    {
        private BaseForm thisOwner;
        public TextBox InfoBox
        {
            get { return TbxSrvInfo; }
        }

        public ServerInfoForm(BaseForm owner)
        {
            InitializeComponent();
            thisOwner = owner;
        }

        private void ServerInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            (thisOwner.MainMenuStrip.Items.Find("hideServerInfoToolStripMenuItem", true)[0]).Text = "Show Server Info";
            e.Cancel = true;
        }
    }
}
