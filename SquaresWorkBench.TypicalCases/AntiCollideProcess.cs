using SquaresWorkBench.CommonEngine;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.TypicalCases
{
    public class AntiCollideProcess: BaseLogicalProcess
    {
        public AntiCollideProcess()
            : base(StartupMode.Automatically, "anti collide process")
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor()");
        }
    }
}
