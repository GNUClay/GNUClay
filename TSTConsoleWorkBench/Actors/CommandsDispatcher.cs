﻿using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class CommandsDispatcher<C>
        where C : IContextOfLogicalProcesses
    {
        public CommandsDispatcher(C context)
        {
            mCommandFiltersStorage = new CommandFiltersStorage<CommandFilter, C>(context);
        }

        public void AddFilter(CommandFilter filter)
        {
            mCommandFiltersStorage.AddFilter(filter);
        }

        public bool Dipatch(EntityAction action)
        {
            var actionsList = mCommandFiltersStorage.FindFilter(action.Command);

            if (_ListHelper.IsEmpty(actionsList))
            {
                return false;
            }

            var targetAction = actionsList.FirstOrDefault();

            if (targetAction == null)
            {
                return false;
            }

            targetAction.Handler(action);

            return true;
        }

        private CommandFiltersStorage<CommandFilter, C> mCommandFiltersStorage = null;
    }
}
