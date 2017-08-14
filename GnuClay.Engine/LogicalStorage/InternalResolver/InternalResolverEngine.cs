using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
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
        private ASTTransformer mASTTransformer = null;
        private StorageDataDictionary mDataDictionary = null;
        private CommonValuesFactory mCommonValuesFactory = null;

        public override void FirstInit()
        {
            mInternalStorageEngine = LogicalContext.InternalStorageEngine;
            mASTTransformer = LogicalContext.ASTTransformer;
            mDataDictionary = Context.DataDictionary;
            mCommonValuesFactory = Context.CommonValuesFactory;
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

        public IValue GetLogicalPropery(IValue holder, ulong propertyKey)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetLogicalPropery holder = {holder} propertyKey = {propertyKey}");
#endif
            var query = mASTTransformer.CreateGetPropertyQuery(holder, propertyKey);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetLogicalPropery query = {query}");
            NLog.LogManager.GetCurrentClassLogger().Info($"GetLogicalPropery query = {SelectQueryDebugHelper.ConvertToString(query, mDataDictionary)}");
#endif

            var result = SelectQuery(query);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(result, mDataDictionary));
            NLog.LogManager.GetCurrentClassLogger().Info($"GetLogicalPropery result = {result}");

            return mCommonValuesFactory.CreateArrayOfFacts(result);
        }

        public IValue SetLogicalProperty(IValue holder, ulong propertyKey, IValue value, bool rewrite)
        {
            var query = mASTTransformer.CreateSetPropertyQuery(holder, propertyKey, value, rewrite);
            InsertQuery(query);
            var keyOfFact = query.Items[0].Key;
            return mCommonValuesFactory.CreateDirectFactValue(keyOfFact);
        }
    }
}
