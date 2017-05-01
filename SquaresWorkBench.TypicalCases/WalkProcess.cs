using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class WalkProcess: BaseLogicalProcess
    {
        public WalkProcess()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor()");
        }

        protected override void OnRegFilter()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(OnRegFilter)}");
        }
    }
}
