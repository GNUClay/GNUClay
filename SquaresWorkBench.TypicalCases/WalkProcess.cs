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

            var numberKey = LogicalEntity.GetKey("number");

            var filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = numberKey;
            filter.Params.Add("distance", filterParameter);

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = numberKey;
            filter.Params.Add("speed", filterParameter);

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = LogicalEntity.GetKey("side");
            filter.Params.Add("side", filterParameter);

            AddFilter(filter);

            filter = new ActionCommandFilter();
            filter.CommandName = "walk";

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = LogicalEntity.GetKey("number");
            filter.Params.Add("speed", filterParameter);

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = LogicalEntity.GetKey("side");
            filter.Params.Add("side", filterParameter);

            AddFilter(filter);

            filter = new ActionCommandFilter();
            filter.CommandName = "walk";

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = LogicalEntity.GetKey("number");
            filter.Params.Add("distance", filterParameter);

            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = LogicalEntity.GetKey("number");
            filter.Params.Add("speed", filterParameter);

            AddFilter(filter);
        }

        protected override void Main()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Main");

            /*while(true)
{
    NLog.LogManager.GetCurrentClassLogger().Info($"Main actionResult.Status = {actionResult.Status}  command = {command} !!!!!!!!!!!!!");
}*/

            NLog.LogManager.GetCurrentClassLogger().Info("End Main");
        }
    }
}
