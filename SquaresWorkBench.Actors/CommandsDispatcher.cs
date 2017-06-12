using GnuClay.CommonUtils.Actors;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public class CommandsDispatcher
    {
        public CommandsDispatcher(IContextOfLogicalProcesses context)
        {
            mCommandFiltersStorage = new CommandFiltersStorage<CommandFilter>(context);
        }

        private object mLockObj = new object();

        public void AddFilter(CommandFilter filter)
        {
            lock (mLockObj)
            {
                mCommandFiltersStorage.AddFilter(filter);

                InvalidateCache();
            }
        }

        public bool Dipatch(IEntityAction action)
        {
            lock (mLockObj)
            {
                var commandHashCode = action.Command.GetHashCode();

                if (mCommandFiltersCacheDict.ContainsKey(commandHashCode))
                {
                    mCommandFiltersCacheDict[commandHashCode].Invoke(action);

                    return true;
                }

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

                mCommandFiltersCacheDict[commandHashCode] = targetAction.Handler;

                targetAction.Handler(action);

                return true;
            }
        }

        private CommandFiltersStorage<CommandFilter> mCommandFiltersStorage = null;
        private Dictionary<int, CommandHandler> mCommandFiltersCacheDict = new Dictionary<int, CommandHandler>();

        private void InvalidateCache()
        {
            mCommandFiltersCacheDict.Clear();
        }
    }
}
