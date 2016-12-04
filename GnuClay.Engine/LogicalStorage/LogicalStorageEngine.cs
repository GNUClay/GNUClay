using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalResolver;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;

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
