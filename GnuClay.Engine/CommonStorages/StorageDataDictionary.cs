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

        public int GetKey(string val)
        {
            if(mValuesDict.ContainsKey(val))
            {
                return mValuesDict[val];
            }

            return CreateKey(val);
        }

        public string GetValue(int key)
        {
            return mKeysDict[key];
        }

        private Dictionary<int, string> mKeysDict;
        private Dictionary<string, int> mValuesDict;
        private int mMaxKey;

        private int CreateKey(string val)
        {
            mMaxKey++;

            mKeysDict[mMaxKey] = val;
            mValuesDict[val] = mMaxKey;

            return mMaxKey; 
        }

        public int UniqueKeysCount()
        {
            return mKeysDict.Count;
        }

        [Serializable]
        private class Data
        {
            public Dictionary<int, string> mKeysDict;
            public Dictionary<string, int> mValuesDict;
            public int mMaxKey;
        }

        public object Save()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Save");

            var tmpData = new Data();
            tmpData.mKeysDict = mKeysDict;
            tmpData.mValuesDict = mValuesDict;
            tmpData.mMaxKey = mMaxKey;
            return tmpData;
        }

        public void Load(object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Load");

            var tmpData = (Data)value;
            mKeysDict = tmpData.mKeysDict;
            mValuesDict = tmpData.mValuesDict;
            mMaxKey = tmpData.mMaxKey;
        }

        public void Clear()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clear");

            mKeysDict = new Dictionary<int, string>();
            mValuesDict = new Dictionary<string, int>();
            mMaxKey = 0;
        }
    }
}
