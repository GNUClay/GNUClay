using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class TstSecondaryCommonClass : ICommonClassOfLogicalProcesses
    {
        public TstSecondaryCommonClass(IContextOfLogicalProcesses context)
        {
            mContextOfLogicalProcesses = context;
            mContextOfLogicalProcesses.SetFiledDispatchOfCommandHandler(OnFiledDispatchOfCommand);
        }

        private IContextOfLogicalProcesses mContextOfLogicalProcesses = null;

        public IContextOfLogicalProcesses Context
        {
            get
            {
                return mContextOfLogicalProcesses;
            }
        }

        public void RunFakeUnity3DHost()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RunFakeUnity3DHost");
        }

        private void OnFiledDispatchOfCommand(IEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnFiledDispatchOfCommand action.Command = {action.Command}");
        }
    }
}
