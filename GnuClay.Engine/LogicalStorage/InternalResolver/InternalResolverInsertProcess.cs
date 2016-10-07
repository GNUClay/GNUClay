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
    public class InternalResolverInsertProcess
    {
        public InternalResolverInsertProcess(InsertQuery query, InternalStorageEngine engine, StorageDataDictionary dataDictionary)
        {
            mInsertQuery = query;
            mInternalStorageEngine = engine;
            mStorageDataDictionary = dataDictionary;
        }

        private InsertQuery mInsertQuery = null;
        private InternalStorageEngine mInternalStorageEngine = null;
        private StorageDataDictionary mStorageDataDictionary = null;

        private List<InsertQueryItemStatistics> mStatisticsList = new List<InsertQueryItemStatistics>();

        public void Run()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("Run");

            if(_ListHelper.IsEmpty(mInsertQuery.Items))
            {
                throw new NullReferenceException("Query is not contain inserting items.");
            }

            FillStatistics();

            ImplementStatistics();

            //NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private void FillStatistics()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("FillStatistics");

            foreach(var tmpItem in mInsertQuery.Items)
            {
                GetStatistics(tmpItem);
            }

            //NLog.LogManager.GetCurrentClassLogger().Info(_ListHelper._ToString(mStatisticsList, nameof(mStatisticsList)));

            //NLog.LogManager.GetCurrentClassLogger().Info("End FillStatistics");
        }

        private void ImplementStatistics()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("ImplementStatistics");

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
            }

            //NLog.LogManager.GetCurrentClassLogger().Info("End ImplementStatistics");
        }

        private void GetStatistics(RuleInstance targetItem)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetStatistics `{RuleInstanceDebugHelper.ConvertToString(targetItem, mStorageDataDictionary)}`");

            var tmpStatistics = new InsertQueryItemStatistics();
            mStatisticsList.Add(tmpStatistics);

            tmpStatistics.Target = targetItem;

            targetItem.CalculateHashCode();

            AnalyzingTreeNode(targetItem.Part_1.Tree, targetItem.Part_1, tmpStatistics);

            if (targetItem.Part_2 == null)
            {
                tmpStatistics.IsRule = false;

                ValidateFact(tmpStatistics);
            }else{ 
                //NLog.LogManager.GetCurrentClassLogger().Info($"GetStatistics begin part 2`{RuleInstanceDebugHelper.ConvertToString(targetItem, mStorageDataDictionary)}`");

                tmpStatistics.IsRule = true;

                AnalyzingTreeNode(targetItem.Part_2.Tree, targetItem.Part_2, tmpStatistics);

                ValidateRule(tmpStatistics);
            }

            targetItem.VarsCount = tmpStatistics.VarsCount;
            targetItem.LocalRelationsIndex = tmpStatistics.LocalRelationsIndex;

            //NLog.LogManager.GetCurrentClassLogger().Info($"tmpStatistics = {tmpStatistics}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"targetItem.GetHashCode() = {targetItem.GetHashCode()}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"End GetStatistics `{RuleInstanceDebugHelper.ConvertToString(targetItem, mStorageDataDictionary)}`");
        }

        private void ValidateRule(InsertQueryItemStatistics context)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateRule context = {context}");

            if(context.Vars.Count == 0)
            {
                throw new RuleException($"The rule `{RuleInstanceDebugHelper.ConvertToString(context.Target, mStorageDataDictionary)}` must contain one or more variables");
            }
        }

        private void ValidateFact(InsertQueryItemStatistics context)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ValidateFact context = {context}");
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
