using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class PropertiesFiltersStorageByType
    {
        public PropertiesFiltersStorageByType(PropertyFilter filter, GnuClayEngineComponentContext context)
        {
            mContext = context;
            Filter = filter;

            mNameOfDescriptor = Guid.NewGuid().ToString("D");
            mKeyOfDescriptor = mContext.DataDictionary.GetKey(mNameOfDescriptor);
        }

        private GnuClayEngineComponentContext mContext = null;
        public PropertyFilter Filter { get; private set; }

        private string mNameOfDescriptor = string.Empty;
        private ulong mKeyOfDescriptor = 0;

        public ulong Descriptor
        {
            get
            {
                return mKeyOfDescriptor;
            }
        }


    }

    public class PropertiesFiltersStorageByHolder
    {
        public PropertiesFiltersStorageByHolder(GnuClayEngineComponentContext context, PropertiesFiltersStorage parent)
        {
            mContext = context;
            mParent = parent;
        }

        private GnuClayEngineComponentContext mContext = null;
        private PropertiesFiltersStorage mParent = null;

        public ulong AddFilter(PropertyFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var propertyKey = filter.PropertyKey;

            if(mDict.ContainsKey(propertyKey))
            {
                var tmpExistingStorage = mDict[propertyKey];

                if (tmpExistingStorage.Filter == filter)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter tmpExistingStorage.Filter == filter filter = {filter}");

                    return tmpExistingStorage.Descriptor;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter mDict.Remove(propertyKey) filter = {filter}");

                mDict.Remove(propertyKey);
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter NEXT filter = {filter}");

            var targetStorage = new PropertiesFiltersStorageByType(filter, mContext);
            mDict.Add(propertyKey, targetStorage);

            var descriptor = targetStorage.Descriptor;

            mDescriptorsDict[descriptor] = targetStorage;

            mParent.OnAddFilter(descriptor, this);

            return descriptor;
        }

        public List<PropertyFilter> FindExecutors(PropertyCommand command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var propertyKey = command.PropertyKey;

            if(!mDict.ContainsKey(propertyKey))
            {
                return null;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors NEXT command = {command}");

            var targetFilter = mDict[propertyKey].Filter;

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors NEXT targetFilter = {targetFilter}");

            double result = 1;

            if (targetFilter.IsAnyType)
            {
                result *= 0.1;
            }
            else
            {
                var tmpCommandTypeKey = command.Value.TypeKey;;
                var tmpFilterTypeKey = targetFilter.TypeKey;

                if (tmpCommandTypeKey == tmpFilterTypeKey)
                {
                    result *= 2;
                }
                else
                {
                    var rank = mContext.InheritanceEngine.GetRank(tmpCommandTypeKey, tmpFilterTypeKey);

                    NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors rank = {rank}");

                    if (rank == 0)
                    {
                        return null;
                    }

                    result *= rank;
                }
            }

            if (targetFilter.IsAnyValue)
            {
                result *= 0.1;
            }
            else
            {
                throw new NotImplementedException();
            }

            if(result > 0)
            {
                return new List<PropertyFilter>() { targetFilter };
            }

            return null;
        }

        private Dictionary<ulong, PropertiesFiltersStorageByType> mDict = new Dictionary<ulong, PropertiesFiltersStorageByType>();
        private Dictionary<ulong, PropertiesFiltersStorageByType> mDescriptorsDict = new Dictionary<ulong, PropertiesFiltersStorageByType>();
    }

    public class PropertiesFiltersStorage
    {
        public PropertiesFiltersStorage(GnuClayEngineComponentContext context)
        {
            mContext = context;
        }

        private GnuClayEngineComponentContext mContext = null;

        public ulong AddFilter(PropertyFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            var holderKey = filter.HolderKey;

            PropertiesFiltersStorageByHolder targetStorage = null;

            if(mDict.ContainsKey(holderKey))
            {
                targetStorage = mDict[holderKey];
            }
            else
            {
                targetStorage = new PropertiesFiltersStorageByHolder(mContext, this);
                mDict[holderKey] = targetStorage;
            }

            return targetStorage.AddFilter(filter);
        }

        public void OnAddFilter(ulong descriptor, PropertiesFiltersStorageByHolder storage)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnAddFilter descriptor = {descriptor}");

            mDescriptorsDict[descriptor] = storage;
        }

        public List<PropertyFilter> FindExecutors(PropertyCommand command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors command = {command}");

            var holderKey = command.Holder.TypeKey;

            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors holderKey = {holderKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors holderName = {mContext.DataDictionary.GetValue(holderKey)} functionName = {mContext.DataDictionary.GetValue(command.Holder.TypeKey)}");

            var tmpObjectsList = mContext.InheritanceEngine.LoadExecutorsQueueItems(holderKey);

            var result = new List<PropertyFilter>();

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

            throw new NotImplementedException();
        }

        private Dictionary<ulong, PropertiesFiltersStorageByHolder> mDict = new Dictionary<ulong, PropertiesFiltersStorageByHolder>();
        private Dictionary<ulong, PropertiesFiltersStorageByHolder> mDescriptorsDict = new Dictionary<ulong, PropertiesFiltersStorageByHolder>();
    }
}
