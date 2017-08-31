using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System.Linq;

namespace TSTConsoleWorkBench.LogicalStorage.Insert
{
    public class LogicalStorageInsertRunner: BaseRunner
    {
        public LogicalStorageInsertRunner()
        {
            //mLogicalStorageEngine = new LogicalStorageEngine(null);

            //mCreateTestingQuery = new CreateTestingQuery(mLogicalStorageEngine.DataDictionary);

            //mCreateSelectTestingQuery = new Select.CreateTestingQuery(mLogicalStorageEngine.DataDictionary);
        }

        //private LogicalStorageEngine mLogicalStorageEngine = null;

        //private CreateTestingQuery mCreateTestingQuery = null;

        //private Select.CreateTestingQuery mCreateSelectTestingQuery = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            RunWithFacade();
            //RunCommonCase();
            //RunComplexFacts();

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private void RunWithFacade()
        {
            var tmpQueryText = "READ {>: {son(Piter,$X1)}}";
            var tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "WRITE {>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "WRITE{>: {son(Alise,Bob)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "DELETE{>: {son(Alise,$X1)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "READ{>: {son(Alise,$X1)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "WRITE{>: {son(Alise,Bob)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "READ{>: {son(Alise,$X1)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "REWRITE{>: {son(Alise,Rob)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpQueryText = "READ{>: {son(Alise,$X1)}}";
            tmpResult = GnuClayEngine.Query(tmpQueryText);
            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));
        }

        private void RunCommonCase()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RunCommonCase");

            var tmpSelectQueryText = "READ {>: {son(Piter,$X1)}}";
            var tmpInsertQueryText = "WRITE {>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";

            /*var tmpSelectQuery = mCreateSelectTestingQuery.Run();

            var tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_2();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_3();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));*/

            var tmpInsertQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpInsertQueryText).InsertQuery;

            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, GnuClayEngine.DataDictionary)}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{tmpInsertQuery}`");

            GnuClayEngine.LogicalStorage.InsertQuery(tmpInsertQuery);

            /*var tmpInsertQuery = mCreateTestingQuery.Run();

            NLog.LogManager.GetCurrentClassLogger().Info($"`{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, mLogicalStorageEngine.DataDictionary)}`");

            mLogicalStorageEngine.InsertQuery(tmpInsertQuery);*/

            var tmpSelectQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpSelectQueryText).SelectQuery;
            //tmpSelectQuery.SelectDirectFactsOnly = true;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText = {SelectQueryDebugHelper.ConvertToString(tmpSelectQuery, GnuClayEngine.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText = {tmpSelectQuery}");

            /*tmpSelectQuery = mCreateSelectTestingQuery.Run();*/

            var tmpResult = GnuClayEngine.LogicalStorage.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));

            tmpInsertQueryText = "WRITE{>: {son(Alise,Bob)}}";
            tmpInsertQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpInsertQueryText).InsertQuery;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, GnuClayEngine.DataDictionary)}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{tmpInsertQuery}`");

            GnuClayEngine.LogicalStorage.InsertQuery(tmpInsertQuery);

            tmpSelectQueryText = "DELETE{>: {son(Alise,$X1)}}";
            tmpSelectQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpSelectQueryText).SelectQuery;
            //tmpSelectQuery.SelectDirectFactsOnly = true;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText = {SelectQueryDebugHelper.ConvertToString(tmpSelectQuery, GnuClayEngine.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText = {tmpSelectQuery}");

            GnuClayEngine.LogicalStorage.RemoveFacts(tmpSelectQuery);

            //tmpResult = GnuClayEngine.LogicalStorage.SelectQuery(tmpSelectQuery);

            //NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));
            //NLog.LogManager.GetCurrentClassLogger().Info($"tmpResult = {tmpResult}");

            //foreach(var resultItem in tmpResult.Items)
            //{
            //    if(resultItem.Key == 0)
            //    {
            //        continue;
            //    }

            //    NLog.LogManager.GetCurrentClassLogger().Info($"resultItem = {resultItem}");

            //    GnuClayEngine.LogicalStorage.TSTRemoveFactOrRuleByKey(resultItem.Key);
            //}

            tmpSelectQueryText = "READ{>: {son(Alise,$X1)}}";
            tmpSelectQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpSelectQueryText).SelectQuery;
            tmpSelectQuery.SelectDirectFactsOnly = true;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText (2)= {SelectQueryDebugHelper.ConvertToString(tmpSelectQuery, GnuClayEngine.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText (2)= {tmpSelectQuery}");

            tmpResult = GnuClayEngine.LogicalStorage.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpResult (2)= {tmpResult}");

            tmpInsertQueryText = "WRITE{>: {son(Alise,Bob)}}";
            tmpInsertQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpInsertQueryText).InsertQuery;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, GnuClayEngine.DataDictionary)}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{tmpInsertQuery}`");

            GnuClayEngine.LogicalStorage.InsertQuery(tmpInsertQuery);

            tmpSelectQueryText = "READ{>: {son(Alise,$X1)}}";
            tmpSelectQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpSelectQueryText).SelectQuery;
            //tmpSelectQuery.SelectDirectFactsOnly = true;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText (3)= {SelectQueryDebugHelper.ConvertToString(tmpSelectQuery, GnuClayEngine.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText (3)= {tmpSelectQuery}");

            tmpResult = GnuClayEngine.LogicalStorage.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpResult (3)= {tmpResult}");


            tmpInsertQueryText = "REWRITE{>: {son(Alise,Rob)}}";
            tmpInsertQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpInsertQueryText).InsertQuery;
            tmpInsertQuery.Rewrite = true;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, GnuClayEngine.DataDictionary)}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{tmpInsertQuery}`");

            GnuClayEngine.LogicalStorage.InsertQuery(tmpInsertQuery);

            tmpSelectQueryText = "READ{>: {son(Alise,$X1)}}";
            tmpSelectQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpSelectQueryText).SelectQuery;
            //tmpSelectQuery.SelectDirectFactsOnly = true;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText (4)= {SelectQueryDebugHelper.ConvertToString(tmpSelectQuery, GnuClayEngine.DataDictionary)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpSelectQueryText (4)= {tmpSelectQuery}");

            tmpResult = GnuClayEngine.LogicalStorage.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, GnuClayEngine.DataDictionary));
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpResult (4)= {tmpResult}");

            /*tmpSelectQuery = mCreateSelectTestingQuery.RunCase_2();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_3();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));*/

            NLog.LogManager.GetCurrentClassLogger().Info("End RunCommonCase");
        }

        public void RunComplexFacts()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RunComplexFacts");

            var mainContext = GnuClayEngine.Context;

            //var tmpInsertQueryText = "INSERT {>: {bit(dog, hand) & instrument(bit, teeth) & part(teeth, dog) & part(hand, Mary)}}";
            //var tmpInsertQueryText = "INSERT {>: {$x1:bit($x2:dog, $x3:hand) & instrument($x1:bit, $x4:teeth) & part($x4:teeth, $x2:dog) & part($x3:hand, Mary)}}";
            //var tmpInsertQueryText = "INSERT #1:{>: {$x1:bit($x2:dog, $x3:hand) & instrument($x1:bit, $x4:teeth) & part($x4:teeth, $x2:dog) & part($x3:hand, Mary)}}";
            var tmpInsertQueryText = "INSERT #fact2:{>:{know(Tom, #fact1:{>:{$x1:bit($x2:dog, $x3:hand) & instrument($x1:bit, $x4:teeth) & part($x4:teeth, $x2:dog) & part($x3:hand, Mary)}})}}";
            var tmpInsertQuery = mainContext.ParserEngine.Parse(tmpInsertQueryText).InsertQuery;

            //var tmpReferenceKey = mainContext.DataDictionary.GetKey("*x1");

            //var targetRuleInstance = tmpInsertQuery.Items.First();

            //var targetNode = targetRuleInstance.Part_1.Tree;

            //targetNode.KeyOfReference = tmpReferenceKey;

            //targetRuleInstance.LocalKeyOfReferenceIndex[tmpReferenceKey] = targetNode;
            tmpInsertQuery.EnableLocalIndexesInToString = true;
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{tmpInsertQuery}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"tmpInsertQuery = `{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, GnuClayEngine.DataDictionary)}`");

            //The parser runs this query with mistakes. A query is parsed partial.

            NLog.LogManager.GetCurrentClassLogger().Info("End RunComplexFacts");
        }
    }
}
