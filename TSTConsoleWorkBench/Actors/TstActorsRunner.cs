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

            var tmpContext = new TstContext();

            var tmpLogicalProcesesFactoresRegistry = new LogicalProcessFactoriesRegistry<TstContext>(tmpContext);
            tmpLogicalProcesesFactoresRegistry.AddFactory<TstProcess_1>();

            var command = new Command();
            command.Name = "TstProcess_1";

            var result = tmpContext.ExecuteCommand(command);

            result.OnFinish((EntityAction action) => {
                NLog.LogManager.GetCurrentClassLogger().Info($"Case_1 result.OnFinish result = {result}");
            });

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
