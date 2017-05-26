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
            Case_1();
            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private void Case_1()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Case_1");

            var tmpContext = new TstContext();

            var tmpLogicalProcesesFactoresRegistry = new LogicalProcessFactoriesRegistry<TstContext>(tmpContext);
            tmpLogicalProcesesFactoresRegistry.AddFactory<TstProcess_1>();

            NLog.LogManager.GetCurrentClassLogger().Info("End Case_1");
        }
    }
}
