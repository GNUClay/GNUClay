using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem
{
    public class RunTimeSettingsStorage : BaseBusOfHostsLoggedComponent
    {
        public RunTimeSettingsStorage(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
#if DEBUG
            logger.Log("Begin");
#endif
        }
    }
}
