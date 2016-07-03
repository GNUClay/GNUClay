using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    public class DefaultGnuClayEngineInitializator: BaseGnuClayEngineInitializator
    {
        public DefaultGnuClayEngineInitializator(IGnuClayEngineContext context)
            : base (context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("DefaultGnuClayEngineInitializator");
        }

        public override void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");
        }
    }
}
