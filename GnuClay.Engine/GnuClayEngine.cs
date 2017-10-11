using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.Bootstrap;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Console;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalBus;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.Parser;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.RemoteFunctions;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.Compiler;
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

            mContext.ScriptCompiler = new GnuClayScriptCompiler(mContext);
            mComponents.Add(mContext.ScriptCompiler);

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

            mContext.ConsoleEngine = new ConsoleEngine(mContext);
            mComponents.Add(mContext.ConsoleEngine);
        }

        private List<BaseGnuClayEngineComponent> mComponents = new List<BaseGnuClayEngineComponent>();

        private void Init()
        {
            FirstInit();
            SecondInit();

            var tmpBootstrapEngine = new BootstrapEngine(mContext);
            tmpBootstrapEngine.Run();
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

        /// <summary>
        /// Saves image of GnuClay entity to a byte array. After saving running continues if the entity was activity before saving.
        /// </summary>
        /// <returns>Returns target byte array which contains the image of GnuClay entity.</returns>
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

        /// <summary>
        /// Loads image of GnuClay entity form array of bytes and activates it next.
        /// All previous information will be removed.
        /// </summary>
        /// <param name="data">Reference to the array of bytes.</param>
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

        /// <summary>
        /// Removes all of internal resources and continues working without them.
        /// </summary>
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

        /// <summary>
        /// Stops and free all of internal resources.
        /// </summary>
        public void Dispose()
        {
            Destroy();
        }

        /// <summary>
        /// Executes query from text and returns result of the executing.
        /// </summary>
        /// <param name="queryString">The text with the query.</param>
        /// <returns>The result of the executing</returns>
        public SelectResult Query(string queryString)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                var queryTree = mContext.ParserEngine.Parse(queryString);
                return Query(queryTree);
            }
        }

        public SelectResult Query(List<GnuClayQuery> queryTreeList)
        {
            lock (mLockObj)
            {
                ValidateIsDestroyed();

                SelectResult lastResult = null;

                foreach(var queryTreeItem in queryTreeList)
                {
                    var kind = queryTreeItem.Kind;

                    switch (kind)
                    {
                        case GnuClayQueryKind.SELECT:
                            lastResult = ProcessSelectQuery(queryTreeItem.SelectQuery);
                            break;

                        case GnuClayQueryKind.INSERT:
                            lastResult = ProcessInsertQuery(queryTreeItem.InsertQuery);
                            break;

                        case GnuClayQueryKind.DELETE:
                            lastResult = ProcessDeleteQuery(queryTreeItem.SelectQuery);
                            break;

                        case GnuClayQueryKind.CALL:
                            lastResult = ProcessCall(queryTreeItem.ASTCodeBlock);
                            break;

                        case GnuClayQueryKind.USER_DEFINED_FUNCTION:
                            lastResult = ProcessUserDefinedFunction(queryTreeItem.UserDefinedFunction);
                            break;

                        default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
                    }
                }

                return lastResult;
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

        private SelectResult ProcessDeleteQuery(SelectQuery query)
        {
            mContext.LogicalStorage.RemoveFacts(query);

            var result = new SelectResult();
            return result;
        }

        private SelectResult ProcessCall(ASTCodeBlock codeBlock)
        {
            mContext.ScriptExecutor.Execute(codeBlock);

            var result = new SelectResult();
            return result;
        }

        private SelectResult ProcessUserDefinedFunction(UserDefinedFunction userDefinedFunction)
        {
            mContext.ScriptExecutor.DefineFunction(userDefinedFunction);

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

        /// <summary>
        /// Get the string value which is associated with that key.
        /// </summary>
        /// <param name="key">Key of the value</param>
        /// <returns>Associated string value.</returns>
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

        public ulong AddRemoteFunction(IExternalCommandFilter filter)
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

        public ulong AddLogHandler(Action<IExternalValue> handler)
        {
            lock(mLockObj)
            {
                return mContext.ConsoleEngine.AddLogHandler(handler);
            }
        }

        public void RemoveLogHandler(ulong descriptor)
        {
            lock (mLockObj)
            {
                mContext.ConsoleEngine.RemoveLogHandler(descriptor);
            }
        }
    }
}
