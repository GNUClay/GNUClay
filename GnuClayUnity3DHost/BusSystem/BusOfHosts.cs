using System;
using System.Collections.Generic;
using System.Text;
using GnuClay;
using GnuClayUnity3DHost.BusSystem.Internal;
using GnuClayUnity3DHost.BusSystem.Internal.LoggingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RegistryOfHostSystem;
using GnuClayUnity3DHost.HostSystem;

namespace GnuClayUnity3DHost.BusSystem
{
    public class BusOfHosts : IBusOfHostsInternalRef, IDisposable
    {
        public BusOfHosts(BusOfHostsOptions options)
        {
            OptionsChecker(options);

            mContext = new CommonContextOfBusOfHosts();
            mContext.Options = options;
            mContext.LoggerComponent = new Logger(mContext);
            mLogger = mContext.LoggerComponent;

            CreateComponents();
            InitComponents();
        }

        private readonly CommonContextOfBusOfHosts mContext;
        private readonly ILog mLogger;

        private void OptionsChecker(BusOfHostsOptions options)
        {
            if(string.IsNullOrWhiteSpace(options.BaseDir))
            {
                throw new NullReferenceException($"Base directory of bus is null or empty.");
            }
        }

        private void CreateComponents()
        {
            mContext.RegistryOfHostComponent = new RegistryOfHost(mContext, mLogger);
        }

        private void InitComponents()
        {
        }

        void IBusOfHostsInternalRef.AddHost(IHostInternalRef host)
        {
            mContext.RegistryOfHostComponent.AddHost(host);
        }

        public void Start()
        {
#if DEBUG
            mLogger.Info("Begin");
#endif

            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
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
        ~BusOfHosts()
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
            mContext?.Dispose();
        }
    }
}
