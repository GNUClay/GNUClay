using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.HostSystem
{
    public abstract class BaseHost: IHost, IHostInternalRef, IDisposable
    {
        protected BaseHost(BaseHostOptions options)
        {

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
        ~BaseHost()
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
            if (disposing)
            {
            }
        }
    }
}
