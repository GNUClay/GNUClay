using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Bootstrap
{
    public class BootstrapEngine: BaseGnuClayEngineComponent
    {
        public BootstrapEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Run");
#endif

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
#endif
        }
    }
}
