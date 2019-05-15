using GnuClayUnity3DHost.BusSystem;
using GnuClayUnity3DHost.BaseHostSystem.Internal.LoggingSystem;
using System;
using System.Collections.Generic;
using System.Text;
using GnuClayUnity3DHost.BaseHostSystem.Internal.RemoteLoggingSystem;

namespace GnuClayUnity3DHost.BaseHostSystem.Internal
{
    public class CommonContextOfBaseHost: IDisposable
    {
        public BaseHostOptions Options { get; set; }

        public IBusOfHostsControllingRef BusOfHostsControllingRef { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Adds a component of host to the context for initialization and releasing.
        /// </summary>
        /// <param name="component">Reference to added component.</param>
        public void AddComponent(BaseHostComponent component)
        {
            mComponentList.Add(component);
        }

        private readonly List<BaseHostComponent> mComponentList = new List<BaseHostComponent>();

        /// <summary>
        /// Reference to component for logging.
        /// </summary>
        public Logger LoggerComponent { get; set; }
        public RemoteLogger RemoteLoggerComponent { get; set; }

        /// <summary>
        /// Gets references to other components. 
        /// </summary>
        public virtual void InitStep1()
        {
            foreach (var component in mComponentList)
            {
                component.InitStep1();
            }
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Dispose()
        {
            lock (IsDisposedLockObj)
            {
                if (IsDisposed)
                {
                    return;
                }

                IsDisposed = true;
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for this instance.
        /// </summary>
        ~CommonContextOfBaseHost()
        {
            if (IsDisposed)
            {
                return;
            }

            Dispose(false);
        }

        /// <summary>
        /// Returns true if the instance was released, owerthise returns false.
        /// </summary>
        public bool IsDisposed { get; private set; }
        private readonly object IsDisposedLockObj = new object();

        /// <summary>
        ///  Dispose this instance.
        /// </summary>
        /// <param name="disposing">Is the instance released not in finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            foreach (var item in mComponentList)
            {
                item.Dispose();
            }
        }
    }
}
