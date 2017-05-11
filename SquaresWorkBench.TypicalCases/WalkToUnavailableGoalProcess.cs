using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class WalkToUnavailableGoalProcess : BaseLogicalProcess
    {
        public WalkToUnavailableGoalProcess()
            : base(StartupMode.OnDemand, "walk to unavailable goal")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor()");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");

            var filter = new ActionCommandFilter();
            filter.CommandName = Name;

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

        protected override void Main()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Main");

            CurrentEntityAction.Status = EntityActionStatus.Faulted;
        }
    }
}
