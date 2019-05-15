using GnuClayUnity3DHost.BaseHostSystem;
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
