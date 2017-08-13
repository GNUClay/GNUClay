using GnuClay.CommonClientTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class SetPropertyQueryBuilder
    {
        public SetPropertyQueryBuilder(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
        {
            Context = context;
            LogicalStorageContext = logicalContext;
            CommonLogicalHelper = logicalContext.CommonLogicalHelper;
            DataDictionary = Context.DataDictionary;
        }

        private GnuClayEngineComponentContext Context;
        private LogicalStorageContext LogicalStorageContext;
        private StorageDataDictionary DataDictionary;
        private CommonLogicalHelper CommonLogicalHelper;
        private InsertQuery mResult = null;

        public InsertQuery Run(IValue holder, ulong propertyKey, IValue value, bool rewrite)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run holder = {holder} propertyKey = {propertyKey} value = {value} rewrite = {rewrite}");
#endif

            mResult = new InsertQuery();
            mResult.Rewrite = rewrite;

            var item = new RuleInstance();
            mResult.Items.Add(item);

            var part = new RulePart();
            item.Part_1 = part;
            part.Parent = item;

            var rootExpressionNode = new ExpressionNode();
            part.Tree = rootExpressionNode;
            rootExpressionNode.Key = propertyKey;
            rootExpressionNode.Kind = ExpressionNodeKind.Relation;
            var relationParams = new List<ExpressionNode>();
            rootExpressionNode.RelationParams = relationParams;

            var leftParam = CommonLogicalHelper.CreateExpressionNode(holder);
            relationParams.Add(leftParam);
                
            var rightParam = CommonLogicalHelper.CreateExpressionNode(value);
            relationParams.Add(rightParam);

            return mResult;
        }
    }
}
