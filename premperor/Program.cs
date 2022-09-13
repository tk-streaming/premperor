using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using Fleck;
using System.Collections.Concurrent;

namespace premperor
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class SimpleServer
    {
        private bool running = false;
        private ConcurrentQueue<CommentInfo> commentInfoQueue;
        public Action<CommentInfo> OnSend { get; set; }

        public SimpleServer(ConcurrentQueue<CommentInfo> commentInfoQueue)
        {
            this.commentInfoQueue = commentInfoQueue;
        }

        public void Start()
        {
            running = true;
            StartHttp((int)Premperor.Default.HttpPort);
            StartWebswcoket((int)Premperor.Default.WsPort);
        }

        private void StartHttp(int port)
        {
            var listener = new HttpListener();
            listener.Prefixes.Clear();
            listener.Prefixes.Add($@"http://+:{port}/");
            listener.Start();

            Task.Run(() => {
                while (running)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    if (request != null)
                    {
                        using (var f = new System.IO.StreamReader(Premperor.Default.DisplayHtmlPath))
                        {
                            var text = System.Text.Encoding.UTF8.GetBytes(f.ReadToEnd());
                            response.OutputStream.Write(text, 0, text.Length);
                        }                        
                    }
                    else
                    {
                        response.StatusCode = 404;
                    }
                    response.Close();
                }
            });

        }

        private void StartWebswcoket(int port)
        {
            var server = new WebSocketServer($"ws://127.0.0.1:{port}");
            server.Start(socket =>
            {
                Task.Run(() => { 
                    while(running)
                    {
                        if (commentInfoQueue.TryDequeue(out var commentInfo) && commentInfo != null)
                        {
                            OnSend?.Invoke(commentInfo);
                            socket.Send(System.Text.Json.JsonSerializer.Serialize(commentInfo));
                            Task.Delay((int)Premperor.Default.SendInterval).Wait();
                        }
                        else
                        {
                            Task.Delay(100).Wait();
                        }
                    }
                });
            });
        }
    }

    public class CommentInfo
    {
        public string id { get; set; }
        public string username { get; set; }
        public string nickname { get; set; }
        public string icon { get; set; }
        public string lang { get; set; }
        public string service { get; set; }
        public bool allowIcon { get; set; }
        public decimal interval { get; set; }
        public decimal tc { get; set; }
        public decimal tgc { get; set; }
    }

    public class UserDbObserver
    {
        private FileSystemWatcher watcher;
        private IDictionary<string, CommentInfo> previousUserDb;

        public Action<IDictionary<string, CommentInfo>, IEnumerable<CommentInfo>> OnReadCallback { get; set; }



        public void StartObservation(System.ComponentModel.ISynchronizeInvoke sync)
        {
            if (watcher != null) return;
            watcher = new FileSystemWatcher(Premperor.Default.OneCommentDir);
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.Renamed += (sender, e) => {
                ReadUserDb();
            };

            watcher.Filter = "user.db";
            watcher.SynchronizingObject = sync;
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;
        }

        public void StopObservation()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            watcher = null;
        }


        public void ReadUserDb(bool doFindNewComments = true)
        {
            var userDb = new Dictionary<string, CommentInfo>();
            var newComments = Enumerable.Empty<CommentInfo>();
            try
            {
                using var fs = new FileStream($"{Premperor.Default.OneCommentDir}\\user.db", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var f = new StreamReader(fs);
                var data = (IDictionary<string, object>)ParseJson(f.ReadToEnd());
                var userIds = data.Keys.Where(key => System.Text.RegularExpressions.Regex.IsMatch(key, @"^[^_]"));
                foreach (var userId in userIds)
                {
                    var user = (IDictionary<string, object>)(data[userId]);
                    var commentInfo = new CommentInfo()
                    {
                        id = (string)(user["id"]),
                        username = (string)(user["username"]),
                        nickname = (string)(user["nickname"]),
                        icon = (string)(user["icon"]),
                        lang = (string)(user["lang"]),
                        service = (string)(user["service"]),
                        allowIcon = (bool)(user["allowIcon"]),
                        interval = (decimal)(user["interval"]),
                        tc = (decimal)(user["tc"]),
                        tgc = (decimal)(user["tgc"]),
                    };
                    userDb.Add(userId, commentInfo);
                }

                if (OnReadCallback != null)
                {
                    if (doFindNewComments)
                    {
                        newComments = FindNewComments(userDb);
                    }
                    OnReadCallback.Invoke(userDb, newComments);
                }
                previousUserDb = userDb;
            }
            catch (Exception) 
            {
            }
        }

        private IEnumerable<CommentInfo> FindNewComments (IDictionary<string, CommentInfo> newUserDb)
        {
            if (previousUserDb == null) return Enumerable.Empty<CommentInfo>();
            var newCommnets = new List<CommentInfo>();
            foreach (var c in newUserDb)
            {
                var prevTc = previousUserDb.ContainsKey(c.Key) ? previousUserDb[c.Key].tc : 0;
                if (prevTc < c.Value.tc)
                {
                    newCommnets.Add(c.Value);
                }
            }
            return newCommnets;
        }

        private static System.Dynamic.ExpandoObject ParseJson(string json)
        {
            using var document = System.Text.Json.JsonDocument.Parse(json);
            return toExpandoObject(document.RootElement);
            static object propertyValue(System.Text.Json.JsonElement elm) =>
                elm.ValueKind switch
                {
                    System.Text.Json.JsonValueKind.Null => null,
                    System.Text.Json.JsonValueKind.Number => elm.GetDecimal(),
                    System.Text.Json.JsonValueKind.String => elm.GetString(),
                    System.Text.Json.JsonValueKind.False => false,
                    System.Text.Json.JsonValueKind.True => true,
                    System.Text.Json.JsonValueKind.Array => elm.EnumerateArray().Select(m => propertyValue(m)).ToArray(),
                    _ => toExpandoObject(elm),
                };
            static System.Dynamic.ExpandoObject toExpandoObject(System.Text.Json.JsonElement elm) =>
                elm.EnumerateObject()
                .Aggregate(
                    new System.Dynamic.ExpandoObject(),
                    (exo, prop) => { ((IDictionary<string, object>)exo).Add(prop.Name, propertyValue(prop.Value)); return exo; });
        }
    }
}
