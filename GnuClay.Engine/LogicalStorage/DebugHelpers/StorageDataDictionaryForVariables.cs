using GnuClay.CommonClientTypes;
using System.Collections.Generic;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public class StorageDataDictionaryForVariables: IReadOnlyStorageDataDictionary
    {
        public string GetValue(ulong key)
        {
            if(mValuesDict.ContainsKey(key))
            {
                return mValuesDict[key];
            }

            return CreateValue(key);
        }

        private Dictionary<ulong, string> mValuesDict = new Dictionary<ulong, string>();

        private string CreateValue(ulong key)
        {
            var tmpStr = $"$X{key}";

            mValuesDict[key] = tmpStr;

            return tmpStr;
        }
    }
}
