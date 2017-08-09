using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using System;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InternalResolverEngine
    {
        public InternalResolverEngine(InternalStorageEngine engine, GnuClayEngineComponentContext context)
        {
            mInternalStorageEngine = engine;
            mContext = context;
        }

        private InternalStorageEngine mInternalStorageEngine = null;
        private GnuClayEngineComponentContext mContext = null;

        public SelectResult SelectQuery(SelectQuery query)
        {
            var tmpProcess = new InternalResolverSelectProcess(query, mInternalStorageEngine, mContext);
            var tmpResult = tmpProcess.Run();
            return tmpResult;
        }

        public void InsertQuery(InsertQuery query)
        {
            var tmpProcess = new InternalResolverInsertProcess(query, mInternalStorageEngine, mContext);
            tmpProcess.Run();
        }

        public void RemoveFacts(SelectQuery query)
        {
            query.SelectDirectFactsOnly = true;

            var selectResult = SelectQuery(query);

            if(!selectResult.Success || !selectResult.HaveBeenFound)
            {
                return;
            }

            foreach(var item in selectResult.Items)
            {
                var key = item.Key;

                if(key == 0)
                {
                    continue;
                }

                mInternalStorageEngine.RemoveFactOrRuleByKey(key);
            }
        }
    }
}
