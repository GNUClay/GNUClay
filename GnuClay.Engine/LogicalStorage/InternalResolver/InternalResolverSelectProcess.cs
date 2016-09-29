using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class PartCaller: IToStringData
    {
        public bool IsFirstPart = true;
        public int RelationKey = 0;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(IsFirstPart));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(IsFirstPart.ToString());

            tmpSb.Append(nameof(RelationKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(RelationKey.ToString());

            return tmpSb.ToString();
        }
    }

    public class InternalResolverSelectProcess
    {
        public InternalResolverSelectProcess(SelectQuery query, InternalStorageEngine engine, StorageDataDictionary dataDictionary)
        {
            mSelectQuery = query;
            mInternalStorageEngine = engine;
            mStorageDataDictionary = dataDictionary;
        }

        private SelectQuery mSelectQuery = null;
        private InternalStorageEngine mInternalStorageEngine = null;
        private StorageDataDictionary mStorageDataDictionary = null;
        private List<RulePart> mExistsParts = new List<RulePart>();

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            ProcessTree(mSelectQuery.SelectedTree, null);

            //throw new NotImplementedException();
        }

        private void ProcessTree(ExpressionNode rootNode, PartCaller partCaler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTree {rootNode.Kind} {rootNode.Key} partCaler {partCaler?.RelationKey}");

            ProcessNextNode(rootNode, partCaler);
        }

        private void ProcessNextNode(ExpressionNode node, PartCaller partCaler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode {node.Kind} {node.Key} partCaler {partCaler?.RelationKey}");

            switch(node.Kind)
            {
                case ExpressionNodeKind.And:
                    ProcessAndNode(node, partCaler);
                    break;

                case ExpressionNodeKind.Or:
                    ProcessOrNode(node, partCaler);
                    break;

                case ExpressionNodeKind.Not:
                    ProcessNotNode(node, partCaler);
                    break;

                case ExpressionNodeKind.Relation:
                    ProcessRelationNode(node, partCaler);
                    break;

                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void ProcessAndNode(ExpressionNode node, PartCaller partCaler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAndNode {node.Kind} {node.Key}  partCaler {partCaler?.RelationKey}");

            ProcessNextNode(node.Left, partCaler);

            NLog.LogManager.GetCurrentClassLogger().Info("====================================");

            ProcessNextNode(node.Right, partCaler);
        }

        private void ProcessOrNode(ExpressionNode node, PartCaller partCaler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessOrNode {node.Kind} {node.Key}  partCaler {partCaler?.RelationKey}");

            throw new NotImplementedException();
        }

        private void ProcessNotNode(ExpressionNode node, PartCaller partCaler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNotNode {node.Kind} {node.Key}  partCaler {partCaler?.RelationKey}");

            throw new NotImplementedException();
        }

        private void ProcessRelationNode(ExpressionNode node, PartCaller partCaler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode {node.Kind} {node.Key} partCaler {partCaler?.RelationKey}");

            if(partCaler != null && partCaler.RelationKey == node.Key)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("partCaler != null && partCaler.RelationKey == node.Key");

                return ;
            }

            var tmpList = mInternalStorageEngine.GetIndex(node.Key);

            //NLog.LogManager.GetCurrentClassLogger().Info(_ListHelper._ToString(tmpList, nameof(tmpList)));
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpList.Count = {tmpList.Count}");

            foreach(var tmpPart in tmpList)
            {
                if(mExistsParts.Contains(tmpPart))
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"mExistsParts.Contains(tmpPart) {tmpPart.GetHashCode()}");

                    continue;
                }

                mExistsParts.Add(tmpPart);

                if(tmpPart.Next == null)
                {
                    ProcessFact(tmpPart);

                    continue;
                }

                ProcessRule(tmpPart, node.Key);
            }
        }

        private void ProcessRule(RulePart part, int targetKey)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRule targetKey = {targetKey}");

            var tmpPartCaller = new PartCaller();

            tmpPartCaller.IsFirstPart = true;
            tmpPartCaller.RelationKey = targetKey;

            ProcessPart(part, tmpPartCaller);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRule targetKey = {targetKey} >>>>");

            ProcessPart(part.Next, null);
        }

        private void ProcessFact(RulePart part)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessFact");

            ProcessPart(part, null);
        }

        private void ProcessPart(RulePart part, PartCaller partCaler)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPart {partCaler?.RelationKey} {part.GetHashCode()}");

            ProcessTree(part.Tree, partCaler);
        }
    }
}
