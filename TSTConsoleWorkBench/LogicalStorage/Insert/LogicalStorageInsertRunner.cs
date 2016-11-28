using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;

namespace TSTConsoleWorkBench.LogicalStorage.Insert
{
    public class LogicalStorageInsertRunner: BaseRunner
    {
        public LogicalStorageInsertRunner()
        {
            mLogicalStorageEngine = new LogicalStorageEngine(null);

            mCreateTestingQuery = new CreateTestingQuery(mLogicalStorageEngine.DataDictionary);

            mCreateSelectTestingQuery = new Select.CreateTestingQuery(mLogicalStorageEngine.DataDictionary);
        }

        private LogicalStorageEngine mLogicalStorageEngine = null;

        private CreateTestingQuery mCreateTestingQuery = null;

        private Select.CreateTestingQuery mCreateSelectTestingQuery = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var tmpSelectQueryText = "SELECT{son(Piter,$X1)}";
            var tmpInsertQueryText = "INSERT {>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";

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

            NLog.LogManager.GetCurrentClassLogger().Info($"`{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, mLogicalStorageEngine.DataDictionary)}`");

            mLogicalStorageEngine.InsertQuery(tmpInsertQuery);

            /*var tmpInsertQuery = mCreateTestingQuery.Run();

            NLog.LogManager.GetCurrentClassLogger().Info($"`{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, mLogicalStorageEngine.DataDictionary)}`");

            mLogicalStorageEngine.InsertQuery(tmpInsertQuery);*/

            var tmpSelectQuery = GnuClayEngine.Context.ParserEngine.Parse(tmpSelectQueryText).SelectQuery;
            NLog.LogManager.GetCurrentClassLogger().Info(SelectQueryDebugHelper.ConvertToString(tmpSelectQuery, mLogicalStorageEngine.DataDictionary, null));

            /*tmpSelectQuery = mCreateSelectTestingQuery.Run();*/

            var tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            /*tmpSelectQuery = mCreateSelectTestingQuery.RunCase_2();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_3();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));*/

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }
    }
}
