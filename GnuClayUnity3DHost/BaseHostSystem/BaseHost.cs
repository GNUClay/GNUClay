using GnuClay;
using GnuClayUnity3DHost.BusSystem;
using GnuClayUnity3DHost.BaseHostSystem.Internal;
using GnuClayUnity3DHost.BaseHostSystem.Internal.LoggingSystem;
using System;
using System.Collections.Generic;
using System.Text;
using GnuClayUnity3DHost.BaseHostSystem.Internal.RemoteLoggingSystem;

namespace GnuClayUnity3DHost.BaseHostSystem
{
    public abstract class BaseHost<T>: IHost, IHostInternalRef, IDisposable where T: CommonContextOfBaseHost, new()
    {
        protected BaseHost(BaseHostOptions options)
        {
            OptionsChecker(options);

            Context = new T();
            Context.Options = options;
            Context.Name = options.Name;

            var internalRef = options.Bus as IBusOfHostsInternalRef;
            internalRef.AddHost(this);

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
            if (string.IsNullOrWhiteSpace(options.Name))
            {
                throw new NullReferenceException($"Name of host is null or empty.");
            }
        }

        private void CreateComponents()
        {
            Context.RemoteLoggerComponent = new RemoteLogger(Context, mLogger);
        }

        private void InitComponents()
        {
            Context.InitStep1();
        }

        void IHostInternalRef.SetBusOfHostsControllingRef(IBusOfHostsControllingRef busOfHostsControllingRef)
        {
            Context.BusOfHostsControllingRef = busOfHostsControllingRef;
        }

        /// <summary>
        /// Returns true if logging is enabled, otherwise returns false.
        /// Set true for enable logging, otherwise set false.
        /// It controls logging of the host only.
        /// </summary>
        public bool EnableLoggingOfHostOnly
        {
            get
            {
                return Context.LoggerComponent.Enable;
            }

            set
            {
                Context.LoggerComponent.Enable = value;
            }
        }

        // TODO: fix me!
        void IHostInternalRef.OnInitedImageDirs()
        {
#if DEBUG
            mLogger.Debug("Begin");
#endif
        }

        // TODO: fix me!
        void IHostInternalRef.Load()
        {
#if DEBUG
            mLogger.Debug("Begin");
#endif
        }

        // TODO: fix me!
        void IHostInternalRef.Clear()
        {
#if DEBUG
            mLogger.Debug("Begin");
#endif
        }

        // TODO: fix me!
        void IHostInternalRef.PrepareForStarting()
        {
#if DEBUG
            mLogger.Debug("Begin");
#endif
        }

        // TODO: fix me!
        void IHostInternalRef.ProcessStopping()
        {
#if DEBUG
            mLogger.Debug("Begin");
#endif
        }

        // TODO: fix me!
        void IHostInternalRef.Save()
        {
#if DEBUG
            mLogger.Debug("Begin");
#endif
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Dispose()
        {
            lock (mStateLockObj)
            {
                if (mState == StateOfEngine.Destroyed)
                {
                    return;
                }

                mState = StateOfEngine.Destroyed;
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for this instance.
        /// </summary>
        ~BaseHost()
        {
            if (mState == StateOfEngine.Destroyed)
            {
                return;
            }

            Dispose(false);
        }

        /// <summary>
        /// Returns true if the instance was released, owerthise returns false.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                lock(mStateLockObj)
                {
                    return mState == StateOfEngine.Destroyed;
                }
            }
        }

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
