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
        public InternalResolverInsertProcess(InsertQuery query, InternalStorageEngine engine, GnuClayEngineComponentContext context)
            : base(engine, context)
        {
            mInsertQuery = query;
        }

        private InsertQuery mInsertQuery = null;

        private List<InsertQueryItemStatistics> mStatisticsList = new List<InsertQueryItemStatistics>();
        private Dictionary<ulong, List<RuleInstance>> mExistsStatisticsHashCodes = new Dictionary<ulong, List<RuleInstance>>();

        public void Run()
        {
            if(_ListHelper.IsEmpty(mInsertQuery.Items))
            {
                throw new NullReferenceException("Query is not contain inserting items.");
            }

            FillStatistics();

            ImplementStatistics();
        }

        private void FillStatistics()
        {
            foreach(var tmpItem in mInsertQuery.Items)
            {
                GetStatistics(tmpItem);
            }
        }

        private void ImplementStatistics()
        {
            foreach (var statisticsItem in mStatisticsList)
            {
                //NLog.LogManager.GetCurrentClassLogger().Info($"ImplementStatistics statisticsItem = {statisticsItem}");

                switch(statisticsItem.Kind)
                {
                    case InsertQueryItemStatisticsKind.Fact:
                        ProcessRuleOrFact(statisticsItem);
                        break;

                    case InsertQueryItemStatisticsKind.Rule:
                        ProcessRuleOrFact(statisticsItem);
                        break;

                    case InsertQueryItemStatisticsKind.SetInheritence:
                        ProcessSetInheritence(statisticsItem);
                        break;

                    case InsertQueryItemStatisticsKind.RemoveInheritence:
                        ProcessRemoveInheritence(statisticsItem);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(statisticsItem.Kind), statisticsItem.Kind.ToString());
                }
            }
        }

        private void ProcessRuleOrFact(InsertQueryItemStatistics statisticsItem)
        {
            mInternalStorageEngine.mRulesAndFactsList.Add(statisticsItem.Target);

            foreach (var tmpEntity in statisticsItem.Entities)
            {
                mInternalStorageEngine.AddEntity(tmpEntity);
            }

            foreach (var tmpIndexedPartItem in statisticsItem.IndexedPartsDict)
            {
                foreach (var tmpRelation in tmpIndexedPartItem.Value)
                {
                    mInternalStorageEngine.AddIndex(tmpRelation, tmpIndexedPartItem.Key);
                }
            }

            mInternalStorageEngine.RegExistsStatisticsHashCode(statisticsItem.Target);
        }

        private void ProcessSetInheritence(InsertQueryItemStatistics statisticsItem)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence statisticsItem = {statisticsItem}");

            var tmpItem = statisticsItem.LocalRelationsIndex.First();

            var expression = tmpItem.Value;

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence expression = {expression}");

            var tmpRelationParams = expression.RelationParams;

            var paramsCount = tmpRelationParams.Count;

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence paramsCount = {paramsCount}");

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

                default: throw new ArgumentOutOfRangeException(nameof(paramsCount), paramsCount.ToString());
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence subKey = {subKey}({mStorageDataDictionary.GetValue(subKey)}) superKey = {superKey}({mStorageDataDictionary.GetValue(superKey)})");

            mContext.InheritanceEngine.SetInheritance(subKey, superKey, 1, InheritanceAspect.WithOutClause);
        }

        private void ProcessRemoveInheritence(InsertQueryItemStatistics statisticsItem)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRemoveInheritence statisticsItem = {statisticsItem}");

            var tmpItem = statisticsItem.LocalRelationsIndex.First();

            var expression = tmpItem.Value;

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRemoveInheritence expression = {expression}");

            var tmpRelationParams = expression.RelationParams;

            var paramsCount = tmpRelationParams.Count;

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSetInheritence paramsCount = {paramsCount}");

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

                default: throw new ArgumentOutOfRangeException(nameof(paramsCount), paramsCount.ToString());
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRemoveInheritence subKey = {subKey}({mStorageDataDictionary.GetValue(subKey)}) superKey = {superKey}({mStorageDataDictionary.GetValue(superKey)})");

            mContext.InheritanceEngine.SetInheritance(subKey, superKey, 0, InheritanceAspect.WithOutClause);
        }

        private void GetStatistics(RuleInstance targetItem)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetStatistics targetItem = `{RuleInstanceDebugHelper.ConvertToString(targetItem, mContext.DataDictionary)}`");

            var tmpStatistics = new InsertQueryItemStatistics();
            
            tmpStatistics.Target = targetItem;

            targetItem.CalculateHashCode();

            CheckUnique(targetItem);

            AnalyzingTreeNode(targetItem.Part_1.Tree, targetItem.Part_1, tmpStatistics);

            if (targetItem.Part_2 == null)
            {
                tmpStatistics.Kind = InsertQueryItemStatisticsKind.Fact;

                ValidateFact(tmpStatistics);
            }else{
                tmpStatistics.Kind = InsertQueryItemStatisticsKind.Rule;

                AnalyzingTreeNode(targetItem.Part_2.Tree, targetItem.Part_2, tmpStatistics);

                ValidateRule(tmpStatistics);
            }

            targetItem.VarsCount = tmpStatistics.VarsCount;
            targetItem.LocalRelationsIndex = tmpStatistics.LocalRelationsIndex;

            //NLog.LogManager.GetCurrentClassLogger().Info($"GetStatistics tmpStatistics = {tmpStatistics}");

            mStatisticsList.Add(tmpStatistics);
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
                throw new NotImplementedException($"Duplicated rule or fact `{RuleInstanceDebugHelper.ConvertToString(targetItem, mStorageDataDictionary)}`. Processing collision does not implemented yet");
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
            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact context = {context}");

            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact context.LocalRelationsIndex.Count = {context.LocalRelationsIndex.Count}");

            switch(context.IndexedPartsDict.Count)
            {
                case 1:
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(context.LocalRelationsIndex.Count), context.LocalRelationsIndex.Count.ToString());
            }

            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact Next");

            var tmpItem = context.LocalRelationsIndex.First();
            var tmpKey = tmpItem.Key;
            var paramsCount = tmpItem.Value.RelationParams.Count;

            NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact tmpParamsCount = {paramsCount}");

            switch(paramsCount)
            {
                case 1:
                    NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact case 1 ProcessInheritese!!!!!!");
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
                        NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact case 2 ProcessInheritese!!!!!!");
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
