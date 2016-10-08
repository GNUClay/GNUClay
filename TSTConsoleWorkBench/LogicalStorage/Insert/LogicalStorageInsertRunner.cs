using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.LogicalStorage.Insert
{
    public class LogicalStorageInsertRunner
    {
        public LogicalStorageInsertRunner()
        {
            mLogicalStorageEngine = new LogicalStorageEngine();

            mCreateTestingQuery = new CreateTestingQuery(mLogicalStorageEngine.DataDictionary);

            mCreateSelectTestingQuery = new Select.CreateTestingQuery(mLogicalStorageEngine.DataDictionary);
        }

        private LogicalStorageEngine mLogicalStorageEngine = null;

        private CreateTestingQuery mCreateTestingQuery = null;

        private Select.CreateTestingQuery mCreateSelectTestingQuery = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var tmpSelectQuery = mCreateSelectTestingQuery.Run();

            var tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_2();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_3();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            var tmpInsertQuery = mCreateTestingQuery.Run();

            NLog.LogManager.GetCurrentClassLogger().Info($"`{InsertQueryDebugHelper.ConvertToString(tmpInsertQuery, mLogicalStorageEngine.DataDictionary)}`");

            mLogicalStorageEngine.InsertQuery(tmpInsertQuery);

            tmpSelectQuery = mCreateSelectTestingQuery.Run();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_2();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            tmpSelectQuery = mCreateSelectTestingQuery.RunCase_3();

            tmpResult = mLogicalStorageEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.DataDictionary));

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }
    }
}
