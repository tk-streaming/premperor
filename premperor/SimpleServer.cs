using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Net;
using Fleck;

namespace premperor
{

    public class SimpleServer
    {
        private bool running = false;
        private ConcurrentQueue<CommentInfo> commentInfoQueue;
        public Action<CommentInfo> OnSend { get; set; }
        private IList<IWebSocketConnection> sockets = new List<IWebSocketConnection>();

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
                            socket.Send(System.Text.Json.JsonSerializer.Serialize(commentInfo));
                        }
                        Task.Delay((int)Premperor.Default.SendInterval).Wait();
                    }
                    else
                    {
                        Task.Delay(100).Wait();
                    }
                }
            });
        }
    }
}
