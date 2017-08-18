using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class ExpressionNodeDebugHelper
    {
        public static string ConvertToString(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            return ProcesNode(node, dataDictionary);
        }

        private static string ProcesNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            if(node == null)
            {
                return string.Empty;
            }

            switch (node.Kind)
            {
                case ExpressionNodeKind.And:
                    return ProcessAndNode(node, dataDictionary);

                case ExpressionNodeKind.Or:
                    return ProcessOrNode(node, dataDictionary);

                case ExpressionNodeKind.Not:
                    return ProcessNotNode(node, dataDictionary);

                case ExpressionNodeKind.Relation:
                    return ProcessRelationNode(node, dataDictionary);

                case ExpressionNodeKind.Entity:
                    return ProcessEntityNode(node, dataDictionary);

                case ExpressionNodeKind.Var:
                    return ProcessVarNode(node, dataDictionary);

                case ExpressionNodeKind.Value:
                    return ProcessValueNode(node, dataDictionary);

                default: throw new ArgumentOutOfRangeException(nameof(node.Kind), node.Kind.ToString());
            }
        }

        private static string ProcessAndNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            return $"{ProcesNode(node.Left, dataDictionary)} & {ProcesNode(node.Right, dataDictionary)}";
        }

        private static string ProcessOrNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            return $"{ProcesNode(node.Left, dataDictionary)} | {ProcesNode(node.Right, dataDictionary)}";
        }

        private static string ProcessNotNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            return $"!{ProcesNode(node.Left, dataDictionary)}";
        }

        private static string ProcessRelationNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            if(node.KeyOfReference > 0)
            {
                tmpSb.Append($"{dataDictionary.GetValue(node.KeyOfReference)}:");
            }

            tmpSb.Append(dataDictionary.GetValue(node.Key));
            tmpSb.Append("(");

            foreach (var tmpParam in node.RelationParams)
            {
                tmpSb.Append(ProcesNode(tmpParam, dataDictionary));
                tmpSb.Append(",");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            tmpSb.Append(")");

            return tmpSb.ToString();
        }

        private static string ProcessEntityNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            if (node.KeyOfReference > 0)
            {
                tmpSb.Append($"{dataDictionary.GetValue(node.KeyOfReference)}:");
            }

            tmpSb.Append(dataDictionary.GetValue(node.Key));
            return tmpSb.ToString();
        }

        private static string ProcessVarNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            return dataDictionary.GetValue(node.Key);
        }

        private static string ProcessValueNode(ExpressionNode node, IReadOnlyStorageDataDictionary dataDictionary)
        {
            if(node.Value == null)
            {
                return "null";
            }

            return node.Value.ToString();
        }
    }
}
