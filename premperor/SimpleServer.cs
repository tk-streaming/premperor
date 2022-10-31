using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Net;
using Fleck;
using System.Linq;

namespace premperor
{

    public class SimpleServer
    {
        private bool running = false;
        private ConcurrentQueue<CommentInfo> commentInfoQueue;
        private string[] idleMessage;
        private int indexOfIdleMessage = 0;
        private int idleCount = 0;
        public Action<CommentInfo> OnSend { get; set; }
        private IList<IWebSocketConnection> sockets = new List<IWebSocketConnection>();

        public SimpleServer(ConcurrentQueue<CommentInfo> commentInfoQueue)
        {
            this.commentInfoQueue = commentInfoQueue;
            this.idleMessage = Premperor.Default.IdleMessage.Split(new string[] { "\r\n" }, StringSplitOptions.None)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();
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
            server.Start(socket => {
                socket.OnOpen = () => {
                    sockets.Add(socket);
                };
                socket.OnClose = () => {
                    sockets.Remove(socket);
                };
            });

            Task.Run(() => {
                while (running)
                {
                    if (commentInfoQueue.TryDequeue(out var commentInfo) && commentInfo != null)
                    {
                        OnSend?.Invoke(commentInfo);
                        foreach (var socket in sockets)
                        {
                            var json = System.Text.Json.JsonSerializer.Serialize(new Payload("comment", commentInfo));
                            socket.Send(json);
                        }
                        Task.Delay((int)Premperor.Default.SendInterval).Wait();
                        this.idleCount = 0;
                    }
                    else
                    {
                        Task.Delay(100).Wait();
                        this.idleCount = this.idleCount + 100;

                        if (this.idleMessage.Length > 0 && this.idleCount > Premperor.Default.IdleMessageInterval)
                        {
                            var msg = this.idleMessage[this.indexOfIdleMessage];
                            foreach (var socket in sockets)
                            {
                                var json = System.Text.Json.JsonSerializer.Serialize(new Payload("message", msg));
                                socket.Send(json);
                            }

                            Task.Delay((int)Premperor.Default.SendInterval).Wait();
                            this.idleCount = 0;
                            this.indexOfIdleMessage = (this.indexOfIdleMessage + 1) % this.idleMessage.Length;
                        }
                    }
                }
            });
        }
    }

    public struct Payload
    {
        public Payload(string name, object data)
        {
            this.name = name;
            this.data = data;
        }
        public object data { get; set; }
        public string name { get; set; }
    }
}
