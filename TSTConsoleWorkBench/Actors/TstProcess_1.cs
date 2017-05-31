﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class TstProcess_1: LogicalProcess<TstContext>
    {
        public TstProcess_1()
            : base(StartupMode.OnDemand, "tstProcess")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");

            var filter = new CommandFilter();
            filter.CommandName = "tstProcess";

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

            var command = new Command();
            command.Name = "walk";

            var walkResult = Context.ExecuteCommand(command, CurrentEntityAction);

            Thread.Sleep(1000);

            NLog.LogManager.GetCurrentClassLogger().Info($"Main walkResult = {walkResult}");

            while (walkResult.Status == EntityActionStatus.Running)
            {

            }

            NLog.LogManager.GetCurrentClassLogger().Info("Main NEXT");

            //throw new Exception($"Main error");
        }
    }
}
