using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.InternalResolver;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using System;

namespace GnuClay.Engine.LogicalStorage
{
    public class LogicalStorageEngine: BaseGnuClayEngineComponent
    {
        public LogicalStorageEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("LogicalStorageEngine");

            mInternalStorageEngine = new InternalStorageEngine();
            mInternalResolverEngine = new InternalResolverEngine(mInternalStorageEngine, Context);
        }

        private object mLockObj = new object();
        private InternalStorageEngine mInternalStorageEngine = null;
        private InternalResolverEngine mInternalResolverEngine = null;

        private bool mIsRunning = true;

        public void Suspend()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Suspend");

            lock(mLockObj)
            {
                mIsRunning = false;
            }
        }

        public void Resume()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Resume");

            lock (mLockObj)
            {
                mIsRunning = true;
            }
        }

        public StorageDataDictionary DataDictionary
        {
            get
            {
                return Context.DataDictionary;
            }
        } 

        public SelectResult SelectQuery(SelectQuery query)
        {
            lock (mLockObj)
            {
                if (!mIsRunning)
                {
                    return new SelectResult() {
                        Success = false,
                        ErrorText = "The engine has stopped"
                    };
                }
            }

            return mInternalResolverEngine.SelectQuery(query);
        }

        public void InsertQuery(InsertQuery query)
        {
            lock(mLockObj)
            {
                if(!mIsRunning)
                {
                    return;
                }
            }

            mInternalResolverEngine.InsertQuery(query);
        }

        public object Save()
        {
            return mInternalStorageEngine.Save();
        }

        public void Load(object value)
        {
            mInternalStorageEngine.Load(value);
        }
    }
}
