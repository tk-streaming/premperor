using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace premperor
{
    public partial class MainForm : Form
    {
        private ConcurrentQueue<CommentInfo> commentInfoQueue = new ConcurrentQueue<CommentInfo>();

        private UserDbObserverBase observer;
        private SimpleServer server;
        public MainForm()
        {
            if (!System.IO.Directory.Exists(Premperor.Default.OneCommentDir))
            {
                if (!SetOneCommentDir())
                {
                    Environment.Exit(0);
                    return;
                }
            }

            try
            {
                server = new SimpleServer(commentInfoQueue);
                server.OnSend = (c) =>
                {
                    Invoke(new Action(() =>
                    {
                        tsslNumOfQueue.Text = $"Send: {c.username}";
                    }));
                };
                observer = Premperor.Default.ObservationType.ToLower() switch
                {
                    "pooling" => new PoolingUserDbObserver(),
                    _ => new WatchingTypeUserDbObserver(),
                };
                observer.OnReadCallback = onUpdateScore;

                InitializeComponent();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                using (var f = new System.IO.StreamWriter("./error.log"))
                {
                    f.WriteLine(e.Message);
                    f.WriteLine();
                    f.WriteLine(e.StackTrace);
                }
                Environment.Exit(0);
            }
        }

        private bool SetOneCommentDir()
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "わんコメのディレクトリを選択";
            fbd.SelectedPath = $@"{System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\live-comment-viewer";
            fbd.ShowNewFolderButton = false;
            var result = fbd.ShowDialog();
            if (result.HasFlag(DialogResult.OK))
            {
                Premperor.Default.OneCommentDir = fbd.SelectedPath;
                Premperor.Default.Save();
                return true;
            }
            return false;
        }

        private void onUpdateScore(IDictionary<string, CommentInfo> userDb, IEnumerable<CommentInfo> newComments)
        {
            try
            {
                foreach(var c in newComments)
                {
                    commentInfoQueue.Enqueue(c);
                }
                var sb = new StringBuilder();
                foreach (var x in userDb.OrderBy(s => s.Value.tc).Reverse().Take((int)Premperor.Default.RankingLimit))
                {
                    sb.AppendLine($"{x.Value.username}: {x.Value.tc}");
                }
                Invoke(new Action(() =>
                {
                    txtRanking.Text = sb.ToString();
                }));
            }
            catch(Exception)
            {
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            observer.ReadUserDb(false);
            server.Start();
            observer.StartObservation(this);
            tsslObservationType.Text = $"[{observer.GetName()}]";
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SettingsDialog();
            dialog.ShowDialog();
        }

        private void CopyURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText($"http://localhost:{Premperor.Default.HttpPort}/");
        }

        private void txtRanking_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
