using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalStorage
{
    public class StorageDataDictionary
    {
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
    }
}
