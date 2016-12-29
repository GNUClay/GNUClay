using GnuClay.CommonClientTypes;
using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CommonClientTypes.ResultTypes;
using System.IO;
using System.IO.Compression;

namespace GnuClay.LocalHost
{
    public class GnuClayEntityLocalHost: IGnuClayEntityConnection
    {
        private object mLockObj = new object();

        public GnuClayEntityLocalHost(string entityName, GnuClayLocalServer server)
        {
            mEntityName = entityName;
            mServer = server;

            GnuClayEngine = new GnuClayEngine();
        }

        private string mEntityName = null;
        private GnuClayLocalServer mServer = null;
        private GnuClayEngine GnuClayEngine = null;

        public string Name
        {
            get
            {
                return mEntityName;
            }
        }

        public void Suspend()
        {
            lock(mLockObj)
            {
                GnuClayEngine.Suspend();
            }           
        }

        public void Resume()
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                GnuClayEngine.Resume();
            }         
        }

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

        public SelectResult Query(string text)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Query text = `{text}`");

                ValidateIsDestroyed();

                try
                {
                    return GnuClayEngine.Query(text);
                }
                catch (Exception e)
                {
                    var result = new SelectResult();
                    result.HaveBeenFound = false;
                    result.Success = false;
                    result.ErrorText = e.ToString();
                    return result;
                }
            }
        }

        public string GetValue(int key)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.DataDictionary.GetValue(key);
            }        
        }

        public int UniqueKeysCount()
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                return GnuClayEngine.DataDictionary.UniqueKeysCount();
            }      
        }

        public void Load(string name)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Load name = `{name}`");

                ValidateIsDestroyed();

                using (var originalStream = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.None))
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

        public void Load(byte[] data)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(" Load(byte[] data)");

                ValidateIsDestroyed();

                GnuClayEngine.Load(data);
            }
        }

        public void Save(string name)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Save name = `{name}`");

                ValidateIsDestroyed();

                var result = GnuClayEngine.Save();

                using (var originalStream = new MemoryStream(result))
                {
                    using (var compressedStream = new FileStream(name, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (var compressionStream = new GZipStream(compressedStream, CompressionMode.Compress))
                        {
                            originalStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
        }

        public byte[] Save()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("byte[] Save()");

                ValidateIsDestroyed();

                return GnuClayEngine.Save();
            }
        }

        public void Clear()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");

                ValidateIsDestroyed();

                GnuClayEngine.Clear();
            }
        }

        private void ValidateIsDestroyed()
        {
            if(mIsDestroyed)
            {
                throw new ApplicationException($"The entity `{mEntityName}` was destroyed.");
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

                mServer.RemoveEntity(this);
                GnuClayEngine.Destroy();
                GnuClayEngine = null;
            }
        }

        public void Dispose()
        {
            Destroy();
        }
    }
}
