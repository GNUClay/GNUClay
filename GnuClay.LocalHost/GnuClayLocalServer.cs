using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using GnuClay.CommonUtils.TypeHelpers;
using System.Threading.Tasks;
using System.IO;

namespace GnuClay.LocalHost
{
    public class GnuClayLocalServer : IGnuClayServerConnection
    {
        public GnuClayLocalServer()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GnuClayLocalServer");
        }

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
                ValidateIsDestroyed();

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

                return ConnectToEntity(_ObjectHelper.CreateName());
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
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveEntity entity.Name = {entity.Name}");

            if (mEntityConnectionDict.ContainsKey(entity.Name))
            {
                mEntityConnectionDict.Remove(entity.Name);
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

        public string[] EntitiesNames
        {
            get
            {
                return mEntityConnectionDict.Keys.ToArray();
            }
        }

        private Dictionary<string, IGnuClayEntityConnection> mEntityConnectionDict = new Dictionary<string, IGnuClayEntityConnection>();

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

                var targetFiles = Directory.GetFiles(name, "*.gcd");

                foreach(var fileName in targetFiles)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"Load fileName = {fileName}");

                    var tmpFileInfo = new FileInfo(fileName);
                    var targetEntityName = tmpFileInfo.Name.Substring(0, tmpFileInfo.Name.Length - tmpFileInfo.Extension.Length);

                    NLog.LogManager.GetCurrentClassLogger().Info($"Load targetEntityName = {targetEntityName}");

                    IGnuClayEntityConnection targetEntity = null;

                    if (mEntityConnectionDict.ContainsKey(targetEntityName))
                    {
                        targetEntity = mEntityConnectionDict[targetEntityName];
                    }
                    else
                    {
                        targetEntity = ConnectToEntity(targetEntityName);
                        targetEntity.Suspend();
                    }

                    targetEntity.Load(fileName);
                }

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

                if(Directory.Exists(name))
                {
                    Directory.Delete(name, true);
                }

                Directory.CreateDirectory(name);

                foreach (var entity in mEntityConnectionDict)
                {
                    var tmpEntity = entity.Value;

                    NLog.LogManager.GetCurrentClassLogger().Info($"tmpEntity.Name = `{tmpEntity.Name}`");

                    var targetPath = Path.Combine(name, $"{tmpEntity.Name}.gcd");

                    NLog.LogManager.GetCurrentClassLogger().Info($"targetPath = `{targetPath}`");

                    tmpEntity.Save(targetPath);
                }

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

                foreach (var entity in mEntityConnectionDict)
                {
                    entity.Value.Clear();
                }

                if (tmpIsRunning)
                {
                    Resume();
                }
            }
        }

        private void ValidateIsDestroyed()
        {
            if (mIsDestroyed)
            {
                throw new ApplicationException("The GnuClay local server was destroyed.");
            }           
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
                mIsRunning = false;

                var tmpTasksList = new List<Task>();

                foreach (var entity in mEntityConnectionDict)
                {
                    var tmpTask = new Task(() => {
                        entity.Value.Destroy();
                    });
                    tmpTasksList.Add(tmpTask);
                    tmpTask.Start();
                }

                Task.WaitAll(tmpTasksList.ToArray());
            }   
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}
