using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class CommandsDispatcher
    {
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

        private CommandFiltersStorage<ActionCommandFilter> mCommandFiltersStorage = new CommandFiltersStorage<ActionCommandFilter>();
    }
}
