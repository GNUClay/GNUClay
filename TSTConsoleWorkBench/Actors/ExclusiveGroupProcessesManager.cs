using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class ExclusiveGroupProcessesManager
    {
        public void SetExclusiveGroupProcess(EntityAction action)
        {
            lock(mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"SetExclusiveGroupProcess action = {action}");

                var exclusiveGroupKey = action.ExclusiveGroupKey;

                NLog.LogManager.GetCurrentClassLogger().Info($"SetExclusiveGroupProcess exclusiveGroupKey = {exclusiveGroupKey}");

                if (mExclusiveGroupProcessDict.ContainsKey(exclusiveGroupKey))
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"SetExclusiveGroupProcess mExclusiveGroupProcessDict.ContainsKey(exclusiveGroupKey)");

                    var targetEntityAction = mExclusiveGroupProcessDict[exclusiveGroupKey];

                    if(targetEntityAction == action)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("SetExclusiveGroupProcess targetEntityAction == action");

                        return;
                    }

                    targetEntityAction.Cancel();
                }

                mExclusiveGroupProcessDict[exclusiveGroupKey] = action;

                NLog.LogManager.GetCurrentClassLogger().Info("End SetExclusiveGroupProcess");
            }
        }

        public void RemoveExclusiveGroupProcess(EntityAction action)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"RemoveExclusiveGroupProcess action = {action}");

                var exclusiveGroupKey = action.ExclusiveGroupKey;

                NLog.LogManager.GetCurrentClassLogger().Info($"RemoveExclusiveGroupProcess exclusiveGroupKey = {exclusiveGroupKey}");

                if (mExclusiveGroupProcessDict.ContainsKey(exclusiveGroupKey))
                {
                    NLog.LogManager.GetCurrentClassLogger().Info("RemoveExclusiveGroupProcess mExclusiveGroupProcessDict.ContainsKey(exclusiveGroupKey)");

                    var targetEntityAction = mExclusiveGroupProcessDict[exclusiveGroupKey];

                    if(targetEntityAction == action)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info("RemoveExclusiveGroupProcess targetEntityAction == action");

                        mExclusiveGroupProcessDict.Remove(exclusiveGroupKey);
                    }
                }
            }
        }

        private object mLockObj = new object();
        private Dictionary<ulong, EntityAction> mExclusiveGroupProcessDict = new Dictionary<ulong, EntityAction>();
    }
}
