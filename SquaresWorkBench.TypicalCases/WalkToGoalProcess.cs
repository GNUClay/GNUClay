using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class WalkToGoalProcess : BaseLogicalProcess
    {
        public WalkToGoalProcess()
            : base(StartupMode.OnDemand, "walk")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor()");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");

            var filter = new ActionCommandFilter();
            filter.CommandName = "walk";

            var numberKey = LogicalEntity.GetKey("number");
            var stringKey = LogicalEntity.GetKey("string");

            var filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = stringKey;
            filter.Params.Add("goal", filterParameter);

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = numberKey;
            filter.Params.Add("speed", filterParameter);

            AddFilter(filter);
        }

        private double Speed = 0;
        private string Goal = string.Empty;

        protected override void OnStart()
        {
            var paramsDict = CurrentCommand.Params;

            Speed = (double)paramsDict["speed"];
            Goal = (string)paramsDict["goal"];
        }

        protected override void Main()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Main Speed = {Speed} Goal = {Goal}");

            var walkToAvailableGoalCommand = new Command();


            walkToAvailableGoalCommand.Name = "walk to available goal";
            walkToAvailableGoalCommand.Params = CurrentCommand.Params.ToDictionary(p => p.Key, p => p.Value);

            var walkToVisibleGoalResult = LogicalEntity.ExecuteCommand(walkToAvailableGoalCommand);

            walkToVisibleGoalResult.OnFinish((EntityAction action) => {
                var status = action.Status;

                NLog.LogManager.GetCurrentClassLogger().Info($"Main walkToAvailableGoalResult.OnFinish status = {status}");

                switch (status)
                {
                    case EntityActionStatus.Completed:
                        CurrentEntityAction.Status = EntityActionStatus.Completed;
                        break;

                    case EntityActionStatus.Faulted:
                        var walkToUnavailableGoalCommand = new Command();
                        walkToUnavailableGoalCommand.Name = "walk to unavailable goal";
                        walkToUnavailableGoalCommand.Params = CurrentCommand.Params.ToDictionary(p => p.Key, p => p.Value);

                        var walkToUnavailableGoalResult = LogicalEntity.ExecuteCommand(walkToUnavailableGoalCommand);

                        walkToUnavailableGoalResult.OnFinish((EntityAction action_1) => {
                            NLog.LogManager.GetCurrentClassLogger().Info($"Main walkToUnavailableGoalResult.OnFinish status = {status}");

                            var status_2 = action_1.Status;

                            switch(status_2)
                            {
                                case EntityActionStatus.Completed:
                                    CurrentEntityAction.Status = EntityActionStatus.Completed;
                                    break;

                                case EntityActionStatus.Faulted:
                                    CurrentEntityAction.Status = EntityActionStatus.Faulted;
                                    break;
                            }
                        });
                        break;
                }
            });
        }
    }
}
