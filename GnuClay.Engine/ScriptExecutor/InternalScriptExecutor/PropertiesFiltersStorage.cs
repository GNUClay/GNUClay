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

            var targetStorage = new PropertiesFiltersStorageByType(filter, mContext);
            mDict.Add(targetHashCode, targetStorage);

            var descriptor = targetStorage.Descriptor;

            mDescriptorsDict[descriptor] = targetStorage;

            mParent.OnAddFilter(descriptor, this);

            return descriptor;
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

        public List<PropertyFilter> FindExecutors(IValue value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FindExecutors value = {value}");

            throw new NotImplementedException();
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
