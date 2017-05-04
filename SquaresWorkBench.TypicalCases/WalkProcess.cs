using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class WalkProcess: BaseLogicalProcess
    {
        public WalkProcess()
            : base(StartupMode.OnDemand, "walk")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor()");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");

            var filter = new ActionCommandFilter();
            filter.CommandName = "walk";

            var filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;

            filter.Params.Add("distance", filterParameter);

            AddFilter(filter);
        }
    }
}
