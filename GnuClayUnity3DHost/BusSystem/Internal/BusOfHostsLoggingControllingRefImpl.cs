using GnuClay.CommonHelpers.LoggingHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal
{
    public class BusOfHostsLoggingControllingRefImpl: IBusOfHostsLoggingControllingRef
    {
        public BusOfHostsLoggingControllingRefImpl(CommonContextOfBusOfHosts context)
        {
            mContext = context;
        }

        private readonly CommonContextOfBusOfHosts mContext;

        RewritingModeOfLoggingToFileOnStartup IBusOfHostsLoggingControllingRef.RewritingModeOnStartup => mContext.LoggingSettings.RewritingModeOnStartup;
        string IBusOfHostsLoggingControllingRef.FullLoggingDir => mContext.LoggingSettings.FullLoggingDir;
        string IBusOfHostsLoggingControllingRef.FilePostfix => mContext.LoggingSettings.FilePostfix;
    }
}
