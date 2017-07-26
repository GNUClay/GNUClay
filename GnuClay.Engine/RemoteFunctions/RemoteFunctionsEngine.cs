using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.RemoteFunctions
{
    public class RemoteFunctionsHandler
    {
        public RemoteFunctionsHandler(BaseCommandFilter filter, GnuClayEngineComponentContext mainContext, RemoteFunctionsEngine parent)
        {
            mMainContext = mainContext;

            mFilter = new CommandFilter(filter);
            mFilter.Handler = Handler;

            mParent = parent;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private CommandFilter mFilter = null;
        private RemoteFunctionsEngine mParent = null;
        private ulong mDescriptor = 0;

        private void Handler(EntityAction action)
        {
            var tmpTaskList = new List<Task>();

            foreach (var item in mDict)
            {
                tmpTaskList.Add(Task.Run(() => {
                    item.Value.Handler(action);
                }));
            }

            Task.WaitAll(tmpTaskList.ToArray());
        }

        public ulong AddFilter(CommandFilter filter)
        {
            if (mDict.Count == 0)
            {
                mDescriptor = mMainContext.FunctionsEngine.AddFilter(mFilter);
            }

            var descriptorName = Guid.NewGuid().ToString("D");
            var descriptorKey = mMainContext.DataDictionary.GetKey(descriptorName);

            mDict[descriptorKey] = filter;

            mParent.OnAddFilter(descriptorKey, this);

            return descriptorKey;
        }

        public void RemoveFilter(ulong descriptor)
        {
            if (mDict.ContainsKey(descriptor))
            {
                mDict.Remove(descriptor);

                if (mDict.Count == 0)
                {
                    mMainContext.FunctionsEngine.RemoveFilter(mDescriptor);
                }
            }
        }

        public Dictionary<ulong, CommandFilter> mDict = new Dictionary<ulong, CommandFilter>();
    }

    public class RemoteFunctionsEngine : BaseGnuClayEngineComponent
    {
        public RemoteFunctionsEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private object mLockObj = new object();

        public ulong AddFilter(CommandFilter filter)
        {
            lock (mLockObj)
            {
                var filterHashCode = filter.GetLongHashCode();

                RemoteFunctionsHandler targetStorage = null;

                if (mDict.ContainsKey(filterHashCode))
                {
                    targetStorage = mDict[filterHashCode];
                }
                else
                {
                    targetStorage = new RemoteFunctionsHandler(filter, Context, this);
                    mDict[filterHashCode] = targetStorage;
                }

                return targetStorage.AddFilter(filter);
            }
        }

        public void OnAddFilter(ulong descriptor, RemoteFunctionsHandler handler)
        {
            mDict[descriptor] = handler;
        }

        public void RemoveFilter(ulong descriptor)
        {
            lock (mLockObj)
            {
                if (mDict.ContainsKey(descriptor))
                {
                    var handler = mDict[descriptor];
                    handler.RemoveFilter(descriptor);
                    mDict.Remove(descriptor);
                }
            }
        }

        private Dictionary<ulong, RemoteFunctionsHandler> mDict = new Dictionary<ulong, RemoteFunctionsHandler>();
    }
}
