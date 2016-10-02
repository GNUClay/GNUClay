using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
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

            var tmpResult = mLogicalStorageEngine.mInternalResolverEngine.SelectQuery(tmpSelectQuery);

            NLog.LogManager.GetCurrentClassLogger().Info($"tmpResult = {tmpResult}");
            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

    }
}
