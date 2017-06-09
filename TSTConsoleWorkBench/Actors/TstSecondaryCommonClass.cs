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
    }
}
