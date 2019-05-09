using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem
{
    public class RuntimeSettingsStorage : BaseBusOfHostsLoggedComponent
    {
        public RuntimeSettingsStorage(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
#if DEBUG
            logger.Log("Begin");
#endif
        }
    }
}
