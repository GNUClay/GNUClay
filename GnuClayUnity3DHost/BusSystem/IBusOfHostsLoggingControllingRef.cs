using GnuClay.CommonHelpers.LoggingHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem
{
    public interface IBusOfHostsLoggingControllingRef
    {
        RewritingModeOfLoggingToFileOnStartup RewritingModeOnStartup { get; }
        string FullLoggingDir { get; }
        string FilePostfix { get; }
    }
}
