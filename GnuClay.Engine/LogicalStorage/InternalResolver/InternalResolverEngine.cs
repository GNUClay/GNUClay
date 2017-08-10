using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using System;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InternalResolverEngine : BaseLogicalStorageComponent
    {
        public InternalResolverEngine(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
            : base(context, logicalContext)
        {
        }

        private InternalStorageEngine mInternalStorageEngine = null;

        public override void FirstInit()
        {
            mInternalStorageEngine = LogicalContext.InternalStorageEngine;
        }

        public SelectResult SelectQuery(SelectQuery query)
        {
            var tmpProcess = new InternalResolverSelectProcess(query, Context, LogicalContext);
            var tmpResult = tmpProcess.Run();
            return tmpResult;
        }

        public void InsertQuery(InsertQuery query)
        {
            var tmpProcess = new InternalResolverInsertProcess(query, Context, LogicalContext);
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
