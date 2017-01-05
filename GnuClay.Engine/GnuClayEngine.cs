﻿using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.Parser;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.RemoteEvents;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.Serialization;
using GnuClay.Engine.StandardLibrary;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine
{
    public class GnuClayEngine: IDisposable
    {
        public GnuClayEngine()
        {
            CreateContext();
            InitFromZero();
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
            NLog.LogManager.GetCurrentClassLogger().Info("CreateContext");

            mContext = new GnuClayEngineComponentContext();

            mContext.ActiveContext = new ActiveContext();
            mContext.SerializationEngine = new SerializationEngine(mContext);
            mContext.DataDictionary = new StorageDataDictionary(mContext);
            mContext.LogicalStorage = new LogicalStorageEngine(mContext);
            mContext.TypeProcessingContext = new TypeProcessingContext(mContext);
            mContext.StandardLibrary = new StandardLibraryEngine(mContext);
            mContext.ScriptExecutor = new ScriptExecutorEngine(mContext);
            mContext.RemoteEventsEngine = new RemoteEventsEngine(mContext);
            mContext.ParserEngine = new GnuClayParserEngine(mContext);
            mContext.InheritanceEngine = new InheritanceEngine(mContext);

            mContext.StandardLibrary.CreateProviders();
        }

        private void InitFromZero()
        {
            mContext.StandardLibrary.InitFromZero();

            //mContext.ActiveContext.ActivateAll();
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

                NLog.LogManager.GetCurrentClassLogger().Info("Suspend");

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

                NLog.LogManager.GetCurrentClassLogger().Info("Resume");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Save");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Load");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Destroy");

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
                NLog.LogManager.GetCurrentClassLogger().Info($"Query queryString = `{queryString}`");

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
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessSelectQuery");

            return mContext.LogicalStorage.SelectQuery(query);
        }

        private SelectResult ProcessInsertQuery(InsertQuery query)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessInsertQuery");

            mContext.LogicalStorage.InsertQuery(query);

            var result = new SelectResult();
            return result;
        }

        private SelectResult ProcessCall(ASTCodeBlock codeBlock)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessCall");
            mContext.ScriptExecutor.Execute(codeBlock);

            var result = new SelectResult();
            return result;
        }
    }
}
