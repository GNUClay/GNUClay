using GnuClay.CommonUtils.TypeHelpers;
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

        public List<T> FindExecutors(NewCommand command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            throw new NotImplementedException();
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

        private class ExecutorsQueueItem
        {
            public double Rank { get; set; }
            public ulong TypeKey { get; set; }

            /// <summary>
            /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
            /// </summary>
            /// <returns>The string representation of this instance.</returns>
            public override string ToString()
            {
                var tmpSb = new StringBuilder();

                tmpSb.AppendLine($"{nameof(Rank)} = {Rank}");
                tmpSb.AppendLine($"{nameof(TypeKey)} = {TypeKey}");

                return tmpSb.ToString();
            }
        }

        public List<T> FindExecutors(NewCommand command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var holderKey = command.Holder.TypeKey;

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors holderKey = {holderKey}");

            var tmpObjectsList = new List<ExecutorsQueueItem>();

            tmpObjectsList.Add(new ExecutorsQueueItem() {
                TypeKey = holderKey,
                Rank = 2
            });

            var tmpInheritanceList = mMainContext.InheritanceEngine.LoadListOfSuperClasses(holderKey);

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors tmpInheritanceList.Count = {tmpInheritanceList.Count}");

            foreach (var tmpInheritanceItem in tmpInheritanceList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors tmpInheritanceItem = {tmpInheritanceItem}");

                tmpObjectsList.Add(new ExecutorsQueueItem()
                {
                    TypeKey = tmpInheritanceItem.SuperKey,
                    Rank = tmpInheritanceItem.Rank * tmpInheritanceItem.Distance
                });
            }

            tmpObjectsList = tmpObjectsList.OrderByDescending(p => p.Rank).ToList();

            var result = new List<T>();

            foreach(var item in tmpObjectsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors item = {item}");

                var key = item.TypeKey;

                if (mDict.ContainsKey(key))
                {
                    var tmpItems = mDict[key].FindExecutors(command);

                    NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors tmpItems.Count = {tmpItems.Count}");

                    if(_ListHelper.IsEmpty(tmpItems))
                    {
                        continue;
                    }

                    result.AddRange(tmpItems);
                }
            }

            return result;
        }

        private Dictionary<ulong, NewCommandFiltersStorageByHolder<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByHolder<T>>();
    }
}
