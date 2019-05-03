using GnuClayUnity3DHost.BusSystem.Internal.IdsStorageSystem;
using GnuClayUnity3DHost.BusSystem.Internal.LoggingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RegistryOfHostSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RemoteLoggingSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal
{
    public sealed class CommonContextOfBusOfHosts: IDisposable
    {
        public BusOfHostsOptions Options { get; set; }

        public string BaseDir { get; set; }
        public string SharedPackagesDir { get; set; }
        public string AppsDir { get; set; }
        public string ImagesDir { get; set; }
        public LoggingSettings LoggingSettings { get; set; } = new LoggingSettings();

        /// <summary>
        /// Adds a component of bus to the context for initialization and releasing.
        /// </summary>
        /// <param name="component">Reference to added component.</param>
        public void AddComponent(BaseBusOfHostsComponent component)
        {
            mComponentList.Add(component);
        }

        private readonly List<BaseBusOfHostsComponent> mComponentList = new List<BaseBusOfHostsComponent>();

        /// <summary>
        /// Reference to component for logging.
        /// </summary>
        public Logger LoggerComponent { get; set; }
        public RemoteLogger RemoteLoggerComponent { get; set; }
        public RegistryOfHost RegistryOfHostComponent { get; set; }
        public IdsStorage IdsStorageComponent { get; set; }

        /// <summary>
        /// Gets references to other components. 
        /// </summary>
        public void InitStep1()
        {
            foreach(var component in mComponentList)
            {
                component.InitStep1();
            }
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for this instance.
        /// </summary>
        ~CommonContextOfBusOfHosts()
        {
            Dispose(false);
        }

        /// <summary>
        /// Returns true if the instance was released, owerthise returns false.
        /// </summary>
        public bool IsDisposed { get; private set; }

        private readonly object IsDisposedLockObj = new object();

        private void Dispose(bool disposing)
        {
            foreach (var item in mComponentList)
            {
                item.Dispose();
            }
        }
    }
}
