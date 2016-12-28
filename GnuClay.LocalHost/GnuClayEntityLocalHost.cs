using GnuClay.CommonClientTypes;
using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CommonClientTypes.ResultTypes;

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

            }

            GnuClayEngine.Suspend();
        }

        public void Resume()
        {
            lock (mLockObj)
            {

            }

            GnuClayEngine.Resume();
        }

        public bool IsRunning
        {
            get
            {
                lock (mLockObj)
                {

                }

                return GnuClayEngine.IsRunning;
            }
        }

        public SelectResult Query(string text)
        {
            lock (mLockObj)
            {

            }

            NLog.LogManager.GetCurrentClassLogger().Info($"Query text = `{text}`");

            try
            {
                return GnuClayEngine.Query(text);
            }catch(Exception e)
            {
                var result = new SelectResult();
                result.HaveBeenFound = false;
                result.Success = false;
                result.ErrorText = e.ToString();
                return result;
            }
        }

        public string GetValue(int key)
        {
            lock (mLockObj)
            {

            }
            return GnuClayEngine.DataDictionary.GetValue(key);
        }

        public int UniqueKeysCount()
        {
            lock (mLockObj)
            {

            }

            return GnuClayEngine.DataDictionary.UniqueKeysCount();
        }

        public void Load(string name)
        {
            lock (mLockObj)
            {

            }
            NLog.LogManager.GetCurrentClassLogger().Info($"Load name = `{name}`");

            throw new NotImplementedException();
        }

        public void Load(byte[] data)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(" Load(byte[] data)");

                throw new NotImplementedException();
            }
        }

        public void Save(string name)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Save name = `{name}`");

                throw new NotImplementedException();
            }
        }

        public byte[] Save()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("byte[] Save()");

                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");

                GnuClayEngine.Clear();
            }
        }

        private void ValidateIsDestroyed()
        {
            throw new ApplicationException($"The entity `{mEntityName}` was destroyed.");
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

                mServer.RemoveEntity(this);

                throw new NotImplementedException();
            }
        }
    }
}
