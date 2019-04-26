using GnuClayUnity3DHost.BipedHostSystem.Internal;
using GnuClayUnity3DHost.BusSystem;
using GnuClayUnity3DHost.HostSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BipedHostSystem
{
    public class BipedHost: BaseHost<CommonContextOfBipedHost>
    {
        public BipedHost(BipedHostOptions options)
            : base(options)
        {
            var internalRef = options.Bus as IBusOfHostsInternalRef;//tmp
            internalRef.AddHost(this);//tmp
        }
    }
}
