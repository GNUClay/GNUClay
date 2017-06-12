using GnuClay.CommonUtils.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public class CurrentEntityActionsManager
    {
        public void SetProcessAsCurrent(IEntityAction action)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"SetProcessAsCurrent");

                if (mCurrentActions.Contains(action))
                {
                    return;
                }

                mCurrentActions.Add(action);
            }
        }

        public void RemoveProcessAsCurrent(IEntityAction action)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"RemoveProcessAsCurrent");

                if (mCurrentActions.Contains(action))
                {
                    mCurrentActions.Remove(action);
                }
            }
        }

        private object mLockObj = new object();
        private List<IEntityAction> mCurrentActions = new List<IEntityAction>();
    }
}
