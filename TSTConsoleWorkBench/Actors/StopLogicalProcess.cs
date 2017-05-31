using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class StopLogicalProcess : LogicalProcess<TstContext>
    {
        public StopLogicalProcess()
            : base(StartupMode.OnDemand, "stop")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");

            var filter = new CommandFilter();
            filter.CommandName = "stop";

            /*var numberKey = Context.GetKey("number");
            var stringKey = Context.GetKey("string");

            var filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = stringKey;
            filter.Params.Add("goal", filterParameter);
             
            filterParameter = new CommandFilterParam();
            filterParameter.IsAnyType = false;
            filterParameter.TypeKey = numberKey;
            filter.Params.Add("speed", filterParameter);*/

            AddFilter(filter);
        }

        protected override void Main()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Main");

            //throw new Exception($"Main error");
        }
    }
}
