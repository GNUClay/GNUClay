using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.LogicalStorage.Wrapper
{
    public class LogicalStorageWrapperRunner
    {
        public LogicalStorageWrapperRunner()
        {
            mLogicalStorageExampleWrapper = new LogicalStorageExampleWrapper();
        }

        private LogicalStorageExampleWrapper mLogicalStorageExampleWrapper = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var tmpSelectQueryText = "SELECT{son(Piter,$X1)}";
                var tmpInsertQueryText = "INSERT {>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";

                NLog.LogManager.GetCurrentClassLogger().Info(tmpInsertQueryText);
                var tmpResult = mLogicalStorageExampleWrapper.Query(tmpInsertQueryText);
                NLog.LogManager.GetCurrentClassLogger().Info($"tmpResult = {tmpResult}");

                NLog.LogManager.GetCurrentClassLogger().Info(tmpSelectQueryText);
                tmpResult = mLogicalStorageExampleWrapper.Query(tmpSelectQueryText);
                NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(tmpResult, mLogicalStorageExampleWrapper.DataDictionary));
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("EndRun");
        }
    }
}
