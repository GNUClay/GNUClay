using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using GnuClay.CommonUtils.TypeHelpers;
using System.Threading.Tasks;
using System.IO;

namespace GnuClay.LocalHost
{
    /// <summary>
    /// The realization of the connector to GnuClay server for a local placing the group of the GnuClay NPCes.
    /// </summary>
    public class GnuClayLocalServer : IGnuClayServerConnection
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GnuClayLocalServer()
        {
        }

        private object mLockObj = new object();

        private bool mIsRunning = true;

        /// <summary>
        /// Returns true if this instance is active. Otherwise returns false.
        /// </summary>
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

        /// <summary>
        /// Suspends all GnuClay NPCes which contain on the server.
        /// </summary>
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

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("Suspend");
#endif
                var tmpTasksList = new List<Task>();

                foreach(var entity in mNPCConnectionDict)
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

        /// <summary>
        /// Resumes all GnuClay NPCes which contain on the server.
        /// </summary>
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

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("Resume");
#endif
                var tmpTasksList = new List<Task>();

                foreach (var entity in mNPCConnectionDict)
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

        /// <summary>
        /// Gets instance of the NPC with the name.
        /// If the NPC does not exist yet then the NPC with the name will be created and returned.
        /// </summary>
        /// <param name="npcName">The name of the target NPC.</param>
        /// <returns>Reference of the NPC with the name.</returns>
        public IGnuClayNPCConnection ConnectToNPC(string npcName)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                if (mNPCConnectionDict.ContainsKey(npcName))
                {
                    return mNPCConnectionDict[npcName];
                }

                var tmpInstance = new GnuClayNPCLocalHost(npcName, this);
                mNPCConnectionDict[npcName] = tmpInstance;

                return tmpInstance;
            }
        }

        /// <summary>
        /// Creates a new empty NPC with a random name (Guid) and returns the instance of the NPC.
        /// </summary>
        /// <returns>Reference to the created NPC.</returns>
        public IGnuClayNPCConnection CreateNPC()
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("CreateEntity");
#endif
                ValidateIsDestroyed();

                return ConnectToNPC(_ObjectHelper.CreateName());
            }
        }

        /// <summary>
        /// Creates a new NPC (with a random name (Guid)) by a byte array of the target image and returns the instance of the NPC.
        /// </summary>
        /// <param name="data">The byte array of the target image.</param>
        /// <returns>Reference to the created NPC.</returns>
        public IGnuClayNPCConnection CreateNPC(byte[] data)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("CreateEntity(byte[] data)");
#endif
                ValidateIsDestroyed();

                var targetEntity = CreateNPC();
                targetEntity.Load(data);

                return targetEntity;
            }
        }

        /// <summary>
        /// Destroys the target NPC by its name.
        /// </summary>
        /// <param name="npcName">The name of the target NPC.</param>
        public void DestroyNPC(string npcName)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"DestroyEntity entityName = {npcName}");
#endif
                ValidateIsDestroyed();

                if (mNPCConnectionDict.ContainsKey(npcName))
                {
                    var targetEntity = mNPCConnectionDict[npcName];
                    mNPCConnectionDict.Remove(npcName);
                    targetEntity.Destroy();
                }
            }
        }

        internal void RemoveNPC(IGnuClayNPCConnection npc)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveNPC npc.Name = {npc.Name}");
#endif
            if (mNPCConnectionDict.ContainsKey(npc.Name))
            {
                mNPCConnectionDict.Remove(npc.Name);
            }
        }

        /// <summary>
        /// Checks containing the NPC with such name on the server.
        /// Returns true if he NPC with such name contains on the server.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="npcName">The name of target NPC.</param>
        /// <returns>Result of checking.</returns>
        public bool ContainsNPC(string npcName)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ContainsEntity entityName = {npcName}");
#endif
                ValidateIsDestroyed();

                return mNPCConnectionDict.ContainsKey(npcName);
            }
        }

        /// <summary>
        /// Returns array of names of all NPCes which contained on the server.
        /// </summary>
        public string[] NPCesNames
        {
            get
            {
                return mNPCConnectionDict.Keys.ToArray();
            }
        }

        private Dictionary<string, IGnuClayNPCConnection> mNPCConnectionDict = new Dictionary<string, IGnuClayNPCConnection>();

        /// <summary>
        /// Loads all GnuClay NPCes from files of target directory activates them next.
        /// All previous information will be removed.
        /// </summary>
        /// <param name="directoryName">The target directory.</param>
        public void Load(string directoryName)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Load directoryName = {directoryName}");
#endif
                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                var targetFiles = Directory.GetFiles(directoryName, "*.gcd");

                foreach(var fileName in targetFiles)
                {
#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"Load fileName = {fileName}");
#endif
                    var tmpFileInfo = new FileInfo(fileName);
                    var targetEntityName = tmpFileInfo.Name.Substring(0, tmpFileInfo.Name.Length - tmpFileInfo.Extension.Length);
#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"Load targetEntityName = {targetEntityName}");
#endif
                    IGnuClayNPCConnection targetEntity = null;

                    if (mNPCConnectionDict.ContainsKey(targetEntityName))
                    {
                        targetEntity = mNPCConnectionDict[targetEntityName];
                    }
                    else
                    {
                        targetEntity = ConnectToNPC(targetEntityName);
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

        /// <summary>
        /// Saves all GnuClay NPCes to their files of target directory.
        /// After saving running continues if the NPC was activity before saving.
        /// </summary>
        /// <param name="directoryName">The target directory.</param>
        public void Save(string directoryName)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Save directoryName = {directoryName}");
#endif
                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                if(Directory.Exists(directoryName))
                {
                    Directory.Delete(directoryName, true);
                }

                Directory.CreateDirectory(directoryName);

                foreach (var entity in mNPCConnectionDict)
                {
                    var tmpEntity = entity.Value;
#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"tmpEntity.Name = `{tmpEntity.Name}`");
#endif
                    var targetPath = Path.Combine(directoryName, $"{tmpEntity.Name}.gcd");
#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"targetPath = `{targetPath}`");
#endif
                    tmpEntity.Save(targetPath);
                }

                if (tmpIsRunning)
                {
                    Resume();
                }
            }
        }

        /// <summary>
        /// Clears all of internal resources of each of the NPCes in the instace. And continues working without them. 
        /// </summary>
        public void Clear()
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");
#endif
                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                foreach (var entity in mNPCConnectionDict)
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

        /// <summary>
        /// Returns true if this instance is destryed. Otherwise returns false. 
        /// </summary>
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

        /// <summary>
        /// Stops and free all of internal resources.
        /// </summary>
        public void Destroy()
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("Destroy");
#endif
                if (mIsDestroyed)
                {
                    return;
                }

                mIsDestroyed = true;
                mIsRunning = false;

                var tmpTasksList = new List<Task>();

                foreach (var entity in mNPCConnectionDict)
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

        /// <summary>
        /// Stops and free all of internal resources.
        /// </summary>
        public void Dispose()
        {
            Destroy();
        }
    }
}
