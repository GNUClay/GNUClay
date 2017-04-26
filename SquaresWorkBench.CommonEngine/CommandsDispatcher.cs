using GnuClay.CommonClientTypes;
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
            mCommandFiltersStorage = new CommandFiltersStorage(entityConnection, cSharpTypesRegistry);
        }

        public void AddFilter(ActionCommandFilter filter)
        {
            mCommandFiltersStorage.AddFilter(filter);
        }

        public bool Dipatch(EntityAction actionResult)
        {
            var action = mCommandFiltersStorage.FindFilter(actionResult.Command);

            if(action == null)
            {
                return false;
            }

            action.Handler(actionResult, actionResult.Command);

            return true;
        }

        private CommandFiltersStorage mCommandFiltersStorage = null;
    }
}
