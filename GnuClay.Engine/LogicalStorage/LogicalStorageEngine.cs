using GnuClay.Engine.LogicalStorage.InternalResolver;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    public class LogicalStorageEngine
    {
        public LogicalStorageEngine()
        {
            mStorageDataDictionary = new StorageDataDictionary();
            mInternalStorageEngine = new InternalStorageEngine();
            mInternalResolverEngine = new InternalResolverEngine(mInternalStorageEngine, mStorageDataDictionary);
        }

        public StorageDataDictionary mStorageDataDictionary = null;
        public InternalStorageEngine mInternalStorageEngine = null;
        public InternalResolverEngine mInternalResolverEngine = null;
    }
}
