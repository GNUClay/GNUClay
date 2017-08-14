using GnuClay.CommonClientTypes;
using GnuClay.Engine.CommonStorages;
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
    public class RewritingSelectQueryBuilder: BaseQueryBuilder
    {
        public RewritingSelectQueryBuilder(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
            : base(context, logicalContext)
        {
        }

        private SelectQuery mResult = null;

        public SelectQuery Run(RuleInstance targetItem)
        {
            var targetPart = targetItem.Part_1;
            mResult = new SelectQuery();
            var rootNode = targetPart.Tree;
            ProcessTree(rootNode);
            return mResult;
        }

        private void ProcessTree(ExpressionNode rootNode)
        {
            ProcessNextNode(rootNode);
        }

        private void ProcessNextNode(ExpressionNode node)
        {
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
            var relationsParams = node.RelationParams;
            var paramsCount = relationsParams.Count;

            if(paramsCount != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(paramsCount), paramsCount.ToString());
            }

            var targetParam = relationsParams[0];

            var resultRelationNode = new ExpressionNode();
            resultRelationNode.Key = node.Key;
            resultRelationNode.Kind = ExpressionNodeKind.Relation;
            var relationParams = new List<ExpressionNode>();
            resultRelationNode.RelationParams = relationParams;
            mResult.SelectedTree = resultRelationNode;

            var entityParam = new ExpressionNode();
            entityParam.Kind = ExpressionNodeKind.Entity;
            entityParam.Key = targetParam.Key;
            relationParams.Add(entityParam);

            var variableParam = new ExpressionNode();
            variableParam.Kind = ExpressionNodeKind.Var;
            variableParam.Key = DataDictionary.GetKey("$x1");
            relationParams.Add(variableParam);
        }
    }
}
