using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class WalkToVisibleGoalProcess : BaseLogicalProcess
    {
        public WalkToVisibleGoalProcess()
            : base(StartupMode.OnDemand, "walk to visible goal")
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

            var n = 0;

            while(true)
            {
                n++;

                if(n == 2)
                {
                    break;
                }

                var targetVisibleItem = LogicalEntity.GetVisibleResultItem(Goal);

                NLog.LogManager.GetCurrentClassLogger().Info($"Main n = {n} targetVisibleItem = {targetVisibleItem}");
            }

            CurrentEntityAction.Status = EntityActionStatus.Faulted;

            NLog.LogManager.GetCurrentClassLogger().Info("End Main");
        }
    }
}
