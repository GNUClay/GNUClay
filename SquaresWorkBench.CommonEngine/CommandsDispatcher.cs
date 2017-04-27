using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class CommandsDispatcher
    {
        public CommandsDispatcher(IGnuClayEntityConnection entityConnection, CSharpTypesRegistry cSharpTypesRegistry)
        {
            mCommandFiltersStorage = new CommandFiltersStorage<ActionCommandFilter>(entityConnection, cSharpTypesRegistry);
        }

        public void AddFilter(ActionCommandFilter filter)
        {
            mCommandFiltersStorage.AddFilter(filter);
        }

        public bool Dipatch(EntityAction actionResult)
        {
            var actionsList = mCommandFiltersStorage.FindFilter(actionResult.Command);

            if(_ListHelper.IsEmpty(actionsList))
            {
                return false;
            }

            var targetAction = actionsList.FirstOrDefault();

            if(targetAction == null)
            {
                return false;
            }

            targetAction.Handler(actionResult, actionResult.Command);

            return true;
        }

        private CommandFiltersStorage<ActionCommandFilter> mCommandFiltersStorage = null;
    }
}
