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
            NLog.LogManager.GetCurrentClassLogger().Info($"Run `{ExpressionNodeDebugHelper.ConvertToString(mSelectQuery.SelectedTree, mStorageDataDictionary, null)}`");

            var tmpInternalResult = new InternalResult();

            ProcessTree(mSelectQuery.SelectedTree, null, ref tmpInternalResult);

            NLog.LogManager.GetCurrentClassLogger().Info("Begin tmpInternalResult");

            foreach (var tmpRezItem in tmpInternalResult.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{InternalResultItemDebugHelper.ConvertToString(tmpRezItem, mStorageDataDictionary, null)}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End tmpInternalResult");

            NLog.LogManager.GetCurrentClassLogger().Info($"End Run `{ExpressionNodeDebugHelper.ConvertToString(mSelectQuery.SelectedTree, mStorageDataDictionary, null)}`");

            //throw new NotImplementedException();
        }

        private void ProcessTree(ExpressionNode rootNode, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTree `{ExpressionNodeDebugHelper.ConvertToString(rootNode, mStorageDataDictionary, null)}` partCaler = {paramsBinder?.RelationKey}");

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
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAndNode pre Left `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}`");

            var tmpLeftResult = new InternalResult();

            ProcessNextNode(node.Left, paramsBinder, ref tmpLeftResult);

            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAndNode pre Right `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}`");

            var tmpRightResult = new InternalResult();

            ProcessNextNode(node.Right, paramsBinder, ref tmpRightResult);

            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAndNode End Processing `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}`");

            /*NLog.LogManager.GetCurrentClassLogger().Info("Begin LeftResult");

            foreach (var tmpRezItem in tmpLeftResult.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{InternalResultItemDebugHelper.ConvertToString(tmpRezItem, mStorageDataDictionary, null)}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End LeftResult");*/
            /*NLog.LogManager.GetCurrentClassLogger().Info("Begin RightResult");

            foreach (var tmpRezItem in tmpRightResult.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{InternalResultItemDebugHelper.ConvertToString(tmpRezItem, mStorageDataDictionary, null)}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End RightResult");*/

            if(_ListHelper.IsEmpty(tmpLeftResult.Items) || _ListHelper.IsEmpty(tmpRightResult.Items))
            {
                return;
            }

            var tmpTargetResult = InternalResult.MergeAsAnd(tmpLeftResult, tmpRightResult);

            /*NLog.LogManager.GetCurrentClassLogger().Info("Begin tmpTargetResult");

            foreach (var tmpRezItem in tmpTargetResult.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{InternalResultItemDebugHelper.ConvertToString(tmpRezItem, mStorageDataDictionary, null)}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End tmpTargetResult");*/

            if(_ListHelper.IsEmpty(tmpTargetResult.Items))
            {
                return;
            }

            result.Items.AddRange(tmpTargetResult.Items);

            //NLog.LogManager.GetCurrentClassLogger().Info("End ProcessAndNode");
        }

        private void ProcessOrNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessOrNode {node.Kind} {node.Key}  partCaler {paramsBinder?.RelationKey}");

            throw new NotImplementedException();
        }

        private void ProcessNotNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNotNode {node.Kind} {node.Key}  partCaler {paramsBinder?.RelationKey}");

            throw new NotImplementedException();
        }

        private void ProcessRelationNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode {node.Kind} `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}` node.Key = {node.Key} partCaler = {paramsBinder?.RelationKey}");

            /*if(paramsBinder != null && paramsBinder.RelationKey == node.Key)
            {
                return ;
            }*/

            var tmpList = mInternalStorageEngine.GetIndex(node.Key);

            foreach(var tmpPart in tmpList)
            {
                if(mExistingsRules.Contains(tmpPart.Parent))
                {
                    continue;
                }

                var tmpBinder = ParamsBinder.FromRelationNode(node, paramsBinder);

                if (tmpPart.Next == null)
                {
                    ProcessFact(tmpPart, tmpBinder, ref result);
                }
                else
                {
                    ProcessRule(tmpPart, tmpBinder, ref result);
                }
            }

            /*NLog.LogManager.GetCurrentClassLogger().Info($"Begin result of `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}`");

            foreach (var tmpRezItem in result.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{InternalResultItemDebugHelper.ConvertToString(tmpRezItem, mStorageDataDictionary, null)}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End result of `{ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary, null)}`");*/
        }

        private void ProcessRule(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRule targetKey = {paramsBinder.RelationKey} `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");

            mExistingsRules.Add(part.Parent);

            if(!BindParams(part.Parent, paramsBinder))
            {
                return;
            }

            var tmpPartResult = new InternalResult();

            ProcessPart(part.Next, paramsBinder, ref tmpPartResult);

            /*NLog.LogManager.GetCurrentClassLogger().Info("Begin PartResult");

            foreach (var tmpRezItem in tmpPartResult.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{InternalResultItemDebugHelper.ConvertToString(tmpRezItem, mStorageDataDictionary, null)}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End PartResult");*/

            //NLog.LogManager.GetCurrentClassLogger().Info($">>>> ProcessRule {paramsBinder}");

            tmpPartResult.Map(paramsBinder.RevertDictionary);

            /*NLog.LogManager.GetCurrentClassLogger().Info($"Begin Maped PartResult of `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");

            foreach (var tmpRezItem in tmpPartResult.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{InternalResultItemDebugHelper.ConvertToString(tmpRezItem, mStorageDataDictionary, null)}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End Maped PartResult of `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");*/

            result.Items.AddRange(tmpPartResult.Items);

            //NLog.LogManager.GetCurrentClassLogger().Info($"End ProcessRule targetKey = {paramsBinder.RelationKey} `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");
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

                paramsBinder.RevertDictionary[tmpCurrBinderParam.Key_Down] = tmpCurrBinderParam.Key_Up;

                if (tmpCurrBinderParam.IsEntity)
                {
                    paramsBinder.VarsWithEntities[tmpCurrBinderParam.Key_Down] = tmpCurrBinderParam.EntityKey;
                }
            }

            return true;
        }

        private void ProcessFact(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            mExistingsRules.Add(part.Parent);

            if(!_ListHelper.IsEmpty(paramsBinder.IndexesParamsWithEntities))
            {
                foreach(var tmpEntityIndex in paramsBinder.IndexesParamsWithEntities)
                {
                    var tmpTargetParam = part.Tree.RelationParams[tmpEntityIndex];
                    var tmpBindedParam = paramsBinder.ParamsList[tmpEntityIndex];

                    if(tmpTargetParam.Key != tmpBindedParam.EntityKey)
                    {
                        return;
                    }
                }           
            }

            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessFact `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");

            var tmpResultItem = new InternalResultItem();
            result.Items.Add(tmpResultItem);

            var tmpBindedParamsIterator = paramsBinder.ParamsList.GetEnumerator();
            var tmpParamsOfFactsIterator = part.Tree.RelationParams.GetEnumerator();

            while(tmpBindedParamsIterator.MoveNext())
            {
                tmpParamsOfFactsIterator.MoveNext();

                var tmpParamResult = new InternalResultParamItem();

                tmpResultItem.ParamsValues.Add(tmpParamResult);

                tmpParamResult.EntityKey = tmpParamsOfFactsIterator.Current.Key;
                tmpParamResult.ParamKey = tmpBindedParamsIterator.Current.Key_Up;
            }

            tmpResultItem.End();
        }

        private void ProcessPart(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPart `{ExpressionNodeDebugHelper.ConvertToString(part.Tree, mStorageDataDictionary, null)}` of rule `{RuleInstanceDebugHelper.ConvertToString(part.Parent, mStorageDataDictionary)}`");

            ProcessTree(part.Tree, paramsBinder, ref result);
        }
    }
}
