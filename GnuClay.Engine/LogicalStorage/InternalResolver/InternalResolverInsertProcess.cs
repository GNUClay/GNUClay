using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InternalResolverInsertProcess
    {
        public InternalResolverInsertProcess(InsertQuery query, InternalStorageEngine engine, GnuClayEngineComponentContext context)
        {
            mInsertQuery = query;
            mInternalStorageEngine = engine;
            mStorageDataDictionary = context.DataDictionary;
        }

        private InsertQuery mInsertQuery = null;
        private InternalStorageEngine mInternalStorageEngine = null;
        private StorageDataDictionary mStorageDataDictionary = null;

        private List<InsertQueryItemStatistics> mStatisticsList = new List<InsertQueryItemStatistics>();
        private Dictionary<long, List<RuleInstance>> mExistsStatisticsHashCodes = new Dictionary<long, List<RuleInstance>>();

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
            foreach (var tmpStatisticsItem in mStatisticsList)
            {
                mInternalStorageEngine.mRulesAndFactsList.Add(tmpStatisticsItem.Target);

                foreach (var tmpEntity in tmpStatisticsItem.Entities)
                {
                    mInternalStorageEngine.AddEntity(tmpEntity);
                }

                foreach(var tmpIndexedPartItem in tmpStatisticsItem.IndexedPartsDict)
                {
                    foreach(var tmpRelation in tmpIndexedPartItem.Value)
                    {
                        mInternalStorageEngine.AddIndex(tmpRelation, tmpIndexedPartItem.Key);
                    }
                }

                mInternalStorageEngine.RegExistsStatisticsHashCode(tmpStatisticsItem.Target);
            }
        }

        private void GetStatistics(RuleInstance targetItem)
        {
            var tmpStatistics = new InsertQueryItemStatistics();
            
            tmpStatistics.Target = targetItem;

            targetItem.CalculateHashCode();

            CheckUnique(targetItem);

            AnalyzingTreeNode(targetItem.Part_1.Tree, targetItem.Part_1, tmpStatistics);

            if (targetItem.Part_2 == null)
            {
                tmpStatistics.IsRule = false;

                ValidateFact(tmpStatistics);
            }else{ 
                tmpStatistics.IsRule = true;

                AnalyzingTreeNode(targetItem.Part_2.Tree, targetItem.Part_2, tmpStatistics);

                ValidateRule(tmpStatistics);
            }

            targetItem.VarsCount = tmpStatistics.VarsCount;
            targetItem.LocalRelationsIndex = tmpStatistics.LocalRelationsIndex;

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

                default: throw new ArgumentOutOfRangeException();
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
