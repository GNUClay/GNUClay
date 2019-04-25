using GnuClayUnity3DHost.HostSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem
{
    public interface IBusOfHostsInternalRef: IDisposable
    {
        void AddHost(IHostInternalRef host);
    }
}
