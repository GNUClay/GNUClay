using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class StopLogicalProcess : LogicalProcessWithCommonClass<TstContext>
    {
        public StopLogicalProcess()
            : base(new LogicalProcessOptions() {
                Name = "stop",
                ExclusiveGroup = "walk_asm"
            })
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
            NLog.LogManager.GetCurrentClassLogger().Info($"Main CurrentEntityAction.Status = {CurrentEntityAction.Status}");

            while (CurrentEntityAction.Status == EntityActionStatus.Running)
            {

            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End Main CurrentEntityAction.Status = {CurrentEntityAction.Status}");

            //throw new Exception($"Main error");
        }
    }
}
