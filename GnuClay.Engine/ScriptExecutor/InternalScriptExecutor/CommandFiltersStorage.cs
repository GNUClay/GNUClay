using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class CommandFiltersStorageByParams<T>
        where T : BaseCommandFilter
    {
        public CommandFiltersStorageByParams(T filter, GnuClayEngineComponentContext mainContext)
        {
            mContext = mainContext;

            mNameOfDescriptor = Guid.NewGuid().ToString("D");
            mKeyOfDescriptor = mContext.DataDictionary.GetKey(mNameOfDescriptor);

            mFilter = filter;
        }

        private GnuClayEngineComponentContext mContext = null;

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

            if (command.IsCallByNamedParams)
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

                NLog.LogManager.GetCurrentClassLogger().Info($"GetNamedRank paramName = {paramKey} paramName = {mContext.DataDictionary.GetValue(paramKey)}");

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
                        var rank = mContext.InheritanceEngine.GetRank(commandParamTypeKey, filterParamTypeKey);

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
                    if (tmpCommandParamsEnumerator.MoveNext())
                    {
                        var tmpCommandParam = tmpCommandParamsEnumerator.Current;

                        NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank tmpFilterParam = {tmpFilterParam}");
                        NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank tmpCommandParam = {tmpCommandParam}");

                        if (tmpFilterParam.IsAnyType)
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

                            var rank = mContext.InheritanceEngine.GetRank(tmpCommandParamTypeKey, tmpFilterParamTypeKey);

                            NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank rank = {rank}");

                            if (rank == 0)
                            {
                                return 0;
                            }

                            result *= rank;
                        }

                        if (tmpFilterParam.IsAnyValue)
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

    public class CommandFiltersStorageByTarget<T>
        where T : BaseCommandFilter
    {
        public CommandFiltersStorageByTarget(GnuClayEngineComponentContext mainContext, CommandFiltersStorageByFunction<T> parent)
        {
            mContext = mainContext;
            mParent = parent;
        }

        private GnuClayEngineComponentContext mContext = null;
        private CommandFiltersStorageByFunction<T> mParent = null;

        public ulong AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetHashCode = filter.GetLongHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                var tmpExistingStorage = mDict[targetHashCode];

                if (tmpExistingStorage.Filter == filter)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter tmpExistingStorage.Filter == filter filter = {filter}");

                    return tmpExistingStorage.Descriptor;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter mDict.Remove(targetHashCode) filter = {filter}");

                mDict.Remove(targetHashCode);
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter NEXT filter = {filter}");

            var targetStorage = new CommandFiltersStorageByParams<T>(filter, mContext);
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

        private Dictionary<ulong, CommandFiltersStorageByParams<T>> mDict = new Dictionary<ulong, CommandFiltersStorageByParams<T>>();
        private Dictionary<ulong, CommandFiltersStorageByParams<T>> mDescriptorsDict = new Dictionary<ulong, CommandFiltersStorageByParams<T>>();
    }

    public class CommandFiltersStorageByFunction<T>
        where T : BaseCommandFilter
    {
        public CommandFiltersStorageByFunction(GnuClayEngineComponentContext mainContext, CommandFiltersStorageByHolder<T> parent)
        {
            mContext = mainContext;
            mParent = parent;
        }

        private GnuClayEngineComponentContext mContext = null;
        private CommandFiltersStorageByHolder<T> mParent = null;

        public ulong AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var targetKey = filter.TargetKey;

            CommandFiltersStorageByTarget<T> targetStorage = null;

            if (mDict.ContainsKey(targetKey))
            {
                targetStorage = mDict[targetKey];
            }
            else
            {
                targetStorage = new CommandFiltersStorageByTarget<T>(mContext, this);
                mDict.Add(targetKey, targetStorage);
            }

            return targetStorage.AddFilter(filter);
        }

        public void OnAddFilter(ulong descriptor, CommandFiltersStorageByTarget<T> storage)
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

        private Dictionary<ulong, CommandFiltersStorageByTarget<T>> mDict = new Dictionary<ulong, CommandFiltersStorageByTarget<T>>();
    }

    public class CommandFiltersStorageByHolder<T>
        where T : BaseCommandFilter
    {
        public CommandFiltersStorageByHolder(GnuClayEngineComponentContext mainContext, CommandFiltersStorage<T> parent)
        {
            mContext = mainContext;
            mParent = parent;
        }

        private GnuClayEngineComponentContext mContext = null;
        private CommandFiltersStorage<T> mParent = null;

        public ulong AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var functionKey = filter.FunctionKey;

            CommandFiltersStorageByFunction<T> targetStorage = null;

            if (mDict.ContainsKey(functionKey))
            {
                targetStorage = mDict[functionKey];
            }
            else
            {
                targetStorage = new CommandFiltersStorageByFunction<T>(mContext, this);
                mDict.Add(functionKey, targetStorage);
            }

            return targetStorage.AddFilter(filter);
        }

        public void OnAddFilter(ulong descriptor, CommandFiltersStorageByTarget<T> storage)
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

        private Dictionary<ulong, CommandFiltersStorageByFunction<T>> mDict = new Dictionary<ulong, CommandFiltersStorageByFunction<T>>();
    }

    public class CommandFiltersStorage<T>
        where T : BaseCommandFilter
    {
        public CommandFiltersStorage(GnuClayEngineComponentContext mainContext)
        {
            mContext = mainContext;
        }

        private GnuClayEngineComponentContext mContext = null;

        public ulong AddFilter(T filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var holderKey = filter.HolderKey;

            CommandFiltersStorageByHolder<T> targetStorage = null;

            if (mDict.ContainsKey(holderKey))
            {
                targetStorage = mDict[holderKey];
            }
            else
            {
                targetStorage = new CommandFiltersStorageByHolder<T>(mContext, this);
                mDict.Add(holderKey, targetStorage);
            }

            return targetStorage.AddFilter(filter);
        }

        public void OnAddFilter(ulong descriptor, CommandFiltersStorageByTarget<T> storage)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnAddFilter descriptor = {descriptor}");

            mDescriptorsDict[descriptor] = storage;
        }

        public List<T> FindExecutors(Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var holderKey = command.Holder.TypeKey;

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors holderKey = {holderKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors holderName = {mContext.DataDictionary.GetValue(holderKey)} functionName = {mContext.DataDictionary.GetValue(command.Function.TypeKey)}");

            var tmpObjectsList = mContext.InheritanceEngine.LoadExecutorsQueueItems(holderKey);

            var result = new List<T>();

            foreach (var item in tmpObjectsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors item = {item}");

                var key = item.TypeKey;

                if (mDict.ContainsKey(key))
                {
                    var tmpItems = mDict[key].FindExecutors(command);

                    NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors tmpItems.Count = {tmpItems.Count}");

                    if (_ListHelper.IsEmpty(tmpItems))
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

            if (mDescriptorsDict.ContainsKey(descriptor))
            {
                mDescriptorsDict[descriptor].RemoveFilter(descriptor);
                mDescriptorsDict.Remove(descriptor);
            }
        }

        private Dictionary<ulong, CommandFiltersStorageByHolder<T>> mDict = new Dictionary<ulong, CommandFiltersStorageByHolder<T>>();
        private Dictionary<ulong, CommandFiltersStorageByTarget<T>> mDescriptorsDict = new Dictionary<ulong, CommandFiltersStorageByTarget<T>>();
    }
}
