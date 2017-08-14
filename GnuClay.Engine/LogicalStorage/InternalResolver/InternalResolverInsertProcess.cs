using GnuClay.CommonClientTypes;
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
    public class InternalResolverInsertProcess: BaseInternalResolver
    {
        public InternalResolverInsertProcess(InsertQuery query, RuleInstance targetItem, GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
            : base(context, logicalContext)
        {
            mTargetItem = targetItem;
            Rewrite = query.Rewrite;
            mCommonLogicalHelper = logicalContext.CommonLogicalHelper;
        }

        private CommonLogicalHelper mCommonLogicalHelper = null;

        private RuleInstance mTargetItem = null;
        private InsertQueryItemStatistics mStatisticItem = null;
        private bool Rewrite = false;

        private Dictionary<ulong, List<RuleInstance>> mExistsStatisticsHashCodes = new Dictionary<ulong, List<RuleInstance>>();

        public void Run()
        {
            GetStatistics();
            ImplementStatistics();
        }

        private void ImplementStatistics()
        {
            var kind = mStatisticItem.Kind;

            switch (kind)
            {
                case InsertQueryItemStatisticsKind.Fact:
                    ProcessRuleOrFact(mStatisticItem);
                    break;

                case InsertQueryItemStatisticsKind.Rule:
                    ProcessRuleOrFact(mStatisticItem);
                    break;

                case InsertQueryItemStatisticsKind.SetInheritence:
                    ProcessSetInheritence(mStatisticItem);
                    break;

                case InsertQueryItemStatisticsKind.RemoveInheritence:
                    ProcessRemoveInheritence(mStatisticItem);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }
        }

        private void ProcessRuleOrFact(InsertQueryItemStatistics statisticsItem)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRuleOrFact statisticsItem = {statisticsItem}");
#endif
            var target = statisticsItem.Target;
            var kind = statisticsItem.Kind;

            var keyOfInstance = target.Key;

            if(keyOfInstance == 0)
            {
                switch (kind)
                {
                    case InsertQueryItemStatisticsKind.Fact:
                        keyOfInstance = mCommonLogicalHelper.GetFactKey();
                        break;

                    case InsertQueryItemStatisticsKind.Rule:
                        keyOfInstance = mCommonLogicalHelper.GetRuleKey();
                        break;
                }

                target.Key = keyOfInstance;
            }

            if(statisticsItem.NeedRewriting)
            {
                mInternalResolverEngine.RemoveFacts(statisticsItem.RewritingQuery);
            }

            mInternalStorageEngine.mRulesAndFactsDict.Add(keyOfInstance, target);

            foreach (var tmpEntity in statisticsItem.Entities)
            {
                mInternalStorageEngine.AddEntity(tmpEntity);
            }

            foreach (var tmpIndexedPartItem in statisticsItem.IndexedPartsDict)
            {
                foreach (var tmpRelation in tmpIndexedPartItem.Value)
                {
                    mInternalStorageEngine.AddPartIndex(tmpRelation, tmpIndexedPartItem.Key);
                }
            }

            mInternalStorageEngine.RegExistsStatisticsHashCode(target);
        }

        private void ProcessSetInheritence(InsertQueryItemStatistics statisticsItem)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence statisticsItem = {statisticsItem}");
#endif
            var tmpItem = statisticsItem.LocalRelationsIndex.First();

            var expression = tmpItem.Value;

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence expression = {expression}");
#endif
            var tmpRelationParams = expression.RelationParams;

            var paramsCount = tmpRelationParams.Count;
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence paramsCount = {paramsCount}");
#endif

            ulong subKey = 0;
            ulong superKey = 0;

            switch (paramsCount)
            {
                case 1:
                    subKey = tmpRelationParams[0].Key;
                    superKey = expression.Key;
                    break;

                case 2:
                    subKey = tmpRelationParams[0].Key;
                    superKey = tmpRelationParams[1].Key;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(paramsCount), paramsCount, null);
            }

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence subKey = {subKey}({mStorageDataDictionary.GetValue(subKey)}) superKey = {superKey}({mStorageDataDictionary.GetValue(superKey)})");
#endif
            Context.InheritanceEngine.SetInheritance(subKey, superKey, 1, InheritanceAspect.WithOutClause);
        }

        private void ProcessRemoveInheritence(InsertQueryItemStatistics statisticsItem)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRemoveInheritence statisticsItem = {statisticsItem}");
#endif
            var tmpItem = statisticsItem.LocalRelationsIndex.First();

            var expression = tmpItem.Value;

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRemoveInheritence expression = {expression}");
#endif
            var tmpRelationParams = expression.RelationParams;

            var paramsCount = tmpRelationParams.Count;
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence paramsCount = {paramsCount}");
#endif
            ulong subKey = 0;
            ulong superKey = 0;

            switch (paramsCount)
            {
                case 1:
                    subKey = tmpRelationParams[0].Key;
                    superKey = expression.Key;
                    break;

                case 2:
                    subKey = tmpRelationParams[0].Key;
                    superKey = tmpRelationParams[1].Key;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(paramsCount), paramsCount, null);
            }

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRemoveInheritence subKey = {subKey}({mStorageDataDictionary.GetValue(subKey)}) superKey = {superKey}({mStorageDataDictionary.GetValue(superKey)})");
#endif
            Context.InheritanceEngine.SetInheritance(subKey, superKey, 0, InheritanceAspect.WithOutClause);
        }

        private void GetStatistics()
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetStatistics mTargetItem = `{RuleInstanceDebugHelper.ConvertToString(mTargetItem, Context.DataDictionary)}`");
#endif
            mStatisticItem = new InsertQueryItemStatistics();

            mStatisticItem.Target = mTargetItem;

            mTargetItem.CalculateHashCode();

            CheckUnique(mTargetItem);

            AnalyzingTreeNode(mTargetItem.Part_1.Tree, mTargetItem.Part_1, mStatisticItem);

            if (mTargetItem.Part_2 == null)
            {
                mStatisticItem.Kind = InsertQueryItemStatisticsKind.Fact;
                ValidateFact(mStatisticItem);

                if(Rewrite)
                {
                    mStatisticItem.NeedRewriting = true;
                    mStatisticItem.RewritingQuery = mASTTransformer.GetRewritingQuery(mTargetItem);
                }
            }
            else{
                mStatisticItem.Kind = InsertQueryItemStatisticsKind.Rule;
                AnalyzingTreeNode(mTargetItem.Part_2.Tree, mTargetItem.Part_2, mStatisticItem);
                ValidateRule(mStatisticItem);
            }

            mTargetItem.VarsCount = mStatisticItem.VarsCount;
            mTargetItem.LocalRelationsIndex = mStatisticItem.LocalRelationsIndex;

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetStatistics mStatisticItem = {mStatisticItem}");
#endif
        }

        private void CheckUnique(RuleInstance targetItem)
        {
            var hasheCode = targetItem.GetLongHashCode();

            if (mExistsStatisticsHashCodes.ContainsKey(hasheCode))
            {
                throw new NotImplementedException($"Duplicated rule or fact `{RuleInstanceDebugHelper.ConvertToString(targetItem, mStorageDataDictionary)}`. Processing collision does not implemented yet");
            }

            RegExistsStatisticsHashCode(targetItem);

            if(mInternalStorageEngine.mLongHasheCodeRulesAndFactsDict.ContainsKey(hasheCode))
            {
#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"CheckUnique (1) `{RuleInstanceDebugHelper.ConvertToString(targetItem, mStorageDataDictionary)}`");
#endif
                var existsItemsList = mInternalStorageEngine.mLongHasheCodeRulesAndFactsDict[hasheCode];

                foreach (var existsItem in existsItemsList)
                {
#if DEBUG
                    //NLog.LogManager.GetCurrentClassLogger().Info($"CheckUnique (2) `{RuleInstanceDebugHelper.ConvertToString(existsItem, mStorageDataDictionary)}`");
#endif
                    if (targetItem.IsEquals(existsItem))
                    {
                        throw new NotImplementedException($"Duplicated rule or fact `{RuleInstanceDebugHelper.ConvertToString(targetItem, mStorageDataDictionary)}`. Processing collision does not implemented yet");
                    }
                }             
            }
        }

        private void RegExistsStatisticsHashCode(RuleInstance targetItem)
        {
            List<RuleInstance> tmpList = null;

            var hasheCode = targetItem.GetLongHashCode();

            if (mExistsStatisticsHashCodes.ContainsKey(hasheCode))
            {
                tmpList = mExistsStatisticsHashCodes[hasheCode];
            }
            else
            {
                tmpList = new List<RuleInstance>();

                mExistsStatisticsHashCodes.Add(hasheCode, tmpList);
            }

            tmpList.Add(targetItem);
        }

        private void ValidateRule(InsertQueryItemStatistics context)
        {
            if(context.Vars.Count == 0)
            {
                throw new RuleException($"The rule `{RuleInstanceDebugHelper.ConvertToString(context.Target, mStorageDataDictionary)}` must contain one or more variables");
            }
        }

        private void ValidateFact(InsertQueryItemStatistics context)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact context = {context}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact context.LocalRelationsIndex.Count = {context.LocalRelationsIndex.Count}");
#endif
            switch (context.IndexedPartsDict.Count)
            {
                case 1:
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(context.LocalRelationsIndex.Count), context.LocalRelationsIndex.Count.ToString());
            }

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact Next");
#endif
            var tmpItem = context.LocalRelationsIndex.First();
            var tmpKey = tmpItem.Key;
            var paramsCount = tmpItem.Value.RelationParams.Count;

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact tmpParamsCount = {paramsCount}");
#endif
            switch (paramsCount)
            {
                case 1:
#if DEBUG
                    //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact case 1 ProcessInheritese!!!!!!");
#endif
                    if (context.IsNot)
                    {
                        context.Kind = InsertQueryItemStatisticsKind.RemoveInheritence;
                        return;
                    }

                    context.Kind = InsertQueryItemStatisticsKind.SetInheritence;
                    return;

                case 2:
                    if (tmpKey == IsKey)
                    {
#if DEBUG
                        //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact case 2 ProcessInheritese!!!!!!");
#endif
                        if (context.IsNot)
                        {
                            context.Kind = InsertQueryItemStatisticsKind.RemoveInheritence;
                        }
                        else
                        {
                            context.Kind = InsertQueryItemStatisticsKind.SetInheritence;
                        }
                        return;
                    }

                    if (context.IsNot)
                    {
                        context.Kind = InsertQueryItemStatisticsKind.RemoveFact;
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(paramsCount), paramsCount.ToString());
            }
        }

        private void AnalyzingTreeNode(ExpressionNode node, RulePart part, InsertQueryItemStatistics context)
        {
            switch (node.Kind)
            {
                case ExpressionNodeKind.And:
                    AnalyzingAndNode(node, part, context);
                    break;

                case ExpressionNodeKind.Or:
                    AnalyzingOrNode(node, part, context);
                    break;

                case ExpressionNodeKind.Not:
                    AnalyzingNotNode(node, part, context);
                    break;

                case ExpressionNodeKind.Relation:
                    AnalyzingRelationNode(node, part, context);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(node.Kind), node.Kind.ToString());
            }
        }

        private void AnalyzingAndNode(ExpressionNode node, RulePart part, InsertQueryItemStatistics context)
        {
            AnalyzingTreeNode(node.Left, part, context);
            AnalyzingTreeNode(node.Right, part, context);
        }

        private void AnalyzingOrNode(ExpressionNode node, RulePart part, InsertQueryItemStatistics context)
        {
            AnalyzingTreeNode(node.Left, part, context);
            AnalyzingTreeNode(node.Right, part, context);
        }

        private void AnalyzingNotNode(ExpressionNode node, RulePart part, InsertQueryItemStatistics context)
        {
            context.IsNot = true;
            AnalyzingTreeNode(node.Left, part, context);
        }

        private void AnalyzingRelationNode(ExpressionNode node, RulePart part, InsertQueryItemStatistics context)
        {
            context.RegIndex(part, node);

            foreach (var tmpParam in node.RelationParams)
            {
                if (tmpParam.Kind == ExpressionNodeKind.Entity)
                {
                    context.RegEntity(tmpParam.Key);

                    continue;
                }

                context.RegVar(tmpParam.Key);
            }
        }
    }
}
