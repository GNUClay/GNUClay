﻿using System;
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

        /// <summary>
        /// Returns true if logging is enabled, otherwise returns false.
        /// Set true for enable logging, otherwise set false.
        /// It controls logging of bus only.
        /// It doesn't control logging of hosts.
        /// </summary>
        public bool EnableLoggingOnBusOnly
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

        /// <summary>
        /// Returns current image.
        /// </summary>
        // TODO: fix me!
        public Image CurentImage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns true if the bus and its hosts is running, otherwise returns false.
        /// </summary>
        // TODO: fix me!
        public bool IsRunning
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Loads the bus and its hosts based on target image called on image name.
        /// The bus will not start after loading. 
        /// You can make it later.
        /// </summary>
        /// <param name="imageName">Name of target image.</param>
        // TODO: fix me!
        public void Load(string imageName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the bus and its hosts based on current image or source files (if still there are not images).
        /// Creates new image if still there are not images.
        /// </summary>
        // TODO: fix me!
        public void Start()
        {
#if DEBUG
            mLogger.Info("Begin");
#endif

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the bus and its hosts based on target image called on image name.
        /// </summary>
        /// <param name="imageName">Name of target image.</param>
        // TODO: fix me!
        public void Start(string imageName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the bus and its hosts without saving its states to current image.
        /// </summary>
        // TODO: fix me!
        public void Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves state of the bus and its hosts to current image.
        /// </summary>
        // TODO: fix me!
        public void Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves state of the bus and its hosts to target image called on image name.
        /// If target image doesn't exist it will be created otherwise existing image will be rewritten.
        /// </summary>
        /// <param name="imageName">Name of target image.</param>
        /// <param name="setNewImageAsCurrent">Set true if you need set new image as current, otherwise set false.</param>
        // TODO: fix me!
        public void Save(string imageName, bool setNewImageAsCurrent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the bus and its hosts and saves their to current image.
        /// </summary>
        // TODO: fix me!
        public void StopAndSave()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the bus and its hosts and saves their to target image called on image name.
        /// If target image doesn't exist it will be created otherwise existing image will be rewritten.
        /// </summary>
        /// <param name="imageName">Name of target image.</param>
        /// <param name="setNewImageAsCurrent">Set true if you need set new image as current, otherwise set false.</param>
        // TODO: fix me!
        public void StopAndSave(string imageName, bool setNewImageAsCurrent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all available images on the base directory.
        /// </summary>
        /// <returns>List of all available images on the base directory.</returns>
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
