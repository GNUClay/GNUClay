using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class CurrentEntityActionsManager
    {
        public void SetProcessAsCurrent(EntityAction action)
        {
            lock(mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"SetProcessAsCurrent action = {action}");

                if(mCurrentActions.Contains(action))
                {
                    return;
                }

                mCurrentActions.Add(action);
            }
        }

        public void RemoveProcessAsCurrent(EntityAction action)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"RemoveProcessAsCurrent action = {action}");

                if (mCurrentActions.Contains(action))
                {
                    mCurrentActions.Remove(action);
                }
            }
        }

        private object mLockObj = new object();
        private List<EntityAction> mCurrentActions = new List<EntityAction>();
    }
}
