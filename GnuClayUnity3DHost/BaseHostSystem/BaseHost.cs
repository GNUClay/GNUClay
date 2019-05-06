using GnuClay;
using GnuClayUnity3DHost.HostSystem.Internal;
using GnuClayUnity3DHost.HostSystem.Internal.LoggingSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.HostSystem
{
    public abstract class BaseHost<T>: IHost, IHostInternalRef, IDisposable where T: CommonContextOfBaseHost, new()
    {
        protected BaseHost(BaseHostOptions options)
        {
            OptionsChecker(options);

            Context = new T();
            Context.Options = options;
            Context.LoggerComponent = new Logger(Context);
            mLogger = Context.LoggerComponent;

            CreateComponents();
            InitComponents();
        }

        protected readonly object mStateLockObj = new object();
        protected StateOfEngine mState = StateOfEngine.Created;

        /// <summary>
        /// Gets state of the host.
        /// </summary>
        public StateOfEngine State
        {
            get
            {
                lock (mStateLockObj)
                {
                    return mState;
                }
            }
        }

        protected readonly T Context;
        private readonly ILog mLogger;

        private void OptionsChecker(BaseHostOptions options)
        {
        }

        private void CreateComponents()
        {
        }

        private void InitComponents()
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
            Context.Dispose();
        }
    }
}
