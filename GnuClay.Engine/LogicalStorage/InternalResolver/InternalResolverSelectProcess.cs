﻿using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InternalResolverSelectProcess: BaseInternalResolver
    {
        public InternalResolverSelectProcess(SelectQuery query, InternalStorageEngine engine, GnuClayEngineComponentContext context)
            : base(engine, context)
        {
            mInheritanceEngine = mContext.InheritanceEngine;

            mSelectQuery = query;

            //NLog.LogManager.GetCurrentClassLogger().Info($"mSelectQuery = {SelectQueryDebugHelper.ConvertToString(mSelectQuery, context.DataDictionary)}");

            //NLog.LogManager.GetCurrentClassLogger().Info($"mSelectQuery = {mSelectQuery}");
        }

        private InheritanceEngine mInheritanceEngine = null;

        private SelectQuery mSelectQuery = null;

        private List<RuleInstance> mExistingsRules = new List<RuleInstance>();
        private List<ulong> mVariablesKeys = new List<ulong>();

        private Dictionary<ulong, List<ExpressionNode>> mModifyEntityKeyExpressionNodeDict = new Dictionary<ulong, List<ExpressionNode>>();
        private Dictionary<ulong, ulong> mVarKeyEntityKeyDict = new Dictionary<ulong, ulong>();
        private Dictionary<ulong, List<InheritanceItem>> mEntityKeyInheritanceDict = new Dictionary<ulong, List<InheritanceItem>>();

        public SelectResult Run()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"Run pre {ExpressionNodeDebugHelper.ConvertToString(mSelectQuery.SelectedTree, mStorageDataDictionary)}");

            ModifySelectTree();

            var tmpParamBinder = new ParamsBinder();

            tmpParamBinder.IsRoot = true;

            var tmpInternalResult = new InternalResult();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Run {ExpressionNodeDebugHelper.ConvertToString(mSelectQuery.SelectedTree, mStorageDataDictionary)}");

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

            tmpResult.HaveBeenFound = true;

            NLog.LogManager.GetCurrentClassLogger().Info($"CreateResult mVariablesKeys = {mVariablesKeys.ToJson()}");

            foreach (var tmpRezItem in result.Items)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"CreateResult tmpRezItem = {tmpRezItem}");

                var tmpValuesDict = tmpRezItem.ParamsValues.ToDictionary(p => p.EntityKey, p => p);

                var tmpSelectResultItem = new SelectResultItem();

                tmpResult.Items.Add(tmpSelectResultItem);

                if(mVariablesKeys.Count == 0)
                {
                    continue;
                }

                foreach(var varKey in mVariablesKeys)
                {
                    var targetValue = tmpRezItem.ParamsDict[varKey];

                    var targetItem = tmpValuesDict[targetValue];

                    NLog.LogManager.GetCurrentClassLogger().Info($"CreateResult targetItem = {targetItem}");

                    var tmpParamItem = new VarResultItem();

                    tmpSelectResultItem.Params.Add(tmpParamItem);

                    tmpParamItem.ParamKey = varKey;
                    tmpParamItem.EntityKey = targetValue;
                    tmpParamItem.Kind = targetItem.Kind;

                    switch (targetItem.Kind)
                    {
                        case ExpressionNodeKind.Value:
                            tmpParamItem.Value = targetItem.Value;
                            break;

                        case ExpressionNodeKind.Entity:
                            break;

                        default: throw new ArgumentOutOfRangeException(nameof(targetItem.Kind), targetItem.Kind.ToString());
                    }
                }
            }

            return tmpResult;
        }

        private void ModifySelectTree()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ModifySelectTree mSelectQuery.SelectedTree = {mSelectQuery.SelectedTree}");

            ModifySelectedTreeNode(mSelectQuery.SelectedTree);

            ulong tmpN = 0;

            NLog.LogManager.GetCurrentClassLogger().Info($"ModifySelectTree pre mModifyEntityKeyExpressionNodeDict = {mModifyEntityKeyExpressionNodeDict.ToJson()}");

            foreach (var tmpItem in mModifyEntityKeyExpressionNodeDict)
            {
                tmpN++;
                var tmpEntityKey = tmpItem.Key;
                mVarKeyEntityKeyDict[tmpN] = tmpEntityKey;

                foreach (var tmpParam in tmpItem.Value)
                {
                    tmpParam.Key = tmpN;
                }

                if(mEntityKeyInheritanceDict.ContainsKey(tmpEntityKey))
                {
                    continue;
                }

                var tmpInheritenceList = mInheritanceEngine.LoadListOfInheritance(tmpEntityKey);

                mEntityKeyInheritanceDict[tmpEntityKey] = tmpInheritenceList;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ModifySelectTree post mModifyEntityKeyExpressionNodeDict = {mModifyEntityKeyExpressionNodeDict.ToJson()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ModifySelectTree mVarKeyEntityKeyDict = {mVarKeyEntityKeyDict.ToJson()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ModifySelectTree mEntityKeyInheritanceDict = {mEntityKeyInheritanceDict.ToJson()}");
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

                default: throw new ArgumentOutOfRangeException(nameof(node.Kind), node.Kind.ToString());
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

                    continue;
                }

                if(tmpParam.Kind == ExpressionNodeKind.Var)
                {
                    mVariablesKeys.Add(tmpParam.Key);
                }
                /*else
                {
                    if(tmpParam.Key > mMaxVarCount)
                    {
                        mMaxVarCount = tmpParam.Key; 
                    }
                }*/
            }
        }

        private void ProcessTree(ExpressionNode rootNode, ParamsBinder paramsBinder, ref InternalResult result)
        {
            ProcessNextNode(rootNode, paramsBinder, ref result);
        }

        private void ProcessNextNode(ExpressionNode node, ParamsBinder paramsBinder, ref InternalResult result)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode {ExpressionNodeDebugHelper.ConvertToString(node, mStorageDataDictionary)}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNextNode node = {node}");

            switch (node.Kind)
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
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode node = {node} (`{mStorageDataDictionary.GetValue(node.Key)}`)");

            var tmpList = mInternalStorageEngine.GetIndex(node.Key);

            Dictionary<ulong, ulong> KEMap = null;

            if(paramsBinder.IsRoot)
            {
                KEMap = mVarKeyEntityKeyDict;

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode KEMap = {KEMap.ToJson()}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode tmpList.Count = {tmpList.Count}");

            foreach (var tmpPart in tmpList)
            {
                if(mExistingsRules.Contains(tmpPart.Parent))
                {
                    continue;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode tmpPart.Parent {RuleInstanceDebugHelper.ConvertToString(tmpPart.Parent, mStorageDataDictionary)}");

                var tmpBinder = ParamsBinder.FromRelationNode(node, paramsBinder, KEMap);

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRelationNode tmpBinder = {tmpBinder}");

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
            if(ruleInstance.VarsCount > (ulong)paramsBinder.ParamsList.Count)
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
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessFact {ExpressionNodeDebugHelper.ConvertToString(part.Tree, mStorageDataDictionary)}");

            mExistingsRules.Add(part.Parent);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessFact part.Tree.RelationParams.Count = {part.Tree.RelationParams.Count}");

            var countRelationParamsOfFact = part.Tree.RelationParams.Count;

            switch (countRelationParamsOfFact)
            {
                case 2:
                    ProcessTwoParamsFact(part, paramsBinder, ref result);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(countRelationParamsOfFact), countRelationParamsOfFact.ToString());
            }
        }

        private void ProcessTwoParamsFact(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTwoParamsFact {ExpressionNodeDebugHelper.ConvertToString(part.Tree, mStorageDataDictionary)}");

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTwoParamsFact part.Tree = {part.Tree}");

            var tmpRelationKey = part.Tree.Key;

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTwoParamsFact tmpRelationKey = {tmpRelationKey}");

            if(tmpRelationKey == IsKey)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessTwoParamsFact tmpRelationKey == IsKey");
                throw new NotImplementedException();
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessTwoParamsFact NEXT");

            var tmpFirstParam = paramsBinder.ParamsList.First();

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTwoParamsFact tmpFirstParam = {tmpFirstParam}");

            if (tmpFirstParam.IsEntity)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessTwoParamsFact tmpFirstParam.IsEntity");

                var tmpOriginalEntityKey = tmpFirstParam.EntityKey;

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTwoParamsFact tmpOriginalEntityKey = {tmpOriginalEntityKey} ({mStorageDataDictionary.GetValue(tmpOriginalEntityKey)})");

                NProcessTwoParamsFact(part, paramsBinder, ref result, tmpOriginalEntityKey, tmpOriginalEntityKey);

                var tmpInheritaceList = mEntityKeyInheritanceDict[tmpOriginalEntityKey];

                foreach(var inheritanceItem in tmpInheritaceList)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"ProcessTwoParamsFact inheritanceItem = {inheritanceItem.ToJson()}");

                    tmpFirstParam.EntityKey = inheritanceItem.Key;

                    NProcessTwoParamsFact(part, paramsBinder, ref result, tmpOriginalEntityKey, inheritanceItem.Key);
                }
            }
            else
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessTwoParamsFact NOT tmpFirstParam.IsEntity");
                throw new NotImplementedException();
            }
        }

        private void NProcessTwoParamsFact(RulePart part, ParamsBinder paramsBinder, ref InternalResult result, ulong originalKey, ulong superKey)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"NProcessTwoParamsFact `{ExpressionNodeDebugHelper.ConvertToString(part.Tree, mStorageDataDictionary)}` originalKey = {originalKey} superKey = {superKey}");

            NLog.LogManager.GetCurrentClassLogger().Info($"NProcessTwoParamsFact paramsBinder = {paramsBinder.ToJson()}");

            if (!_ListHelper.IsEmpty(paramsBinder.IndexesParamsWithEntities))
            {
                foreach (var tmpEntityIndex in paramsBinder.IndexesParamsWithEntities)
                {
                    var tmpTargetParam = part.Tree.RelationParams[tmpEntityIndex];
                    var tmpBindedParam = paramsBinder.ParamsList[tmpEntityIndex];

                    if (tmpTargetParam.Key != tmpBindedParam.EntityKey)
                    {
                        return;
                    }
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info("NProcessTwoParamsFact NEXT");

            var tmpResultItem = new InternalResultItem();
            result.Items.Add(tmpResultItem);

            var tmpBindedParamsIterator = paramsBinder.ParamsList.GetEnumerator();
            var tmpParamsOfFactsIterator = part.Tree.RelationParams.GetEnumerator();

            var n = 0;

            while (tmpBindedParamsIterator.MoveNext())
            {
                n++;

                tmpParamsOfFactsIterator.MoveNext();

                var tmpParamResult = new InternalResultParamItem();

                tmpResultItem.ParamsValues.Add(tmpParamResult);

                var currentParamOfFacts = tmpParamsOfFactsIterator.Current;

                NLog.LogManager.GetCurrentClassLogger().Info($"NProcessTwoParamsFact n = {n}");
                NLog.LogManager.GetCurrentClassLogger().Info($"NProcessTwoParamsFact tmpBindedParamsIterator.Current.Key_Up = {tmpBindedParamsIterator.Current.Key_Up} currentParamOfFacts = {currentParamOfFacts}");

                if(n == 1 && currentParamOfFacts.Kind == ExpressionNodeKind.Entity)
                {
                    tmpParamResult.EntityKey = originalKey;
                }
                else
                {
                    tmpParamResult.EntityKey = currentParamOfFacts.Key;
                }
                
                tmpParamResult.ParamKey = tmpBindedParamsIterator.Current.Key_Up;
                tmpParamResult.Kind = currentParamOfFacts.Kind;

                switch (tmpParamResult.Kind)
                {
                    case ExpressionNodeKind.Entity:
                        break;

                    case ExpressionNodeKind.Value:
                        tmpParamResult.Value = currentParamOfFacts.Value;
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(tmpParamResult.Kind), tmpParamResult.Kind.ToString());
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"NProcessTwoParamsFact tmpParamResult = {tmpParamResult}");
            }

            tmpResultItem.End();
        }

        private void ProcessPart(RulePart part, ParamsBinder paramsBinder, ref InternalResult result)
        {
            ProcessTree(part.Tree, paramsBinder, ref result);
        }
    }
}
