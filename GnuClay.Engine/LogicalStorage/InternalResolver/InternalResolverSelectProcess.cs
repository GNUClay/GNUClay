using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
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
        public InternalResolverSelectProcess(SelectQuery query, InternalStorageEngine engine, GnuClayEngineComponentContext context)
        {
            mSelectQuery = query;
            mInternalStorageEngine = engine;
            mStorageDataDictionary = context.DataDictionary;
        }

        private SelectQuery mSelectQuery = null;
        private InternalStorageEngine mInternalStorageEngine = null;
        private StorageDataDictionary mStorageDataDictionary = null;
        private List<RuleInstance> mExistingsRules = new List<RuleInstance>();
        private List<int> mVariablesKeys = new List<int>();

        private Dictionary<int, List<ExpressionNode>> mModifyEntityKeyExpressionNodeDict = new Dictionary<int, List<ExpressionNode>>();
        private Dictionary<int, int> mVarKeyEntityKeyDict = new Dictionary<int, int>();
        private int mMaxVarCount = 0;

        public SelectResult Run()
        {
            ModifySelectTree();

            var tmpParamBinder = new ParamsBinder();

            tmpParamBinder.IsRoot = true;

            var tmpInternalResult = new InternalResult();

            ProcessTree(mSelectQuery.SelectedTree, tmpParamBinder, ref tmpInternalResult);

            var tmpResult = CreateResult(tmpInternalResult);

            return tmpResult;
        }

        private SelectResult CreateResult(InternalResult result)
        {
            var tmpResult = new SelectResult();

            if(result.Items.Count == 0)
            {
                return tmpResult;
            }

            tmpResult.Success = true;

            foreach (var tmpRezItem in result.Items)
            {
                var tmpSelectResultItem = new SelectResultItem();

                tmpResult.Items.Add(tmpSelectResultItem);

                if(mVariablesKeys.Count == 0)
                {
                    continue;
                }

                foreach(var varKey in mVariablesKeys)
                {
                    var targetValue = tmpRezItem.ParamsDict[varKey];

                    var tmpParamItem = new VarResultItem();

                    tmpSelectResultItem.Params.Add(tmpParamItem);

                    tmpParamItem.ParamKey = varKey;
                    tmpParamItem.EntityKey = targetValue;
                }
            }

            return tmpResult;
        }

        private void ModifySelectTree()
        {
            ModifySelectedTreeNode(mSelectQuery.SelectedTree);

            var tmpN = mMaxVarCount;

            foreach (var tmpItem in mModifyEntityKeyExpressionNodeDict)
            {
                tmpN++;
                mVarKeyEntityKeyDict[tmpN] = tmpItem.Key;

                foreach (var tmpParam in tmpItem.Value)
                {
                    tmpParam.Key = tmpN;
                }
            }

            if(mMaxVarCount > 0)
            {
                for (var n = 1; n <= mMaxVarCount; n++)
                {
                    mVariablesKeys.Add(n);
                }
            }
        }

        private void ModifySelectedTreeNode(ExpressionNode node)
        {
            switch (node.Kind)
            {
                case ExpressionNodeKind.And:
                    ModifySelectedAndNode(node);
                    break;

                case ExpressionNodeKind.Or:
                    ModifySelectedOrNode(node);
                    break;

                case ExpressionNodeKind.Not:
                    ModifySelectedNotNode(node);
                    break;

                case ExpressionNodeKind.Relation:
                    ModifySelectedRelationNode(node);
                    break;

                default: throw new ArgumentOutOfRangeException();
            }
        }

        private void ModifySelectedAndNode(ExpressionNode node)
        {
            ModifySelectedTreeNode(node.Left);
            ModifySelectedTreeNode(node.Right);
        }

        private void ModifySelectedOrNode(ExpressionNode node)
        {
            ModifySelectedTreeNode(node.Left);
            ModifySelectedTreeNode(node.Right);
        }

        private void ModifySelectedNotNode(ExpressionNode node)
        {
            ModifySelectedTreeNode(node.Left);
        }

        private void ModifySelectedRelationNode(ExpressionNode node)
        {
            foreach(var tmpParam in node.RelationParams)
            {
                if(tmpParam.Kind == ExpressionNodeKind.Entity)
                {
                    List<ExpressionNode> tmpList = null;

                    if (mModifyEntityKeyExpressionNodeDict.ContainsKey(tmpParam.Key))
                    {
                        tmpList = mModifyEntityKeyExpressionNodeDict[tmpParam.Key];
                    }
                    else
                    {
                        tmpList = new List<ExpressionNode>();

                        mModifyEntityKeyExpressionNodeDict.Add(tmpParam.Key, tmpList);
                    }

                    tmpList.Add(tmpParam);
                }
                else
                {
                    if(tmpParam.Key > mMaxVarCount)
                    {
                        mMaxVarCount = tmpParam.Key; 
                    }
                }
            }
        }

        private void ProcessTree(ExpressionNode rootNode, ParamsBinder paramsBinder, ref InternalResult result)
        {
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
            var tmpLeftResult = new InternalResult();

            ProcessNextNode(node.Left, paramsBinder, ref tmpLeftResult);

            var tmpRightResult = new InternalResult();

            ProcessNextNode(node.Right, paramsBinder, ref tmpRightResult);

            if(_ListHelper.IsEmpty(tmpLeftResult.Items) || _ListHelper.IsEmpty(tmpRightResult.Items))
            {
                return;
            }

            var tmpTargetResult = InternalResult.MergeAsAnd(tmpLeftResult, tmpRightResult);

            if(_ListHelper.IsEmpty(tmpTargetResult.Items))
            {
                return;
            }

            result.Items.AddRange(tmpTargetResult.Items);
        }

        private void ProcessOrNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            throw new NotImplementedException();
        }

        private void ProcessNotNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            throw new NotImplementedException();
        }

        private void ProcessRelationNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            var tmpList = mInternalStorageEngine.GetIndex(node.Key);

            Dictionary<int, int> KEMap = null;

            if(paramsBinder.IsRoot)
            {
                KEMap = mVarKeyEntityKeyDict;
            }

            foreach(var tmpPart in tmpList)
            {
                if(mExistingsRules.Contains(tmpPart.Parent))
                {
                    continue;
                }

                var tmpBinder = ParamsBinder.FromRelationNode(node, paramsBinder, KEMap);

                if (tmpPart.Next == null)
                {
                    ProcessFact(tmpPart, tmpBinder, ref result);
                }
                else
                {
                    ProcessRule(tmpPart, tmpBinder, ref result);
                }
            }
        }

        private void ProcessRule(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            mExistingsRules.Add(part.Parent);

            if(!BindParams(part.Parent, paramsBinder))
            {
                return;
            }

            var tmpPartResult = new InternalResult();

            ProcessPart(part.Next, paramsBinder, ref tmpPartResult);

            tmpPartResult.Map(paramsBinder.RevertDictionary);

            result.Items.AddRange(tmpPartResult.Items);
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
            ProcessTree(part.Tree, paramsBinder, ref result);
        }
    }
}
