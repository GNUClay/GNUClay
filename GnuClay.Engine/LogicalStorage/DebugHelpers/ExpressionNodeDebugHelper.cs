using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class ExpressionNodeDebugHelper
    {
        public static string ConvertToString(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            if(localDataDictionary == null)
            {
                localDataDictionary = new StorageDataDictionaryForVariables();
            }

            return ProcesNode(node, dataDictionary, localDataDictionary);
        }

        private static string ProcesNode(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            switch (node.Kind)
            {
                case ExpressionNodeKind.And:
                    return ProcessAndNode(node, dataDictionary, localDataDictionary);

                case ExpressionNodeKind.Or:
                    return ProcessOrNode(node, dataDictionary, localDataDictionary);

                case ExpressionNodeKind.Not:
                    return ProcessNotNode(node, dataDictionary, localDataDictionary);

                case ExpressionNodeKind.Relation:
                    return ProcessRelationNode(node, dataDictionary, localDataDictionary);

                case ExpressionNodeKind.Entity:
                    return ProcessEntityNode(node, dataDictionary, localDataDictionary);

                case ExpressionNodeKind.Var:
                    return ProcessVarNode(node, dataDictionary, localDataDictionary);

                default: throw new ArgumentOutOfRangeException();
            }
        }

        private static string ProcessAndNode(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            return $"{ProcesNode(node.Left, dataDictionary, localDataDictionary)} & {ProcesNode(node.Right, dataDictionary, localDataDictionary)}";
        }

        private static string ProcessOrNode(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            return $"{ProcesNode(node.Left, dataDictionary, localDataDictionary)} | {ProcesNode(node.Right, dataDictionary, localDataDictionary)}";
        }

        private static string ProcessNotNode(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            return $"{ProcesNode(node.Left, dataDictionary, localDataDictionary)}";
        }

        private static string ProcessRelationNode(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(dataDictionary.GetValue(node.Key));
            tmpSb.Append("(");

            foreach (var tmpParam in node.RelationParams)
            {
                tmpSb.Append(ProcesNode(tmpParam, dataDictionary, localDataDictionary));
                tmpSb.Append(",");
            }

            tmpSb.Remove(tmpSb.Length - 1, 1);

            tmpSb.Append(")");

            return tmpSb.ToString();
        }

        private static string ProcessEntityNode(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            return dataDictionary.GetValue(node.Key);
        }

        private static string ProcessVarNode(ExpressionNode node, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
        {
            return localDataDictionary.GetValue(node.Key);
        }
    }
}
