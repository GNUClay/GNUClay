using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewCommandFiltersStorageByParams<T>
        where T : NewBaseCommandFilter
    {
        public NewCommandFiltersStorageByParams(T filter, GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;
            mFilter = filter;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        private T mFilter = null;

        public T Filter
        {
            get
            {
                return mFilter;
            }
        }
    }

    public class NewCommandFiltersStorageByTarget<T>
        where T : NewBaseCommandFilter
    {
        public NewCommandFiltersStorageByTarget(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        public void AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetHashCode = filter.GetLongHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                return;
            }

            var targetStorage = new NewCommandFiltersStorageByParams<T>(filter, mMainContext, mAdditionalContext);
            mDict.Add(targetHashCode, targetStorage);
        }

        private Dictionary<ulong, NewCommandFiltersStorageByParams<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByParams<T>>();
    }

    public class NewCommandFiltersStorageByFunction<T>
        where T : NewBaseCommandFilter
    {
        public NewCommandFiltersStorageByFunction(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        public void AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");


            var targetKey = filter.TargetKey;

            NewCommandFiltersStorageByTarget<T> targetStorage = null;

            if (mDict.ContainsKey(targetKey))
            {
                targetStorage = mDict[targetKey];
            }
            else
            {
                targetStorage = new NewCommandFiltersStorageByTarget<T>(mMainContext, mAdditionalContext);
                mDict.Add(targetKey, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        private Dictionary<ulong, NewCommandFiltersStorageByTarget<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByTarget<T>>();
    }

    public class NewCommandFiltersStorageByHolder<T>
        where T : NewBaseCommandFilter
    {
        public NewCommandFiltersStorageByHolder(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        public void AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var functionKey = filter.FunctionKey;

            NewCommandFiltersStorageByFunction<T> targetStorage = null;

            if (mDict.ContainsKey(functionKey))
            {
                targetStorage = mDict[functionKey];
            }
            else
            {
                targetStorage = new NewCommandFiltersStorageByFunction<T>(mMainContext, mAdditionalContext);
                mDict.Add(functionKey, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        private Dictionary<ulong, NewCommandFiltersStorageByFunction<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByFunction<T>>();
    }

    public class NewCommandFiltersStorage<T>
        where T: NewBaseCommandFilter
    {
        public NewCommandFiltersStorage(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        public void AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var holderKey = filter.HolderKey;

            NewCommandFiltersStorageByHolder<T> targetStorage = null;

            if (mDict.ContainsKey(holderKey))
            {
                targetStorage = mDict[holderKey];
            }
            else
            {
                targetStorage = new NewCommandFiltersStorageByHolder<T>(mMainContext, mAdditionalContext);
                mDict.Add(holderKey, targetStorage);
            }

            targetStorage.AddFilter(filter);
        }

        private Dictionary<ulong, NewCommandFiltersStorageByHolder<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByHolder<T>>();
    }
}
