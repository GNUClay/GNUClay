using GnuClayUnity3DHost.BusSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BaseHostSystem
{
    public interface IHostInternalRef : IDisposable
    {
        void SetBusOfHostsControllingRef(IBusOfHostsControllingRef busOfHostsControllingRef);
        void OnInitedImageDirs();
        void Load();
        void Clear();
        void PrepareForStarting();
        void ProcessStopping();
        void Save();
    }
}
