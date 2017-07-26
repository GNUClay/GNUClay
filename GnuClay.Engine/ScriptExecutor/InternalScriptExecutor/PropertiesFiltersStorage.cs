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
            var propertyKey = filter.PropertyKey;

            if(mDict.ContainsKey(propertyKey))
            {
                var tmpExistingStorage = mDict[propertyKey];

                if (tmpExistingStorage.Filter == filter)
                {
                    return tmpExistingStorage.Descriptor;
                }

                mDict.Remove(propertyKey);
            }

            var targetStorage = new PropertiesFiltersStorageByType(filter, mContext);
            mDict.Add(propertyKey, targetStorage);

            var descriptor = targetStorage.Descriptor;

            mDescriptorsDict[descriptor] = targetStorage;

            mParent.OnAddFilter(descriptor, this);

            return descriptor;
        }

        public List<PropertyFilter> FindExecutors(PropertyCommand command)
        {
            var propertyKey = command.PropertyKey;

            if(!mDict.ContainsKey(propertyKey))
            {
                return null;
            }

            var targetFilter = mDict[propertyKey].Filter;

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
                if (command.Value == targetFilter.Value)
                {
                    result *= 2;
                }
                else
                {
                    return null;
                }
            }

            if(result > 0)
            {
                return new List<PropertyFilter>() { targetFilter };
            }

            return null;
        }

        public void RemoveFilter(ulong descriptor)
        {
            var targetStorage = mDescriptorsDict[descriptor];
            mDescriptorsDict.Remove(descriptor);

            var propertyKey = targetStorage.Filter.PropertyKey;

            mDict.Remove(propertyKey);
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
            mDescriptorsDict[descriptor] = storage;
        }

        public List<PropertyFilter> FindExecutors(PropertyCommand command)
        {
            var holderKey = command.Holder.TypeKey;

            var tmpObjectsList = mContext.InheritanceEngine.LoadExecutorsQueueItems(holderKey);

            var result = new List<PropertyFilter>();

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

        public void RemoveFilter(ulong descriptor)
        {
            if (mDescriptorsDict.ContainsKey(descriptor))
            {
                mDescriptorsDict[descriptor].RemoveFilter(descriptor);
                mDescriptorsDict.Remove(descriptor);
            }
        }

        private Dictionary<ulong, PropertiesFiltersStorageByHolder> mDict = new Dictionary<ulong, PropertiesFiltersStorageByHolder>();
        private Dictionary<ulong, PropertiesFiltersStorageByHolder> mDescriptorsDict = new Dictionary<ulong, PropertiesFiltersStorageByHolder>();
    }
}
