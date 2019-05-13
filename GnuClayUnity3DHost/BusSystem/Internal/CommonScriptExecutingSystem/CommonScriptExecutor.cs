using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.CommonScriptExecutingSystem
{
    public class CommonScriptExecutor : BaseBusOfHostsLoggedComponent
    {
        public CommonScriptExecutor(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
        }

        // TODO: fix me!
        public void Start()
        {
#if DEBUG
            Debug("Begin");
#endif
        }

        // TODO: fix me!
        public void Stop()
        {
#if DEBUG
            Debug("Begin");
#endif
        }
    }
}
