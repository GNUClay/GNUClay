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

        public bool IsRunning
        {
            get
            {
                lock (mLockObj)
                {
                    return mIsRunning;
                }
            }
        }

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
                ValidateIsDestroyed();

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
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                if (mEntityConnectionDict.ContainsKey(entityName))
                {
                    return mEntityConnectionDict[entityName];
                }

                var tmpInstance = new GnuClayEntityLocalHost(entityName, this);
                mEntityConnectionDict[entityName] = tmpInstance;

                return tmpInstance;
            }
        }

        public IGnuClayEntityConnection CreateEntity()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("CreateEntity");

                ValidateIsDestroyed();

                return ConnectToEntity($"#{Guid.NewGuid().ToString("D")}");
            }
        }

        public IGnuClayEntityConnection CreateEntity(byte[] data)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("CreateEntity(byte[] data)");

                ValidateIsDestroyed();

                var targetEntity = CreateEntity();
                targetEntity.Load(data);

                return targetEntity;
            }
        }

        public void DestroyEntity(string entityName)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"DestroyEntity entityName = {entityName}");

                ValidateIsDestroyed();

                if (mEntityConnectionDict.ContainsKey(entityName))
                {
                    var targetEntity = mEntityConnectionDict[entityName];
                    mEntityConnectionDict.Remove(entityName);
                    targetEntity.Destroy();
                }
            }
        }

        internal void RemoveEntity(IGnuClayEntityConnection entity)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"RemoveEntity entity.Name = {entity.Name}");

                if (mEntityConnectionDict.ContainsKey(entity.Name))
                {
                    mEntityConnectionDict.Remove(entity.Name);
                }
            }
        }

        public bool ContainsEntity(string entityName)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"ContainsEntity entityName = {entityName}");

                ValidateIsDestroyed();

                return mEntityConnectionDict.ContainsKey(entityName);
            }
        }

        private Dictionary<string, IGnuClayEntityConnection> mEntityConnectionDict = new Dictionary<string, IGnuClayEntityConnection>();

        public void Load()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Load");

                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                throw new NotImplementedException();

                foreach (var enityConnection in mEntityConnectionDict)
                {
                    throw new NotImplementedException();
                }

                throw new NotImplementedException();

                if (tmpIsRunning)
                {
                    Resume();
                }
            }
        }

        public void Load(string name)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Load name = {name}");

                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                throw new NotImplementedException();

                foreach (var enityConnection in mEntityConnectionDict)
                {
                    throw new NotImplementedException();
                }

                throw new NotImplementedException();

                if (tmpIsRunning)
                {
                    Resume();
                }
            }
        }

        public void Save()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Save");

                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                throw new NotImplementedException();

                foreach (var enityConnection in mEntityConnectionDict)
                {
                    throw new NotImplementedException();
                }

                throw new NotImplementedException();

                if (tmpIsRunning)
                {
                    Resume();
                }
            }
        }

        public void Save(string name)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Save name = {name}");

                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                throw new NotImplementedException();

                foreach (var enityConnection in mEntityConnectionDict)
                {
                    throw new NotImplementedException();
                }

                throw new NotImplementedException();

                if (tmpIsRunning)
                {
                    Resume();
                }
            }
        }

        public void Clear()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");

                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                foreach (var enityConnection in mEntityConnectionDict)
                {
                    enityConnection.Value.Clear();
                }

                if (tmpIsRunning)
                {
                    Resume();
                }
            }
        }

        private void ValidateIsDestroyed()
        {
            throw new ApplicationException("The GnuClay local server was destroyed.");
        }

        private bool mIsDestroyed = false;

        public bool IsDestroyed
        {
            get
            {
                lock (mLockObj)
                {
                    return mIsDestroyed;
                }
            }
        }

        public void Destroy()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Destroy");

                if (mIsDestroyed)
                {
                    return;
                }

                mIsDestroyed = true;

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                foreach (var enityConnection in mEntityConnectionDict)
                {
                    enityConnection.Value.Destroy();
                }
            }   
        }
    }
}
