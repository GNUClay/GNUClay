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

            var walkToVisibleGoalCommand = new Command();


            walkToVisibleGoalCommand.Name = "walk to visible goal";
            walkToVisibleGoalCommand.Params = CurrentCommand.Params.ToDictionary(p => p.Key, p => p.Value);

            var walkToVisibleGoalResult = LogicalEntity.ExecuteCommand(walkToVisibleGoalCommand);

            walkToVisibleGoalResult.OnFinish((EntityAction action) => {
                var status = action.Status;

                NLog.LogManager.GetCurrentClassLogger().Info($"Main walkToVisibleGoalResult.OnFinish status = {status}");

                /*switch ()
                {

                }*/
            });

            /*var isVisible = LogicalEntity.IsVisible(Goal);

            NLog.LogManager.GetCurrentClassLogger().Info($"Main isVisible = {isVisible}");

            if(isVisible)
            {
                CurrentCommand.Name = "walk to visible goal";

                LogicalEntity.ExecuteCommand(CurrentEntityAction, CurrentCommand);

                return;
            }

            CurrentCommand.Name = "walk to invisible goal";

            LogicalEntity.ExecuteCommand(CurrentEntityAction, CurrentCommand);*/
        }
    }
}
