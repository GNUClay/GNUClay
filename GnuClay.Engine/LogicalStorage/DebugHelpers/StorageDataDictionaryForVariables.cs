using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
