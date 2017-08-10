using GnuClay.CommonClientTypes;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class RewritingSelectQueryBuilder
    {
        public RewritingSelectQueryBuilder(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
        {
            Context = context;
            LogicalStorageContext = logicalContext;
        }

        private GnuClayEngineComponentContext Context;
        private LogicalStorageContext LogicalStorageContext;
        private SelectQuery mResult = null;

        public SelectQuery Run(RuleInstance targetItem)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run targetItem = {targetItem}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run targetItem = `{RuleInstanceDebugHelper.ConvertToString(targetItem, Context.DataDictionary)}`");
#endif

            var targetPart = targetItem.Part_1;

            mResult = new SelectQuery();

            var rootNode = targetPart.Tree;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode {ExpressionNodeDebugHelper.ConvertToString(rootNode, Context.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode node = {rootNode}");
#endif

            ProcessTree(rootNode);

            return mResult;
        }

        private void ProcessTree(ExpressionNode rootNode)
        {
            ProcessNextNode(rootNode);
        }

        private void ProcessNextNode(ExpressionNode node)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode {ExpressionNodeDebugHelper.ConvertToString(node, Context.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode node = {node}");
#endif

            var kind = node.Kind;

            switch (kind)
            {
                case ExpressionNodeKind.Relation:
                    ProcessRelationNode(node);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }
        }

        private void ProcessRelationNode(ExpressionNode node)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode (`{Context.DataDictionary.GetValue(node.Key)}`) node = {node}");
#endif
            var relationsParams = node.RelationParams;
            var paramsCount = relationsParams.Count;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode paramsCount = {paramsCount}");
#endif

            if(paramsCount != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(paramsCount), paramsCount.ToString());
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode NEXT (`{Context.DataDictionary.GetValue(node.Key)}`)");
#endif

            foreach(var tmpParam in relationsParams)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode {ExpressionNodeDebugHelper.ConvertToString(tmpParam, Context.DataDictionary)}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode tmpParam = {tmpParam}");
#endif
            }

            var targetParam = relationsParams[0];

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode {ExpressionNodeDebugHelper.ConvertToString(targetParam, Context.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode targetParam  = {targetParam}");
#endif

            var resultRelationNode = new ExpressionNode();
            resultRelationNode.Key = node.Key;
            resultRelationNode.Kind = ExpressionNodeKind.Relation;
            resultRelationNode.RelationParams = new List<ExpressionNode>();

            mResult.SelectedTree = resultRelationNode;

            var entityParam = new ExpressionNode();
            entityParam.Kind = ExpressionNodeKind.Entity;
            entityParam.Key = targetParam.Key;
            resultRelationNode.RelationParams.Add(entityParam);
        }
    }
}
