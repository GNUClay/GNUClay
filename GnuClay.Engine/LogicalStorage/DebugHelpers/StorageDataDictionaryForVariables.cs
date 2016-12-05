using GnuClay.CommonClientTypes;
using System.Collections.Generic;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public class StorageDataDictionaryForVariables: IReadOnlyStorageDataDictionary
    {
        public string GetValue(int key)
        {
            if(mValuesDict.ContainsKey(key))
            {
                return mValuesDict[key];
            }

            return CreateValue(key);
        }

        private Dictionary<int, string> mValuesDict = new Dictionary<int, string>();

        private string CreateValue(int key)
        {
            var tmpStr = $"$X{key}";

            mValuesDict[key] = tmpStr;

            return tmpStr;
        }

        public int UniqueKeysCount()
        {
            return mValuesDict.Count;
        }
    }
}
