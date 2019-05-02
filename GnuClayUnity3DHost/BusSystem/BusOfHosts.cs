using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GnuClay;
using GnuClay.CommonHelpers.FileHelpers;
using GnuClayUnity3DHost.BusSystem.Internal;
using GnuClayUnity3DHost.BusSystem.Internal.IdsStorageSystem;
using GnuClayUnity3DHost.BusSystem.Internal.LoggingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RegistryOfHostSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RemoteLoggingSystem;
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

            var pathResolver = new PathResolver();
            mContext.BaseDir = pathResolver.Resolve(options.BaseDir);
            mContext.SharedPackagesDir = pathResolver.Resolve(options.SharedPackagesDir, mContext.BaseDir);
            mContext.AppsDir = pathResolver.Resolve(options.AppsDir, mContext.BaseDir);
            mContext.ParsedItemsDir = pathResolver.Resolve(options.ParsedItemsDir, mContext.BaseDir);
            mContext.IndexedItemsDir = pathResolver.Resolve(options.IndexedItemsDir, mContext.BaseDir);
            mContext.ImagesDir = pathResolver.Resolve(options.ImagesDir, mContext.BaseDir);

            CreatePathsIfNotExist();

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

            if(string.IsNullOrWhiteSpace(options.SharedPackagesDir))
            {
                throw new NullReferenceException($"SharedPackages directory of bus is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(options.AppsDir))
            {
                throw new NullReferenceException($"Apps directory of bus is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(options.ParsedItemsDir))
            {
                throw new NullReferenceException($"ParsedItems directory of bus is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(options.IndexedItemsDir))
            {
                throw new NullReferenceException($"IndexedItems directory of bus is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(options.ImagesDir))
            {
                throw new NullReferenceException($"Images directory of bus is null or empty.");
            }
        }

        private void CreatePathsIfNotExist()
        {
            if (!Directory.Exists(mContext.BaseDir))
            {
                Directory.CreateDirectory(mContext.BaseDir);
            }

            if (!Directory.Exists(mContext.SharedPackagesDir))
            {
                Directory.CreateDirectory(mContext.SharedPackagesDir);
            }

            if (!Directory.Exists(mContext.AppsDir))
            {
                Directory.CreateDirectory(mContext.AppsDir);
            }

            if (!Directory.Exists(mContext.ParsedItemsDir))
            {
                Directory.CreateDirectory(mContext.ParsedItemsDir);
            }

            if (!Directory.Exists(mContext.IndexedItemsDir))
            {
                Directory.CreateDirectory(mContext.IndexedItemsDir);
            }

            if (!Directory.Exists(mContext.ImagesDir))
            {
                Directory.CreateDirectory(mContext.ImagesDir);
            }
        }

        private void CreateComponents()
        {
            mContext.RemoteLoggerComponent = new RemoteLogger(mContext, mLogger);
            mContext.RegistryOfHostComponent = new RegistryOfHost(mContext, mLogger);
            mContext.IdsStorageComponent = new IdsStorage(mContext, mLogger);
        }

        private void InitComponents()
        {
            mContext.InitStep1();
        }

        void IBusOfHostsInternalRef.AddHost(IHostInternalRef host)
        {
            mContext.RegistryOfHostComponent.AddHost(host);
        }

        public bool Enable
        {
            get
            {
                return mContext.LoggerComponent.Enable;
            }

            set
            {
                mContext.LoggerComponent.Enable = value;
            }
        }

        // TODO: fix me!
        public void Start()
        {
#if DEBUG
            mLogger.Info("Begin");
#endif

            //throw new NotImplementedException();
        }

        // TODO: fix me!
        public void Stop()
        {
            throw new NotImplementedException();
        }

        // TODO: fix me!
        public IList<Image> GetAllImages()
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
