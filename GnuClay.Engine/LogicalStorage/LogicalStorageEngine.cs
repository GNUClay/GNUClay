using GnuClay.Engine.LogicalStorage.CommonData;
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

        private StorageDataDictionary mStorageDataDictionary = null;
        private InternalStorageEngine mInternalStorageEngine = null;
        private InternalResolverEngine mInternalResolverEngine = null;

        public StorageDataDictionary DataDictionary
        {
            get
            {
                return mStorageDataDictionary;
            }
        }

        public SelectResult SelectQuery(SelectQuery query)
        {
            return mInternalResolverEngine.SelectQuery(query);
        }

        public void InsertQuery(InsertQuery query)
        {
            mInternalResolverEngine.InsertQuery(query);
        }
    }
}
