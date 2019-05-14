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
            lock(mHostsListLockObj)
            {
                if (mHostsList.Contains(host))
                {
                    return;
                }

                mHostsList.Add(host);
                host.SetBusOfHostsControllingRef(Context.BusOfHostsControllingRef);
            }
        }

        private readonly object mHostsListLockObj = new object();
        private List<IHostInternalRef> mHostsList = new List<IHostInternalRef>();

        public override void OnInitedImageDirs()
        {
            base.OnInitedImageDirs();
            EmitOnInitedImageDirs();
        }

        public void EmitOnInitedImageDirs()
        {
            lock (mHostsListLockObj)
            {
                foreach (var host in mHostsList)
                {
                    host.OnInitedImageDirs();
                }
            }
        }

        public void Load()
        {
            lock (mHostsListLockObj)
            {
                foreach (var host in mHostsList)
                {
                    host.Load();
                }
            }
        }

        public void Clear()
        {
            lock (mHostsListLockObj)
            {
                foreach (var host in mHostsList)
                {
                    host.Clear();
                }
            }
        }

        public void PrepareForStarting()
        {
            lock (mHostsListLockObj)
            {
                foreach (var host in mHostsList)
                {
                    host.PrepareForStarting();
                }
            }
        }

        public void ProcessStopping()
        {
            lock (mHostsListLockObj)
            {
                foreach (var host in mHostsList)
                {
                    host.ProcessStopping();
                }
            }
        }

        public void Save()
        {
            lock (mHostsListLockObj)
            {
                foreach (var host in mHostsList)
                {
                    host.Save();
                }
            }
        }

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
