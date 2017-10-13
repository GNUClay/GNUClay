using GnuClay.CommonClientTypes;
using GnuClay.Engine;
using System;
using System.Collections.Generic;
using GnuClay.CommonClientTypes.CommonData;
using System.IO;
using System.IO.Compression;

namespace GnuClay.LocalHost
{
    /// <summary>
    /// The realization of the GnuClay NPC connector for a local placing the GnuClay engine. 
    /// </summary>
    public class GnuClayNPCLocalHost: IGnuClayNPCConnection
    {
        private object mLockObj = new object();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="npcName">String value that will be correspond with the instance.</param>
        /// <param name="server">Reference to the local server.</param>
        public GnuClayNPCLocalHost(string npcName, GnuClayLocalServer server)
        {
            mNPCName = npcName;
            mServer = server;

            GnuClayEngine = new GnuClayEngine();
        }

        private string mNPCName;
        private GnuClayLocalServer mServer;
        private GnuClayEngine GnuClayEngine;

        /// <summary>
        /// Returns the name of the GnuClay NPC.
        /// </summary>
        public string Name
        {
            get
            {
                return mNPCName;
            }
        }

        /// <summary>
        /// Suspends the instance.
        /// </summary>
        public void Suspend()
        {
            lock(mLockObj)
            {
                GnuClayEngine.Suspend();
            }           
        }

        /// <summary>
        /// Resumes the instance.
        /// </summary>
        public void Resume()
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                GnuClayEngine.Resume();
            }         
        }

        /// <summary>
        /// Returns true if this instance is active. Otherwise returns false.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                lock (mLockObj)
                {
                    return GnuClayEngine.IsRunning;
                }          
            }
        }

        /// <summary>
        /// Executes query from text and returns result of the executing.
        /// </summary>
        /// <param name="text">The text with the query.</param>
        /// <returns>The result of the executing</returns>
        public ISelectResult Query(string text)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Query text = `{text}`");
#endif
                ValidateIsDestroyed();

                return GnuClayEngine.Query(text);
            }
        }

        /// <summary>
        /// Returns the key of the string value from its internal data dictionary.
        /// </summary>
        /// <param name="val">The target string value</param>
        /// <returns>The key of the string value.</returns>
        public ulong GetKey(string val)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.GetKey(val);
            }
        }

        /// <summary>
        /// Get the string value which is associated with that key.
        /// </summary>
        /// <param name="key">Key of the value</param>
        /// <returns>Associated string value.</returns>
        public string GetValue(ulong key)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.GetValue(key);
            }        
        }

        /// <summary>
        /// Loads image of GnuClay NPC form file and activates it next.
        /// All previous information will be removed.
        /// </summary>
        /// <param name="fileName">The name of the file which contains the image of GnuClay NPC.</param>
        public void Load(string fileName)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Load name = `{fileName}`");
#endif
                ValidateIsDestroyed();

                using (var originalStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (var decompressionStream = new GZipStream(originalStream, CompressionMode.Decompress))
                    {
                        using (var decompressedStream = new MemoryStream())
                        {
                            decompressionStream.CopyTo(decompressedStream);

                            GnuClayEngine.Load(decompressedStream.ToArray());
                        }
                    }                     
                }            
            }
        }

        /// <summary>
        /// Loads image of GnuClay NPC form array of bytes and activates it next.
        /// All previous information will be removed.
        /// </summary>
        /// <param name="data">Reference to the array of bytes.</param>
        public void Load(byte[] data)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info(" Load(byte[] data)");
#endif
                ValidateIsDestroyed();

                GnuClayEngine.Load(data);
            }
        }

        /// <summary>
        /// Saves image of GnuClay NPC to a file. After saving running continues if the NPC was activity before saving.
        /// </summary>
        /// <param name="fileName">The name of the file which will contain the image of GnuClay NPC.</param>
        public void Save(string fileName)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Save fileName = `{fileName}`");
#endif
                ValidateIsDestroyed();

                var result = GnuClayEngine.Save();

                using (var originalStream = new MemoryStream(result))
                {
                    using (var compressedStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (var compressionStream = new GZipStream(compressedStream, CompressionMode.Compress))
                        {
                            originalStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Saves image of GnuClay NPC to a byte array. After saving running continues if the NPC was activity before saving.
        /// </summary>
        /// <returns>Returns target byte array which contains the image of GnuClay NPC.</returns>
        public byte[] Save()
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("byte[] Save()");
#endif
                ValidateIsDestroyed();

                return GnuClayEngine.Save();
            }
        }

        /// <summary>
        /// Removes all of internal resources and continues working without them.
        /// </summary>
        public void Clear()
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");
#endif
                ValidateIsDestroyed();

                GnuClayEngine.Clear();
            }
        }

        private void ValidateIsDestroyed()
        {
            if(mIsDestroyed)
            {
                throw new ApplicationException($"The entity `{mNPCName}` was destroyed.");
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

                mServer.RemoveNPC(this);
                GnuClayEngine.Destroy();
                GnuClayEngine = null;
            }
        }

        /// <summary>
        /// Stops and free all of internal resources.
        /// </summary>
        public void Dispose()
        {
            Destroy();
        }

        /// <summary>
        /// Set relationship of inheritance between two entities.
        /// </summary>
        /// <param name="subKey">The key of type of the subclass.</param>
        /// <param name="superKey">The key of type of the superclass.</param>
        /// <param name="rank">The rank of the inheritance from 0 to 1 inclusively.</param>
        public void SetInheritance(ulong subKey, ulong superKey, double rank)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                GnuClayEngine.SetInheritance(subKey, superKey, rank);
            }           
        }

        /// <summary>
        /// Loads a list of the superclasses for the target entity.
        /// </summary>
        /// <param name="targetKey">The key of type of the target entity.</param>
        /// <returns>The list of the superclasses for the target entity.</returns>
        public List<InheritanceItem> LoadListOfSuperClasses(ulong targetKey)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.LoadListOfSuperClasses(targetKey);
            }
        }

        /// <summary>
        /// Gets rank of relationship of inheritance between two entities.
        /// </summary>
        /// <param name="subKey">The key of type of the subclass.</param>
        /// <param name="superKey">The key of type of the superclass.</param>
        /// <returns>The rank of the inheritance from 0 to 1 inclusively.</returns>
        public double GetInheritanceRank(ulong subKey, ulong superKey)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.GetInheritanceRank(subKey, superKey);
            }
        }

        /// <summary>
        /// Loads a list of the subclasses for the target entity.
        /// </summary>
        /// <param name="targetKey">The key of type of the target entity.</param>
        /// <returns>The list of the subclasses for the target entity.</returns>
        public List<InheritanceItem> LoadListOfSubClasses(ulong targetKey)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.LoadListOfSubClasses(targetKey);
            }
        }

        /// <summary>
        /// Loads all items of relationship of inheritance.
        /// </summary>
        /// <returns>The list of all items of relationship of inheritance.</returns>
        public List<InheritanceItem> LoadAllInheritanceItems()
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.LoadAllInheritanceItems();
            }
        }

        /// <summary>
        /// Adds remote function.
        /// </summary>
        /// <param name="filter">The filter which describes the signature and handler of the function.</param>
        /// <returns>The descriptor of the function.</returns>
        public ulong AddRemoteFunction(IExternalCommandFilter filter)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.AddRemoteFunction(filter);
            }
        }

        /// <summary>
        /// Removes remote function by its descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor of the removed function.</param>
        public void RemoveRemoteFunction(ulong descriptor)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                GnuClayEngine.RemoveRemoteFunction(descriptor);
            }
        }

        /// <summary>
        /// Adds a handler for receiving log messages.
        /// Returns the descriptor of the added handler.
        /// </summary>
        /// <param name="handler">The reference to the handler.</param>
        /// <returns>The descriptor of the added handler.</returns>
        public ulong AddLogHandler(Action<IExternalValue> handler)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.AddLogHandler(handler);
            }
        }

        /// <summary>
        /// Removes a handler of log messages by its descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor of the removed handler.</param>
        public void RemoveLogHandler(ulong descriptor)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                GnuClayEngine.RemoveLogHandler(descriptor);
            }
        }
    }
}
