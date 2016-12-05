using GnuClay.CommonClientTypes;
using GnuClay.Engine.InternalCommonData;
using System.Collections.Generic;

namespace GnuClay.Engine.CommonStorages
{
    public class StorageDataDictionary: BaseGnuClayEngineComponent, IReadOnlyStorageDataDictionary
    {
        public StorageDataDictionary(GnuClayEngineComponentContext context)
            : base(context)
        {
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

        private Dictionary<int, string> mKeysDict = new Dictionary<int, string>();
        private Dictionary<string, int> mValuesDict = new Dictionary<string, int>();
        private int mMaxKey = 0;

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
    }
}
