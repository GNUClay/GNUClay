using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.InternalResolver;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Threading;

namespace GnuClay.Engine.LogicalStorage
{
    public class LogicalStorageEngine: BaseGnuClayEngineComponent
    {
        public LogicalStorageEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            mInternalStorageEngine = new InternalStorageEngine();
            mInternalResolverEngine = new InternalResolverEngine(mInternalStorageEngine, Context);
        }

        private object mLockObj = new object();
        private InternalStorageEngine mInternalStorageEngine = null;
        private InternalResolverEngine mInternalResolverEngine = null;
        private StorageDataDictionary mDataDictionary = null;
        private InheritanceEngine mInheritanceEngine = null;

        private ulong mLogicalRuleTypeKey = 0;
        private ulong mFactTypeKey = 0;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
            mInheritanceEngine = Context.InheritanceEngine;

            mLogicalRuleTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.LogicalRuleName);
            mInheritanceEngine.SetInheritance(mLogicalRuleTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
            mFactTypeKey = mDataDictionary.GetKey(StandartTypeNamesConstants.FactName);
            mInheritanceEngine.SetInheritance(mFactTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
        }

        public ulong GetFactKey()
        {
            var name = Guid.NewGuid().ToString("D");
            var key = mDataDictionary.GetKey(name);
            mInheritanceEngine.SetInheritance(key, mFactTypeKey, 1, InheritanceAspect.WithOutClause);
            return key;
        }

        public ulong GetRuleKey()
        {
            var name = Guid.NewGuid().ToString("D");
            var key = mDataDictionary.GetKey(name);
            mInheritanceEngine.SetInheritance(key, mLogicalRuleTypeKey, 1, InheritanceAspect.WithOutClause);
            return key;
        }

        private bool mIsRunning = true;

        public void Suspend()
        {
            lock(mLockObj)
            {
                mIsRunning = false;
            }

            while(true)
            {
                lock (mLockObj)
                {
                    if(mInsertQueriesCount == 0)
                    {
                        break;
                    }
                }

                Thread.Sleep(10);
            }
        }

        public void Resume()
        {
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
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SelectQuery query = {query}");
#endif

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

        private int mInsertQueriesCount = 0;

        public void InsertQuery(InsertQuery query)
        {
            lock(mLockObj)
            {
#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"InsertQuery query = {query}");
#endif

                if (!mIsRunning)
                {
                    return;
                }

                mInsertQueriesCount++;
            }

            mInternalResolverEngine.InsertQuery(query);

            lock (mLockObj)
            {
                mInsertQueriesCount--;
            }
        }

        public void TSTRemoveFactOrRuleByKey(ulong key)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTRemoveFactOrRuleByKey key = {key}");
#endif

            mInternalStorageEngine.RemoveFactOrRuleByKey(key);
        }

        public ulong GetEntityKey(string name)
        {
            lock (mLockObj)
            {
                var tmpKey = DataDictionary.GetKey(name);
                NRegEntity(tmpKey);
                return tmpKey;
            }
        }

        public void RegEntity(ulong key)
        {
            lock (mLockObj)
            {
                NRegEntity(key);
            }
        }

        private ulong UniversalTypeKey = 1;

        private void NRegEntity(ulong key)
        {
            if (mInternalStorageEngine.RegEntity(key))
            {
                mInheritanceEngine.SetInheritance(key, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
            }
        }

        public object Save()
        {
            return mInternalStorageEngine.Save();
        }

        public void Load(object value)
        {
            mInternalStorageEngine.Load(value);
        }

        public void Clear()
        {
            mInternalStorageEngine.Clear();
        }
    }
}
