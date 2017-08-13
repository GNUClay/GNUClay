using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.InternalResolver;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GnuClay.Engine.LogicalStorage
{
    public class LogicalStorageEngine: BaseGnuClayEngineComponent
    {
        public LogicalStorageEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            CreateContext();
        }

        private object mLockObj = new object();
        private LogicalStorageContext mLogicalContext = null;
        private InternalStorageEngine mInternalStorageEngine = null;
        private InternalResolverEngine mInternalResolverEngine = null;
        private StorageDataDictionary mDataDictionary = null;
        private InheritanceEngine mInheritanceEngine = null;

        private void CreateContext()
        {
            mLogicalContext = new LogicalStorageContext();

            mInternalStorageEngine = new InternalStorageEngine(Context, mLogicalContext);
            mLogicalContext.InternalStorageEngine = mInternalStorageEngine;
            mComponents.Add(mInternalStorageEngine);

            mInternalResolverEngine = new InternalResolverEngine(Context, mLogicalContext);
            mLogicalContext.InternalResolverEngine = mInternalResolverEngine;
            mComponents.Add(mInternalResolverEngine);

            mLogicalContext.CommonLogicalHelper = new CommonLogicalHelper(Context, mLogicalContext);
            mComponents.Add(mLogicalContext.CommonLogicalHelper);

            mLogicalContext.ASTTransformer = new ASTTransformer(Context, mLogicalContext);
            mComponents.Add(mLogicalContext.ASTTransformer);
        }

        private List<BaseLogicalStorageComponent> mComponents = new List<BaseLogicalStorageComponent>();

        private void FirstInitOfLogacalContext()
        {
            foreach (var component in mComponents)
            {
                component.FirstInit();
            }
        }

        private void SecondInitOfLogicalcontext()
        {
            foreach (var component in mComponents)
            {
                component.SecondInit();
            }
        }

        public override void FirstInit()
        {
            FirstInitOfLogacalContext();

            mDataDictionary = Context.DataDictionary;
            mInheritanceEngine = Context.InheritanceEngine;
        }

        public override void SecondInit()
        {
            SecondInitOfLogicalcontext();
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

        public SelectResult SelectQuery(SelectQuery query)
        {
            lock (mLockObj)
            {
#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"SelectQuery query = {query}");
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

        public void RemoveFacts(SelectQuery query)
        {
            lock (mLockObj)
            {
                if (!mIsRunning)
                {
                    return;
                }

                mInternalResolverEngine.RemoveFacts(query);
            }
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

        public SelectResult GetLogicalPropery(IValue holder, ulong propertyKey)
        {
            lock (mLockObj)
            {
                return mInternalResolverEngine.GetLogicalPropery(holder, propertyKey);
            }
        }

        public IValue SetLogicalProperty(IValue holder, ulong propertyKey, IValue value, bool rewrite)
        {
            lock (mLockObj)
            {
                return mInternalResolverEngine.SetLogicalProperty(holder, propertyKey, value, rewrite);
            }
        }

        public ulong GetEntityKey(string name)
        {
            lock (mLockObj)
            {
                var tmpKey = mDataDictionary.GetKey(name);
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
