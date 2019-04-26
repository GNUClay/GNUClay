using GnuClay;
using GnuClayUnity3DHost.HostSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RegistryOfHostSystem
{
    public class RegistryOfHost: BaseBusOfHostsLoggedComponent
    {
        public RegistryOfHost(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
        }

        public void AddHost(IHostInternalRef host)
        {
            if(mHostsList.Contains(host))
            {
                return;
            }

            mHostsList.Add(host);
        }

        private List<IHostInternalRef> mHostsList = new List<IHostInternalRef>();

        /// <summary>
        ///  Dispose this instance.
        /// </summary>
        /// <param name="disposing">Is the instance released not in finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            foreach(var host in mHostsList)
            {
                host.Dispose();
            }
        }
    }
}
