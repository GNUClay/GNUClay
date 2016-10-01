using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
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
        private List<RuleInstance> mExistingsRules = new List<RuleInstance>();

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            //var tmpParamsBinder = new ParamsBinder();

            var tmpInternalResult = new InternalResult();

            ProcessTree(mSelectQuery.SelectedTree, null, ref tmpInternalResult);

            //throw new NotImplementedException();
        }

        private void ProcessTree(ExpressionNode rootNode, ParamsBinder paramsBinder, ref InternalResult result)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTree `{ExpressionNodeDebugHelper.ConvertToString(rootNode, mStorageDataDictionary, null)}` partCaler = {paramsBinder?.RelationKey}");

            ProcessNextNode(rootNode, paramsBinder, ref result);
        }

        private void ProcessNextNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            switch(node.Kind)
            {
                case ExpressionNodeKind.And:
                    ProcessAndNode(node, paramsBinder, ref result);
                    break;

                case ExpressionNodeKind.Or:
                    ProcessOrNode(node, paramsBinder, ref result);
                    break;

                case ExpressionNodeKind.Not:
                    ProcessNotNode(node, paramsBinder, ref result);
                    break;

                case ExpressionNodeKind.Relation:
                    ProcessRelationNode(node, paramsBinder, ref result);
                    break;

                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void ProcessAndNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAndNode {node.Kind} {node.Key}  partCaler {partCaler?.RelationKey}");

            var tmpLeftResult = new InternalResult();

            ProcessNextNode(node.Left, paramsBinder, ref tmpLeftResult);

            NLog.LogManager.GetCurrentClassLogger().Info($"==== `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}`");

            var tmpRightResult = new InternalResult();

            ProcessNextNode(node.Right, paramsBinder, ref tmpRightResult);
        }

        private void ProcessOrNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessOrNode {node.Kind} {node.Key}  partCaler {paramsBinder?.RelationKey}");

            throw new NotImplementedException();
        }

        private void ProcessNotNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNotNode {node.Kind} {node.Key}  partCaler {paramsBinder?.RelationKey}");

            throw new NotImplementedException();
        }

        private void ProcessRelationNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode {node.Kind} `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}` node.Key = {node.Key} partCaler = {paramsBinder?.RelationKey}");

            if(paramsBinder != null && paramsBinder.RelationKey == node.Key)
            {
                return ;
            }

            var tmpList = mInternalStorageEngine.GetIndex(node.Key);

            foreach(var tmpPart in tmpList)
            {
                if(mExistingsRules.Contains(tmpPart.Parent))
                {
                    continue;
                }

                var tmpBinder = ParamsBinder.FromRelationNode(node, paramsBinder);

                NLog.LogManager.GetCurrentClassLogger().Info(tmpBinder);

                if (tmpPart.Next == null)
                {
                    ProcessFact(tmpPart, tmpBinder, ref result);

                    continue;
                }

                ProcessRule(tmpPart, tmpBinder, ref result);
            }
        }

        private void ProcessRule(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRule targetKey = {paramsBinder.RelationKey} `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");

            mExistingsRules.Add(part.Parent);

            if(!BindParams(part.Parent, paramsBinder))
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($">>>> ProcessRule {paramsBinder}");

            var tmpFirstPartResult = new InternalResult();

            ProcessPart(part, paramsBinder, ref tmpFirstPartResult);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRule targetKey = {paramsBinder.RelationKey} >>>> `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");

            var tmpSecondPartResult = new InternalResult();

            ProcessPart(part.Next, paramsBinder, ref tmpSecondPartResult);
        }

        private bool BindParams(RuleInstance ruleInstance, ParamsBinder paramsBinder)
        {
            if(ruleInstance.VarsCount > paramsBinder.ParamsList.Count)
            {
                return false;
            }

            var tmpTargetNode = ruleInstance.GetRealationNodeByKey(paramsBinder.RelationKey);

            var tmpBinderParamsIterator = paramsBinder.ParamsList.GetEnumerator();
            var tmpTargetNodeParamsIterator = tmpTargetNode.RelationParams.GetEnumerator();

            while(tmpBinderParamsIterator.MoveNext())
            {
                tmpTargetNodeParamsIterator.MoveNext();

                var tmpCurrBinderParam = tmpBinderParamsIterator.Current;

                tmpCurrBinderParam.Key_Down = tmpTargetNodeParamsIterator.Current.Key;

                if(tmpCurrBinderParam.IsEntity)
                {
                    paramsBinder.VarsWithEntities[tmpCurrBinderParam.Key_Down] = tmpCurrBinderParam.EntityKey;
                }
            }

            return true;
        }

        private void ProcessFact(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            mExistingsRules.Add(part.Parent);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessFact {RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info(paramsBinder);
            NLog.LogManager.GetCurrentClassLogger().Info("Tree boundary");
        }

        private void ProcessPart(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPart `{ExpressionNodeDebugHelper.ConvertToString(part.Tree, mStorageDataDictionary, null)}`");

            ProcessTree(part.Tree, paramsBinder, ref result);
        }
    }
}
