using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.LoadingFromSourceCode
{
    public class LoaderFromSourceCode: BaseBusOfHostsLoggedComponent
    {
        public LoaderFromSourceCode(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
        }

        // TODO: fix me!
        public void Load()
        {
#if DEBUG
            Debug("Begin");
#endif
        }
    }
}
