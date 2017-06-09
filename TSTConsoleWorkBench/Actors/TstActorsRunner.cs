using GnuClay.LocalHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class TstActorsRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Run");
            Case_1();
            //Case_2();
            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private void Case_1()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case_1");

            var tmpServerConnection = new GnuClayLocalServer();
            var tmpEntityConnection = tmpServerConnection.CreateEntity();

            var tmpContextOfLogicalProcesses = new ContextOfLogicalProcesses(tmpEntityConnection);

            var tmpCommonClass = new TstPrimaryCommonClass(tmpContextOfLogicalProcesses);
            var tmpSecondaryCommonClass = new TstSecondaryCommonClass(tmpContextOfLogicalProcesses);

            var tmpLogicalProcesesFactoresRegistry = new LogicalProcessFactoriesRegistry(tmpCommonClass.Context);
            tmpLogicalProcesesFactoresRegistry.AddFactory<TstProcess_1, TstPrimaryCommonClass>(tmpCommonClass);
            tmpLogicalProcesesFactoresRegistry.AddFactory<WalkLogicalProcess, TstPrimaryCommonClass>(tmpCommonClass);
            tmpLogicalProcesesFactoresRegistry.AddFactory<StopLogicalProcess, TstPrimaryCommonClass>(tmpCommonClass);
            tmpLogicalProcesesFactoresRegistry.AddFactory<SecondaryCommonClassLogicalProcess, TstSecondaryCommonClass>(tmpSecondaryCommonClass);
            tmpLogicalProcesesFactoresRegistry.AddFactory<LogicalProcessWithOutCommonClass>();

            var otherCommand = new OtherCommand();
            otherCommand.Name = "other";

            var otherEntityAction = new OtherEntityAction(otherCommand);

            var command = new Command();
            command.Name = "tstProcess";

            var result = tmpCommonClass.Context.ExecuteCommand(command/*, otherEntityAction*/);

            result.OnFinish((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"Case_1 result.OnFinish result = {result}");
            });

            command = new Command();
            command.Name = "alone";

            tmpCommonClass.Context.ExecuteCommand(command);

            command = new Command();
            command.Name = "second";

            tmpCommonClass.Context.ExecuteCommand(command);

            Thread.Sleep(10000);

            NLog.LogManager.GetCurrentClassLogger().Info("Case_1 result.Cancel()");
            result.Cancel();

            Thread.Sleep(10000);

            NLog.LogManager.GetCurrentClassLogger().Info("End Case_1");
        }

        private void Case_2()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case_2");

            var tmpBlackBoard = new Blackboard();

            tmpBlackBoard.OnAddBlackboardCell += (ulong key) =>
            {
                Task.Run(() => {
                    NLog.LogManager.GetCurrentClassLogger().Info($"Case_2 tmpBlackBoard.OnAddBlackboardCell () => key = {key} tmpBlackBoard.GetValue = {tmpBlackBoard.GetValue<int>(key)}");
                });
            };

            tmpBlackBoard.OnAddBlackboardCellWithValue += (ulong key, object value) => {
                Task.Run(() => {
                    NLog.LogManager.GetCurrentClassLogger().Info($"Case_2 tmpBlackBoard.OnAddBlackboardCellWithValue () => key = {key} value = {value}");
                });
            };

            tmpBlackBoard.OnChangeBlackboardCell += (ulong key) =>
            {
                Task.Run(() => {
                    NLog.LogManager.GetCurrentClassLogger().Info($"Case_2 tmpBlackBoard.OnChangeBlackboardCell () => key = {key} tmpBlackBoard.GetValue = {tmpBlackBoard.GetValue<int>(key)}");
                });
            };

            tmpBlackBoard.OnChangeBlackboardCellWithValue += (ulong key, object value) => {
                Task.Run(() => {
                    NLog.LogManager.GetCurrentClassLogger().Info($"Case_2 tmpBlackBoard.OnChangeBlackboardCellWithValue () => key = {key} value = {value}");
                });
            };

            tmpBlackBoard.OnRemoveBlackboardCell += (ulong key) =>
            {
                Task.Run(() => {
                    NLog.LogManager.GetCurrentClassLogger().Info($"Case_2 tmpBlackBoard.OnRemoveBlackboardCell () => key = {key}");
                });
            };

            tmpBlackBoard.OnRemoveBlackboardCellWithValue += (ulong key, object value) => {
                Task.Run(() => {
                    NLog.LogManager.GetCurrentClassLogger().Info($"Case_2 tmpBlackBoard.OnRemoveBlackboardCellWithValue () => key = {key} value = {value}");
                });
            };

            ulong targetKey = 1;

            tmpBlackBoard.SetValue(targetKey, 12);
            tmpBlackBoard.SetValue(targetKey, 12);
            tmpBlackBoard.SetValue(targetKey, 13);
            tmpBlackBoard.SetValue(targetKey, 13);
            tmpBlackBoard.SetValue(targetKey, 14);
            tmpBlackBoard.RemoveKey(targetKey);
            tmpBlackBoard.SetValue(targetKey, 14);

            NLog.LogManager.GetCurrentClassLogger().Info("End Case_2");
        }
    }
}
