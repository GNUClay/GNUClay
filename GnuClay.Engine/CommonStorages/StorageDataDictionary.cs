using GnuClay.CommonClientTypes;
using GnuClay.Engine.InternalCommonData;
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
        }

        private object mLockObj = new object();

        public ulong GetKey(string val)
        {
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
                TSTDump();

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

            NLog.LogManager.GetCurrentClassLogger().Info($"CreateKey val = `{val}` mMaxKey = {mMaxKey}");

            return mMaxKey; 
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
                NLog.LogManager.GetCurrentClassLogger().Info("Save");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Load");

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
                NLog.LogManager.GetCurrentClassLogger().Info("Clear");

                mKeysDict = new Dictionary<ulong, string>();
                mValuesDict = new Dictionary<string, ulong>();
                mMaxKey = 0;
            }
        }

        public void TSTDump()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin TSTDump");

            foreach(var item in mKeysDict)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTDump item = {item}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End TSTDump");
        }
    }
}
