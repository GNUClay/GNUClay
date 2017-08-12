using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.ScriptExecutor;
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

        public SelectResult GetLogicalPropery(IValue holder, ulong propertyKey)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetLogicalPropery holder = {holder} propertyKey = {propertyKey}");
#endif

            throw new NotImplementedException();
        }

        public ulong SetLogicalProperty(IValue holder, ulong propertyKey, IValue value, bool rewrite)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalProperty holder = {holder} propertyKey = {propertyKey} value = {value} rewrite = {rewrite}");
#endif

            throw new NotImplementedException();
        }
    }
}
