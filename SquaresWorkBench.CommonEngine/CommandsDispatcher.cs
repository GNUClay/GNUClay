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

        public EntityAction Dipatch(Command command)
        {
            var action = mCommandFiltersStorage.FindFilter(command);

            if(action == null)
            {
                return null;
            }

            return action.Handler(command);
        }

        private CommandFiltersStorage<ActionCommandFilter> mCommandFiltersStorage = new CommandFiltersStorage<ActionCommandFilter>();
    }
}
