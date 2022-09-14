using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace premperor
{
    public abstract class UserDbObserverBase
    {
        protected IDictionary<string, CommentInfo> previousUserDb;
        public Action<IDictionary<string, CommentInfo>, IEnumerable<CommentInfo>> OnReadCallback { get; set; }
        public abstract void StartObservation(System.ComponentModel.ISynchronizeInvoke sync);

        public abstract string GetName();
        public void ReadUserDb(bool doFindNewComments = true)
        {
            var userDb = new Dictionary<string, CommentInfo>();
            var newComments = Enumerable.Empty<CommentInfo>();
            try
            {
                using var fs = new FileStream($"{Premperor.Default.OneCommentDir}\\user.db", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var f = new StreamReader(fs);
                var data = (IDictionary<string, object>)Util.ParseJson(f.ReadToEnd());
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
        protected IEnumerable<CommentInfo> FindNewComments(IDictionary<string, CommentInfo> newUserDb)
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
    }

    public class PoolingUserDbObserver : UserDbObserverBase
    {
        public override string GetName() { return "Pooling Mode"; }
        public override void StartObservation(System.ComponentModel.ISynchronizeInvoke sync)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    ReadUserDb();
                    Task.Delay((int)Premperor.Default.PoolingTypeObservationInterval).Wait();
                }
            });
        }
    }

    public class WatchingTypeUserDbObserver : UserDbObserverBase
    {
        public override string GetName() { return "Watching Mode"; }
        private FileSystemWatcher watcher;
        public override void StartObservation(System.ComponentModel.ISynchronizeInvoke sync)
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
    }
}
