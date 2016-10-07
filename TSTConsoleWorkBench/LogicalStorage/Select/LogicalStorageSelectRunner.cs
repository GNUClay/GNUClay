using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.LogicalStorage.Select
{
    public class LogicalStorageSelectRunner
    {
        public LogicalStorageSelectRunner()
        {
            mLogicalStorageEngine = new LogicalStorageEngine();

            mCreateTestingRules = new CreateTestingRules(mLogicalStorageEngine);

            mCreateTestingQuery = new CreateTestingQuery(mLogicalStorageEngine.mStorageDataDictionary);
        }

        private LogicalStorageEngine mLogicalStorageEngine = null;

        private CreateTestingRules mCreateTestingRules = null;

        private CreateTestingQuery mCreateTestingQuery = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            mCreateTestingRules.Run();

            var tmpSelectQuery = mCreateTestingQuery.Run();

            var tmpStopWatch = new Stopwatch();

            tmpStopWatch.Start();

            var tmpResult = mLogicalStorageEngine.mInternalResolverEngine.SelectQuery(tmpSelectQuery);

            tmpStopWatch.Stop();

            NLog.LogManager.GetCurrentClassLogger().Info($"ElapsedMilliseconds = {tmpStopWatch.ElapsedMilliseconds}");

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.mStorageDataDictionary));

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");

            NLog.LogManager.GetCurrentClassLogger().Info("RunCase_2");

            tmpSelectQuery = mCreateTestingQuery.RunCase_2();

            tmpStopWatch.Restart();

            tmpResult = mLogicalStorageEngine.mInternalResolverEngine.SelectQuery(tmpSelectQuery);

            tmpStopWatch.Stop();

            NLog.LogManager.GetCurrentClassLogger().Info($"ElapsedMilliseconds = {tmpStopWatch.ElapsedMilliseconds}");

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.mStorageDataDictionary));

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");

            NLog.LogManager.GetCurrentClassLogger().Info("RunCase_3");

            tmpSelectQuery = mCreateTestingQuery.RunCase_3();

            tmpStopWatch.Restart();

            tmpResult = mLogicalStorageEngine.mInternalResolverEngine.SelectQuery(tmpSelectQuery);

            tmpStopWatch.Stop();

            NLog.LogManager.GetCurrentClassLogger().Info($"ElapsedMilliseconds = {tmpStopWatch.ElapsedMilliseconds}");

            NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageEngine.mStorageDataDictionary));

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }
    }
}
