using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
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
    public class LogicalStorageEngine: BaseGnuClayEngineComponent
    {
        public LogicalStorageEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("LogicalStorageEngine");

            mInternalStorageEngine = new InternalStorageEngine();
            mInternalResolverEngine = new InternalResolverEngine(mInternalStorageEngine, Context);
        }

        private InternalStorageEngine mInternalStorageEngine = null;
        private InternalResolverEngine mInternalResolverEngine = null;

        public StorageDataDictionary DataDictionary
        {
            get
            {
                return Context.DataDictionary;
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
