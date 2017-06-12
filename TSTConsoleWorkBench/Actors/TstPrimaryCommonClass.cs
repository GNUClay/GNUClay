using GnuClay.CommonClientTypes;
using GnuClay.LocalHost;
using SquaresWorkBench.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTConsoleWorkBench.Actors;

namespace TSTConsoleWorkBench.Actors
{
    public class TstPrimaryCommonClass: ICommonClassOfLogicalProcesses
    {
        public TstPrimaryCommonClass(IContextOfLogicalProcesses context)
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

        public void GoToMarket()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoToMarket");
        }
    }
}
