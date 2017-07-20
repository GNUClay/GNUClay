using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewCommandFiltersStorageByParams<T>
        where T : BaseCommandFilter
    {
        public NewCommandFiltersStorageByParams(T filter, GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;

            mNameOfDescriptor = Guid.NewGuid().ToString("D");
            mKeyOfDescriptor = mMainContext.DataDictionary.GetKey(mNameOfDescriptor);

            mFilter = filter;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        private string mNameOfDescriptor = string.Empty;
        private ulong mKeyOfDescriptor = 0;

        public ulong Descriptor
        {
            get
            {
                return mKeyOfDescriptor;
            }
        }

        private T mFilter = null;

        public T Filter
        {
            get
            {
                return mFilter;
            }
        }

        public double GetRank(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetRank command = {command}");

            if(command.IsCallByNamedParams)
            {
                return GetNamedRank(command);
            }

            return GetPositionedRank(command);
        }

        private double GetNamedRank(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank command = {command}");

            NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank mFilter.Params.Count = {mFilter.Params.Count}");

            if (_ListHelper.IsEmpty(mFilter.Params))
            {
                return 0.01;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("GetNamedRank NEXT");

            var commandParams = command.NamedParams.ToDictionary(p => p.ParamName.TypeKey, p => p);

            double result = 1;

            foreach (var filterParamKVP in mFilter.Params)
            {
                var paramKey = filterParamKVP.Key;

                NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank paramName = {paramKey} paramName = {mMainContext.DataDictionary.GetValue(paramKey)}");

                if (!commandParams.ContainsKey(paramKey))
                {
                    continue;
                }

                var targetCommandParam = commandParams[paramKey];

                var filterParam = filterParamKVP.Value;

                NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank targetCommandParam = {targetCommandParam}");
                NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank filterParam = {filterParam}");

                if (filterParam.IsAnyType)
                {
                    result *= 0.1;
                }
                else
                {
                    var commandParamTypeKey = targetCommandParam.ParamValue.TypeKey;
                    var filterParamTypeKey = filterParam.TypeKey;

                    NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank commandParamTypeKey = {commandParamTypeKey} filterParamTypeKey = {filterParamTypeKey}");

                    if (commandParamTypeKey == filterParamTypeKey)
                    {
                        result *= 2;
                    }
                    else
                    {
                        var rank = mMainContext.InheritanceEngine.GetRank(commandParamTypeKey, filterParamTypeKey);

                        NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank rank = {rank}");

                        if (rank == 0)
                        {
                            return 0;
                        }

                        result *= rank;
                    }
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank NEXT NEXT result = {result}");

                if (filterParam.IsAnyValue)
                {
                    result *= 0.1;
                }
                else
                {
                    if (targetCommandParam == filterParam.Value)
                    {
                        result *= 2;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank result = {result}");

            return result;
        }

        private double GetPositionedRank(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank command = {command}");

            var tmpCommandParams = command.PositionedParams;
            var tmpFilterParams = mFilter.Params;

            if (tmpCommandParams.Count > tmpFilterParams.Count)
            {
                return 0;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank NEXT command = {command}");

            var tmpCommandParamsEnumerator = tmpCommandParams.GetEnumerator();
            var tmpFilterParamsEnumerator = tmpFilterParams.GetEnumerator();

            var tmpExistsParams = true;

            double result = 1;

            while (tmpFilterParamsEnumerator.MoveNext())
            {
                var tmpFilterParam = tmpFilterParamsEnumerator.Current.Value;

                if (tmpExistsParams)
                {
                    if(tmpCommandParamsEnumerator.MoveNext())
                    {
                        var tmpCommandParam = tmpCommandParamsEnumerator.Current;

                        NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank tmpFilterParam = {tmpFilterParam}");
                        NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank tmpCommandParam = {tmpCommandParam}");

                        if(tmpFilterParam.IsAnyType)
                        {
                            result *= 0.1;
                        }
                        else
                        {
                            var tmpCommandParamTypeKey = tmpCommandParam.ParamValue.TypeKey;
                            var tmpFilterParamTypeKey = tmpFilterParam.TypeKey;

                            if (tmpCommandParamTypeKey == tmpFilterParamTypeKey)
                            {
                                result *= 2;
                                continue;
                            }

                            var rank = mMainContext.InheritanceEngine.GetRank(tmpCommandParamTypeKey, tmpFilterParamTypeKey);

                            NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank rank = {rank}");

                            if (rank == 0)
                            {
                                return 0;
                            }

                            result *= rank;
                        }

                        if(tmpFilterParam.IsAnyValue)
                        {
                            result *= 0.1;
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        tmpExistsParams = false;
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank result = {result}");

            return result;
        }
    }

    public class NewCommandFiltersStorageByTarget<T>
        where T : BaseCommandFilter
    {
        public NewCommandFiltersStorageByTarget(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext, NewCommandFiltersStorageByFunction<T> parent)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;
            mParent = parent;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private NewCommandFiltersStorageByFunction<T> mParent = null;

        public ulong AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetHashCode = filter.GetLongHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                var tmpExistingStorage = mDict[targetHashCode];

                if(tmpExistingStorage.Filter == filter)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter tmpExistingStorage.Filter == filter filter = {filter}");

                    return tmpExistingStorage.Descriptor;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter mDict.Remove(targetHashCode) filter = {filter}");

                mDict.Remove(targetHashCode);
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter NEXT filter = {filter}");

            var targetStorage = new NewCommandFiltersStorageByParams<T>(filter, mMainContext, mAdditionalContext);
            mDict.Add(targetHashCode, targetStorage);

            var descriptor = targetStorage.Descriptor;

            mDescriptorsDict[descriptor] = targetStorage;

            mParent.OnAddFilter(descriptor, this);

            return descriptor;
        }

        public List<T> FindExecutors(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var targetFilters = new List<KeyValuePair<double, T>>();

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors mDict.Count = {mDict.Count}");

            foreach (var item in mDict)
            {
                var value = item.Value;

                var rank = value.GetRank(command);

                NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors rank = {rank}");

                if (rank == 0)
                {
                    continue;
                }

                targetFilters.Add(new KeyValuePair<double, T>(rank, value.Filter));
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors NEXT targetFilters.Count = {targetFilters.Count}");

            if (_ListHelper.IsEmpty(targetFilters))
            {
                return new List<T>();
            }

            return targetFilters.OrderByDescending(p => p.Key).Select(p => p.Value).ToList();
        }

        public void RemoveFilter(ulong descriptor)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFilter descriptor = {descriptor}");

            var targetStorage = mDescriptorsDict[descriptor];
            mDescriptorsDict.Remove(descriptor);

            var targetHashCode = targetStorage.Filter.GetLongHashCode();

            mDict.Remove(targetHashCode);
        }

        private Dictionary<ulong, NewCommandFiltersStorageByParams<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByParams<T>>();
        private Dictionary<ulong, NewCommandFiltersStorageByParams<T>> mDescriptorsDict = new Dictionary<ulong, NewCommandFiltersStorageByParams<T>>();
    }

    public class NewCommandFiltersStorageByFunction<T>
        where T : BaseCommandFilter
    {
        public NewCommandFiltersStorageByFunction(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext, NewCommandFiltersStorageByHolder<T> parent)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;
            mParent = parent;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private NewCommandFiltersStorageByHolder<T> mParent = null;

        public ulong AddFilter(T filter)
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
                targetStorage = new NewCommandFiltersStorageByTarget<T>(mMainContext, mAdditionalContext, this);
                mDict.Add(targetKey, targetStorage);
            }

            return targetStorage.AddFilter(filter);
        }

        public void OnAddFilter(ulong descriptor, NewCommandFiltersStorageByTarget<T> storage)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnAddFilter descriptor = {descriptor}");

            mParent.OnAddFilter(descriptor, storage);
        }

        public List<T> FindExecutors(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var targetKey = command.TargetKey;

            if (mDict.ContainsKey(targetKey))
            {
                return mDict[targetKey].FindExecutors(command);
            }

            return new List<T>();
        }

        private Dictionary<ulong, NewCommandFiltersStorageByTarget<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByTarget<T>>();
    }

    public class NewCommandFiltersStorageByHolder<T>
        where T : BaseCommandFilter
    {
        public NewCommandFiltersStorageByHolder(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex, NewCommandFiltersStorage<T> parent)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;
            mParent = parent;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private NewCommandFiltersStorage<T> mParent = null;

        public ulong AddFilter(T filter)
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
                targetStorage = new NewCommandFiltersStorageByFunction<T>(mMainContext, mAdditionalContext, this);
                mDict.Add(functionKey, targetStorage);
            }

            return targetStorage.AddFilter(filter);
        }

        public void OnAddFilter(ulong descriptor, NewCommandFiltersStorageByTarget<T> storage)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnAddFilter descriptor = {descriptor}");

            mParent.OnAddFilter(descriptor, storage);
        }

        public List<T> FindExecutors(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var functionKey = command.Function.TypeKey;

            if (mDict.ContainsKey(functionKey))
            {
                return mDict[functionKey].FindExecutors(command);
            }

            return new List<T>();
        }

        private Dictionary<ulong, NewCommandFiltersStorageByFunction<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByFunction<T>>();
    }

    public class NewCommandFiltersStorage<T>
        where T: BaseCommandFilter
    {
        public NewCommandFiltersStorage(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContex)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContex;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        public ulong AddFilter(T filter)
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
                targetStorage = new NewCommandFiltersStorageByHolder<T>(mMainContext, mAdditionalContext, this);
                mDict.Add(holderKey, targetStorage);
            }

            return targetStorage.AddFilter(filter);
        }

        public void OnAddFilter(ulong descriptor, NewCommandFiltersStorageByTarget<T> storage)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnAddFilter descriptor = {descriptor}");

            mDescriptorsDict[descriptor] = storage;
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

        public List<T> FindExecutors(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var holderKey = command.Holder.TypeKey;

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors holderKey = {holderKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors holderName = {mMainContext.DataDictionary.GetValue(holderKey)} functionName = {mMainContext.DataDictionary.GetValue(command.Function.TypeKey)}");

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

        public void RemoveFilter(ulong descriptor)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFilter descriptor = {descriptor}");

            if(mDescriptorsDict.ContainsKey(descriptor))
            {
                mDescriptorsDict[descriptor].RemoveFilter(descriptor);
                mDescriptorsDict.Remove(descriptor);
            }
        }

        private Dictionary<ulong, NewCommandFiltersStorageByHolder<T>> mDict = new Dictionary<ulong, NewCommandFiltersStorageByHolder<T>>();
        private Dictionary<ulong, NewCommandFiltersStorageByTarget<T>> mDescriptorsDict = new Dictionary<ulong, NewCommandFiltersStorageByTarget<T>>();
    }
}
