using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class ContextOfLogicalProcesses: IContextOfLogicalProcesses
    {
        public ContextOfLogicalProcesses(IGnuClayEntityConnection entityConnection)
        {
            mEntityConnection = entityConnection;
        }

        protected IGnuClayEntityConnection mEntityConnection = null;
    }
}
