using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem
{
    public interface IBusOfHostsControllingRef
    {
        IBusOfHostsLoggingControllingRef LoggindOptions { get; }
    }
}
