using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Serialization
{
    [Serializable]
    public class SerializationInfo
    {
        public object LogicalStorageInfo;
        public object StorageDataDictionaryInfo;
        public object InheritanceEngineInfo;
        public object FunctionsEngineInfo;
    }
}
