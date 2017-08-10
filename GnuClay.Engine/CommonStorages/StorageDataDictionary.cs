using GnuClay.CommonClientTypes;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;

namespace GnuClay.Engine.CommonStorages
{
    public class StorageDataDictionary: BaseGnuClayEngineComponent, IReadOnlyStorageDataDictionary
    {
        public StorageDataDictionary(GnuClayEngineComponentContext context)
            : base(context)
        {
            Clear();

            GetKey(StandartTypeNamesConstants.UniversalTypeName);
        }

        private object mLockObj = new object();

        public ulong GetKey(string val)
        {
            val = val.ToLower();

            lock(mLockObj)
            {
                if (mValuesDict.ContainsKey(val))
                {
                    return mValuesDict[val];
                }

                return CreateKey(val);
            }
        }

        public string GetValue(ulong key)
        {
            lock (mLockObj)
            {
                //TSTDump();

                return mKeysDict[key];
            }       
        }

        private Dictionary<ulong, string> mKeysDict;
        private Dictionary<string, ulong> mValuesDict;
        private ulong mMaxKey;

        private ulong CreateKey(string val)
        {
            mMaxKey++;

            mKeysDict[mMaxKey] = val;
            mValuesDict[val] = mMaxKey;

            return mMaxKey; 
        }

        public void RemoveKey(ulong key)
        {
            lock (mLockObj)
            {
                var value = mKeysDict[key];
                mKeysDict.Remove(key);
                mValuesDict.Remove(value);
            }
        }

        [Serializable]
        private class Data
        {
            public Dictionary<ulong, string> mKeysDict;
            public Dictionary<string, ulong> mValuesDict;
            public ulong mMaxKey;
        }

        public object Save()
        {
            lock (mLockObj)
            {
                var tmpData = new Data();
                tmpData.mKeysDict = mKeysDict;
                tmpData.mValuesDict = mValuesDict;
                tmpData.mMaxKey = mMaxKey;
                return tmpData;
            }
        }

        public void Load(object value)
        {
            lock (mLockObj)
            {
                var tmpData = (Data)value;
                mKeysDict = tmpData.mKeysDict;
                mValuesDict = tmpData.mValuesDict;
                mMaxKey = tmpData.mMaxKey;
            }
        }

        public void Clear()
        {
            lock (mLockObj)
            {
                mKeysDict = new Dictionary<ulong, string>();
                mValuesDict = new Dictionary<string, ulong>();
                mMaxKey = 0;
            }
        }

#if DEBUG
        public void TSTDump()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin TSTDump");

            foreach(var item in mKeysDict)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTDump item = {item}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End TSTDump");
        }
#endif
    }
}
