using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InternalResolverEngine
    {
        public InternalResolverEngine(InternalStorageEngine engine, StorageDataDictionary dataDictionary)
        {
            mInternalStorageEngine = engine;
            mStorageDataDictionary = dataDictionary;
        }

        private InternalStorageEngine mInternalStorageEngine = null;
        private StorageDataDictionary mStorageDataDictionary = null;

        public SelectResult SelectQuery(SelectQuery query)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("SelectQuery");

            var tmpProcess = new InternalResolverSelectProcess(query, mInternalStorageEngine, mStorageDataDictionary);

            var tmpResult = tmpProcess.Run();

            NLog.LogManager.GetCurrentClassLogger().Info("SelectQuery Finish");

            //throw new NotImplementedException();

            return tmpResult;
        }
    }
}
