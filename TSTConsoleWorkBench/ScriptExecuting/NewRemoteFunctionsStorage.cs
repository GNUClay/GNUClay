using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewRemoteFunctionsHandler
    {
        public NewRemoteFunctionsHandler(BaseCommandFilter filter, GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext, NewRemoteFunctionsStorage parent)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;

            mFilter = new CommandFilter(filter);
            mFilter.Handler = Handler;

            mParent = parent;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private CommandFilter mFilter = null;
        private NewRemoteFunctionsStorage mParent = null;
        private ulong mDescriptor = 0;

        private void Handler(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin Handler action = {action}");

            var tmpTaskList = new List<Task>();

            foreach(var item in mDict)
            {
                tmpTaskList.Add(Task.Run(()=> {
                    item.Value.Handler(action);
                }));
            }

            Task.WaitAll(tmpTaskList.ToArray());

            NLog.LogManager.GetCurrentClassLogger().Info($"End Handler action = {action}");
        }

        public ulong AddFilter(CommandFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            if(mDict.Count == 0)
            {
                mDescriptor = mAdditionalContext.NewFunctionEngine.AddFilter(mFilter);
            }

            var descriptorName = Guid.NewGuid().ToString("D");
            var descriptorKey = mMainContext.DataDictionary.GetKey(descriptorName);

            mDict[descriptorKey] = filter;

            mParent.OnAddFilter(descriptorKey, this);

            return descriptorKey;
        }

        public void RemoveFilter(ulong descriptor)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFilter descriptor = {descriptor}");

            if (mDict.ContainsKey(descriptor))
            {
                mDict.Remove(descriptor);

                if (mDict.Count == 0)
                {
                    mAdditionalContext.NewFunctionEngine.RemoveFilter(mDescriptor);
                }
            }
        }

        public Dictionary<ulong, CommandFilter> mDict = new Dictionary<ulong, CommandFilter>();
    }

    public class NewRemoteFunctionsStorage
    {
        public NewRemoteFunctionsStorage(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        private object mLockObj = new object();

        public ulong AddFilter(CommandFilter filter)
        {
            lock(mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

                var filterHashCode = filter.GetLongHashCode();

                NewRemoteFunctionsHandler targetStorage = null;

                if (mDict.ContainsKey(filterHashCode))
                {
                    targetStorage = mDict[filterHashCode];
                }
                else
                {
                    targetStorage = new NewRemoteFunctionsHandler(filter, mMainContext, mAdditionalContext, this);
                    mDict[filterHashCode] = targetStorage;
                }

                return targetStorage.AddFilter(filter);
            }
        }

        public void OnAddFilter(ulong descriptor, NewRemoteFunctionsHandler handler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnAddFilter descriptor = {descriptor}");

            mDict[descriptor] = handler;
        }

        public void RemoveFilter(ulong descriptor)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFilter descriptor = {descriptor}");

                if(mDict.ContainsKey(descriptor))
                {
                    var handler = mDict[descriptor];
                    handler.RemoveFilter(descriptor);
                    mDict.Remove(descriptor);
                }
            }
        }

        private Dictionary<ulong, NewRemoteFunctionsHandler> mDict = new Dictionary<ulong, NewRemoteFunctionsHandler>();

    }
}
