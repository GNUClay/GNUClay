using GnuClayUnity3DHost.HostSystem.Internal.LoggingSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.HostSystem.Internal
{
    public class CommonContextOfBaseHost: IDisposable
    {
        public BaseHostOptions Options { get; set; }

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
