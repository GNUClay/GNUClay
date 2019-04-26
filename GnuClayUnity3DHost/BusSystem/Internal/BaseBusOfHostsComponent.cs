using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal
{
    /// <summary>
    /// Represents a base component of the bus. 
    /// </summary>
    public abstract class BaseBusOfHostsComponent : IDisposable
    {
        /// <summary>
        /// Construct an instance of the component.
        /// </summary>
        /// <param name="context">Common context of the bus.</param>
        /// <param name="logger">Logger for the component.</param>
        protected BaseBusOfHostsComponent(CommonContextOfBusOfHosts context, ILog logger)
        {
            Context = context;
            context.AddComponent(this);

            Logger = logger;
        }

        /// <summary>
        /// Common context of the bus.
        /// </summary>
        protected readonly CommonContextOfBusOfHosts Context;

        /// <summary>
        /// Logger for the component.
        /// </summary>
        public ILog Logger { get; protected set; }

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
        ~BaseBusOfHostsComponent()
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
        }
    }
}
