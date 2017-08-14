using GnuClay.CommonClientTypes.Inheritance;
using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalBus;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.Parser;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.RemoteFunctions;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.Serialization;
using GnuClay.Engine.StandardLibrary;
using GnuClay.Engine.Triggers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GnuClay.Engine
{
    public class GnuClayEngine: IDisposable
    {
        public GnuClayEngine()
        {
            CreateContext();
            Init();
        }

        private object mLockObj = new object();

        public StorageDataDictionary DataDictionary
        {
            get
            {
                return mContext.DataDictionary;
            }
        }

        public LogicalStorageEngine LogicalStorage
        {
            get
            {
                return mContext.LogicalStorage;
            }
        }

        public ScriptExecutorEngine ExecutorEngine
        {
            get
            {
                return mContext.ScriptExecutor;
            }
        }

        private GnuClayEngineComponentContext mContext = null;

        public GnuClayEngineComponentContext Context
        {
            get
            {
                return mContext;
            }
        }

        private void CreateContext()
        {
            mContext = new GnuClayEngineComponentContext();

            mContext.ActiveContext = new ActiveContext();

            mContext.SerializationEngine = new SerializationEngine(mContext);
            mComponents.Add(mContext.SerializationEngine);

            mContext.DataDictionary = new StorageDataDictionary(mContext);
            mComponents.Add(mContext.DataDictionary);

            mContext.LogicalStorage = new LogicalStorageEngine(mContext);
            mComponents.Add(mContext.LogicalStorage);

            mContext.StandardLibrary = new StandardLibraryEngine(mContext);
            mComponents.Add(mContext.StandardLibrary);

            mContext.ScriptExecutor = new ScriptExecutorEngine(mContext);
            mComponents.Add(mContext.ScriptExecutor);

            mContext.RemoteFunctionsEngine = new RemoteFunctionsEngine(mContext);
            mComponents.Add(mContext.RemoteFunctionsEngine);

            mContext.ParserEngine = new GnuClayParserEngine(mContext);
            mComponents.Add(mContext.ParserEngine);

            mContext.InheritanceEngine = new InheritanceEngine(mContext);
            mComponents.Add(mContext.InheritanceEngine);

            mContext.ErrorsFactory = new ErrorsFactory(mContext);
            mComponents.Add(mContext.ErrorsFactory);

            mContext.ConstTypeProvider = new ConstTypeProvider(mContext);
            mComponents.Add(mContext.ConstTypeProvider);

            mContext.FunctionsEngine = new FunctionsEngine(mContext);
            mComponents.Add(mContext.FunctionsEngine);

            mContext.UserDefinedFunctionsStorage = new UserDefinedFunctionsStorage(mContext);
            mComponents.Add(mContext.UserDefinedFunctionsStorage);

            mContext.InternalBusEngine = new InternalBusEngine(mContext);
            mComponents.Add(mContext.InternalBusEngine);

            mContext.TriggersEngine = new TriggersEngine(mContext);
            mComponents.Add(mContext.TriggersEngine);

            mContext.PropertiesEngine = new PropertiesEngine(mContext);
            mComponents.Add(mContext.PropertiesEngine);

            mContext.CommonValuesFactory = new CommonValuesFactory(mContext);
            mComponents.Add(mContext.CommonValuesFactory);

            mContext.CommonKeysEngine = new CommonKeysEngine(mContext);
            mComponents.Add(mContext.CommonKeysEngine);
        }

        private List<BaseGnuClayEngineComponent> mComponents = new List<BaseGnuClayEngineComponent>();

        private void Init()
        {
            FirstInit();
        }

        private void FirstInit()
        {
            foreach(var component in mComponents)
            {
                component.FirstInit();
            }
        }

        private void SecondInit()
        {
            foreach (var component in mComponents)
            {
                component.SecondInit();
            }
        }

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

                var tmpTasksList = new List<Task>();

                var tmpTask = new Task(() => {
                    mContext.ActiveContext.Suspend();
                });
                tmpTasksList.Add(tmpTask);
                tmpTask.Start();

                tmpTask = new Task(() => {
                    mContext.LogicalStorage.Suspend();
                });
                tmpTasksList.Add(tmpTask);
                tmpTask.Start();

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

                var tmpTasksList = new List<Task>();

                var tmpTask = new Task(() => {
                    mContext.ActiveContext.Resume();
                });
                tmpTasksList.Add(tmpTask);
                tmpTask.Start();

                tmpTask = new Task(() => {
                    mContext.LogicalStorage.Resume();
                });
                tmpTasksList.Add(tmpTask);
                tmpTask.Start();

                Task.WaitAll(tmpTasksList.ToArray());
            }
        }

        public byte[] Save()
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                var result = mContext.SerializationEngine.Save();

                if (tmpIsRunning)
                {
                    Resume();
                }

                return result;
            }
        }

        public void Load(byte[] value)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                mContext.SerializationEngine.Load(value);

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
                ValidateIsDestroyed();

                var tmpIsRunning = mIsRunning;

                if (tmpIsRunning)
                {
                    Suspend();
                }

                mContext.SerializationEngine.Clear();

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
                throw new ApplicationException("The GnuClay engine was destroyed.");
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
                if (mIsDestroyed)
                {
                    return;
                }

                mIsDestroyed = true;

                mIsRunning = false;

                mContext.ActiveContext.StopAll();
                mContext = null;
            }
        }

        public void Dispose()
        {
            Destroy();
        }

        public SelectResult Query(string queryString)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                var queryTree = mContext.ParserEngine.Parse(queryString);
                return Query(queryTree);
            }
        }

        public SelectResult Query(GnuClayQuery queryTree)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                switch (queryTree.Kind)
                {
                    case GnuClayQueryKind.SELECT:
                        return ProcessSelectQuery(queryTree.SelectQuery);

                    case GnuClayQueryKind.INSERT:
                        return ProcessInsertQuery(queryTree.InsertQuery);

                    case GnuClayQueryKind.CALL:
                        return ProcessCall(queryTree.ASTCodeBlock);

                    default: throw new ArgumentOutOfRangeException(nameof(queryTree.Kind));
                }
            }
        }

        private SelectResult ProcessSelectQuery(SelectQuery query)
        {
            return mContext.LogicalStorage.SelectQuery(query);
        }

        private SelectResult ProcessInsertQuery(InsertQuery query)
        {
            mContext.LogicalStorage.InsertQuery(query);

            var result = new SelectResult();
            return result;
        }

        private SelectResult ProcessCall(ASTCodeBlock codeBlock)
        {
            mContext.ScriptExecutor.Execute(codeBlock);

            var result = new SelectResult();
            return result;
        }

        public ulong GetKey(string val)
        {
            lock (mLockObj)
            {
                return mContext.DataDictionary.GetKey(val);
            }
        }

        public string GetValue(ulong key)
        {
            lock (mLockObj)
            {
                return mContext.DataDictionary.GetValue(key);
            }
        }

        public void SetInheritance(ulong subKey, ulong superKey, double rank)
        {
            lock (mLockObj)
            {
                mContext.InheritanceEngine.SetInheritance(subKey, superKey, rank, InheritanceAspect.WithOutClause);
            }
        }

        public List<InheritanceItem> LoadListOfSuperClasses(ulong targetKey)
        {
            lock (mLockObj)
            {
                return mContext.InheritanceEngine.LoadListOfSuperClasses(targetKey);
            }
        }

        public double GetInheritanceRank(ulong subKey, ulong superKey)
        {
            lock (mLockObj)
            {
                return mContext.InheritanceEngine.GetRank(subKey, superKey);
            }
        }

        public List<InheritanceItem> LoadListOfSubClasses(ulong targetKey)
        {
            lock (mLockObj)
            {
                return mContext.InheritanceEngine.LoadListOfSubClasses(targetKey);
            }
        }

        public List<InheritanceItem> LoadAllInheritanceItems()
        {
            lock (mLockObj)
            {
                return mContext.InheritanceEngine.LoadAllItems();
            }
        }

        public ulong AddRemoteFunction(CommandFilter filter)
        {
            lock (mLockObj)
            {
                return mContext.RemoteFunctionsEngine.AddFilter(filter);
            }
        }

        public void RemoveRemoteFunction(ulong descriptor)
        {
            lock (mLockObj)
            {
                mContext.RemoteFunctionsEngine.RemoveFilter(descriptor);
            }
        }
    }
}
