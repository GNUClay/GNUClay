using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.LocalHost
{
    public class GnuClayLocalServer : IGnuClayServerConnection
    {
        private object mLockObj = new object();
        private bool mIsRunning = true;

        public void Suspend()
        {
            lock(mLockObj)
            {
                if (!mIsRunning)
                {
                    return;
                }

                mIsRunning = false;

                NLog.LogManager.GetCurrentClassLogger().Info("Suspend");

                var tmpTasksList = new List<Task>();

                foreach(var entity in mEntityConnectionDict)
                {
                    var tmpTask = new Task(() => {
                        entity.Value.Suspend();
                    });
                    tmpTasksList.Add(tmpTask);
                    tmpTask.Start();
                }

                Task.WaitAll(tmpTasksList.ToArray());
            }
        }

        public void Resume()
        {
            lock (mLockObj)
            {
                if (mIsRunning)
                {
                    return;
                }

                mIsRunning = true;

                NLog.LogManager.GetCurrentClassLogger().Info("Resume");

                var tmpTasksList = new List<Task>();

                foreach (var entity in mEntityConnectionDict)
                {
                    var tmpTask = new Task(() => {
                        entity.Value.Resume();
                    });
                    tmpTasksList.Add(tmpTask);
                    tmpTask.Start();
                }

                Task.WaitAll(tmpTasksList.ToArray());
            }
        }

        public IGnuClayEntityConnection ConnectToEntity(string entityName)
        {
            if(mEntityConnectionDict.ContainsKey(entityName))
            {
                return mEntityConnectionDict[entityName];
            }

            var tmpInstance = new GnuClayEntityLocalHost(entityName);
            mEntityConnectionDict[entityName] = tmpInstance;

            return tmpInstance;
        }

        private Dictionary<string, IGnuClayEntityConnection> mEntityConnectionDict = new Dictionary<string, IGnuClayEntityConnection>();
    }
}
