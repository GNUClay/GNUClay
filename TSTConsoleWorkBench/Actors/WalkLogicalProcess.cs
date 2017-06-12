using GnuClay.CommonUtils.Actors;
using SquaresWorkBench.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class WalkLogicalProcess : LogicalProcessWithCommonClass<TstPrimaryCommonClass>
    {
        public WalkLogicalProcess()
            : base(new LogicalProcessOptions() {
                Name = "walk",
                ExclusiveGroup = "walk_asm"
            })
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");

            var filter = new CommandFilter();
            filter.CommandName = "walk";

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

            while(CurrentEntityAction.Status == EntityActionStatus.Running)
            {

            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End Main CurrentEntityAction.Status = {CurrentEntityAction.Status}");

            //throw new Exception($"Main error");
        }
    }
}
