using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class TstActorsRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Run");

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }
    }
}
