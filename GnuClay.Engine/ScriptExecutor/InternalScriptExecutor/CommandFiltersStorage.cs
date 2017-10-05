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
            if (command.IsCallByNamedParams)
            {
                return GetNamedRank(command);
            }

            return GetPositionedRank(command);
        }

        private double GetNamedRank(Command command)
        {
            if (_ListHelper.IsEmpty(mFilter.Params))
            {
                return 0.01;
            }

            var commandParams = command.NamedParams.ToDictionary(p => p.ParamName.TypeKey, p => p);

            double result = 1;

            foreach (var filterParamKVP in mFilter.Params)
            {
                var paramKey = filterParamKVP.Key;

                if (!commandParams.ContainsKey(paramKey))
                {
                    continue;
                }

                var targetCommandParam = commandParams[paramKey];

                var filterParam = filterParamKVP.Value;

                if (filterParam.IsAnyType)
                {
                    result *= 0.1;
                }
                else
                {
                    var targetCommandParamValue = targetCommandParam.ParamValue;
                    var commandParamTypeKey = targetCommandParamValue.TypeKey;
                    var filterParamTypeKey = filterParam.TypeKey;

                    if (commandParamTypeKey == filterParamTypeKey)
                    {
                        result *= 2;
                    }
                    else
                    {
                        if(!targetCommandParamValue.IsNull)
                        {
                            var rank = mContext.InheritanceEngine.GetRank(commandParamTypeKey, filterParamTypeKey);

                            if (rank == 0)
                            {
                                return 0;
                            }

                            result *= rank;
                        }
                    }
                }

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

            return result;
        }

        private double GetPositionedRank(Command command)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank command = {command}");
#endif
            var tmpCommandParams = command.PositionedParams;
            var tmpFilterParams = mFilter.Params;

            if (tmpCommandParams.Count > tmpFilterParams.Count)
            {
                return 0;
            }

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank NEXT command = {command}");
#endif
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

#if DEBUG
                        //NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank tmpFilterParam = {tmpFilterParam}");
                        //NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank tmpCommandParam = {tmpCommandParam}");
#endif
                        if (tmpFilterParam.IsAnyType)
                        {
                            result *= 0.1;
                        }
                        else
                        {
                            var paramValue = tmpCommandParam.ParamValue;
                            var tmpCommandParamTypeKey = paramValue.TypeKey;
                            var tmpFilterParamTypeKey = tmpFilterParam.TypeKey;

                            if (tmpCommandParamTypeKey == tmpFilterParamTypeKey)
                            {
                                result *= 2;
                                continue;
                            }

                            if(paramValue.IsNull)
                            {
#if DEBUG
                                //NLog.LogManager.GetCurrentClassLogger().Info("GetPositionedRank tmpCommandParam.ParamValue.IsNull");
#endif

                                continue;
                            }

                            var rank = mContext.InheritanceEngine.GetRank(tmpCommandParamTypeKey, tmpFilterParamTypeKey);

#if DEBUG
                            //NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank rank = {rank}");
#endif
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
                            if (tmpCommandParam.ParamValue == tmpFilterParam.Value)
                            {
                                result *= 2;
                            }
                            else
                            {
                                return 0;
                            }
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

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetPositionedRank result = {result}");
#endif
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
            var targetHashCode = filter.GetLongHashCode();

            if (mDict.ContainsKey(targetHashCode))
            {
                var tmpExistingStorage = mDict[targetHashCode];

                if (tmpExistingStorage.Filter == filter)
                {
                    return tmpExistingStorage.Descriptor;
                }

                mDict.Remove(targetHashCode);
            }

            var targetStorage = new CommandFiltersStorageByParams<T>(filter, mContext);
            mDict.Add(targetHashCode, targetStorage);
            var descriptor = targetStorage.Descriptor;
            mDescriptorsDict[descriptor] = targetStorage;
            mParent.OnAddFilter(descriptor, this);
            return descriptor;
        }

        public List<T> FindExecutors(Command command)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");
#endif

            var targetFilters = new List<KeyValuePair<double, T>>();

            foreach (var item in mDict)
            {
                var value = item.Value;
                var rank = value.GetRank(command);

                if (rank == 0)
                {
                    continue;
                }

                targetFilters.Add(new KeyValuePair<double, T>(rank, value.Filter));
            }

            if (_ListHelper.IsEmpty(targetFilters))
            {
                return new List<T>();
            }

            return targetFilters.OrderByDescending(p => p.Key).Select(p => p.Value).ToList();
        }

        public T GetExecutorByDescriptor(ulong descriptor)
        {
            if (mDescriptorsDict.ContainsKey(descriptor))
            {
                var storage = mDescriptorsDict[descriptor];
                return storage.Filter;
            }

            return null;
        }

        public void RemoveFilter(ulong descriptor)
        {
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
            mParent.OnAddFilter(descriptor, storage);
        }

        public List<T> FindExecutors(Command command)
        {
            var targetKey = command.TargetKey;

            var result = new List<T>();

            if (mDict.ContainsKey(targetKey))
            {
                var tmpRez = mDict[targetKey].FindExecutors(command);

                if(!_ListHelper.IsEmpty(tmpRez))
                {
                    result.AddRange(tmpRez);
                }
            }

            if (mDict.ContainsKey(0))
            {
                var tmpRez = mDict[0].FindExecutors(command);

                if (!_ListHelper.IsEmpty(tmpRez))
                {
                    result.AddRange(tmpRez);
                }
            }

            return result;
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
            mParent.OnAddFilter(descriptor, storage);
        }

        public List<T> FindExecutors(Command command)
        {
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
        private object mLockObj = new object();

        public CommandFiltersStorage(GnuClayEngineComponentContext mainContext)
        {
            mContext = mainContext;
        }

        private GnuClayEngineComponentContext mContext = null;

        public ulong AddFilter(T filter)
        {
            lock(mLockObj)
            {
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
        }

        public void OnAddFilter(ulong descriptor, CommandFiltersStorageByTarget<T> storage)
        {
            mDescriptorsDict[descriptor] = storage;
        }

        public List<T> FindExecutors(Command command)
        {
            lock (mLockObj)
            {
                var holderKey = command.Holder.TypeKey;
                var tmpObjectsList = mContext.InheritanceEngine.LoadExecutorsQueueItems(holderKey);
                var result = new List<T>();

                foreach (var item in tmpObjectsList)
                {
                    var key = item.TypeKey;

                    if (mDict.ContainsKey(key))
                    {
                        var tmpItems = mDict[key].FindExecutors(command);

                        if (_ListHelper.IsEmpty(tmpItems))
                        {
                            continue;
                        }

                        result.AddRange(tmpItems);
                    }
                }

                return result;
            }
        }

        public T GetExecutorByDescriptor(ulong descriptor)
        {
            lock (mLockObj)
            {
                if (mDescriptorsDict.ContainsKey(descriptor))
                {
                    var storage = mDescriptorsDict[descriptor];
                    return storage.GetExecutorByDescriptor(descriptor);
                }

                return null;           
            }
        }

        public void RemoveFilter(ulong descriptor)
        {
            lock (mLockObj)
            {
                if (mDescriptorsDict.ContainsKey(descriptor))
                {
                    mDescriptorsDict[descriptor].RemoveFilter(descriptor);
                    mDescriptorsDict.Remove(descriptor);
                }
            }
        }

        private Dictionary<ulong, CommandFiltersStorageByHolder<T>> mDict = new Dictionary<ulong, CommandFiltersStorageByHolder<T>>();
        private Dictionary<ulong, CommandFiltersStorageByTarget<T>> mDescriptorsDict = new Dictionary<ulong, CommandFiltersStorageByTarget<T>>();
    }
}
