using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace premperor
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            txtOneCommentDir.Text = Premperor.Default.OneCommentDir;
            txtDisplayPath.Text = Premperor.Default.DisplayHtmlPath;
            numHttpPort.Value = Premperor.Default.HttpPort;
            numWsPort.Value = Premperor.Default.WsPort;
            numSendInterval.Value = Premperor.Default.SendInterval;
            numRankingLimit.Value = Premperor.Default.RankingLimit;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Premperor.Default.OneCommentDir = txtOneCommentDir.Text;
            Premperor.Default.DisplayHtmlPath = txtDisplayPath.Text;
            Premperor.Default.HttpPort = (uint)numHttpPort.Value;
            Premperor.Default.WsPort = (uint)numWsPort.Value;
            Premperor.Default.SendInterval = (uint)numSendInterval.Value;
            Premperor.Default.RankingLimit = (uint)numRankingLimit.Value;
            Premperor.Default.Save();
            Close();
            Application.Exit();
        }

        private void btnFindOneCommentDir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "わんコメのディレクトリを選択";
            fbd.SelectedPath = $@"{System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\live-comment-viewer";
            fbd.ShowNewFolderButton = false;
            var result = fbd.ShowDialog();
            if (result.HasFlag(DialogResult.OK))
            {
                this.txtOneCommentDir.Text = fbd.SelectedPath;
            }
        }

        private void btnFindDisplay_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "HTML file|*.html;*.htm|All files|*.*";
            var result = ofd.ShowDialog();
            if (result.HasFlag(DialogResult.OK))
            {
                this.txtDisplayPath.Text = ofd.FileName;
            }
        }
    }
}
