using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GnuClay;
using GnuClay.CommonHelpers.FileHelpers;
using GnuClayUnity3DHost.BusSystem.Internal;
using GnuClayUnity3DHost.BusSystem.Internal.CommonScenarios;
using GnuClayUnity3DHost.BusSystem.Internal.CommonScriptExecutingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.IdsStorageSystem;
using GnuClayUnity3DHost.BusSystem.Internal.ImagesStorageSystem;
using GnuClayUnity3DHost.BusSystem.Internal.LoadingFromSourceCode;
using GnuClayUnity3DHost.BusSystem.Internal.LoggingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RegistryOfHostSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RemoteLoggingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem;
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

            mContext.BusAppDir = Path.Combine(mContext.AppsDir, "Bus");

            mContext.ImagesDir = pathResolver.Resolve(options.ImagesDir, mContext.BaseDir);

            CreatePathsIfNotExist();

            mContext.LoggerComponent = new Logger(mContext);
            mLogger = mContext.LoggerComponent;

            CreateComponents();
            InitComponents();
        }

        private readonly object mStateLockObj = new object();
        private StateOfEngine mState = StateOfEngine.Created;

        /// <summary>
        /// Gets state of the bus.
        /// </summary>
        public StateOfEngine State
        {
            get
            {
                lock(mStateLockObj)
                {
                    return mState;
                }
            }
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

            if(!Directory.Exists(mContext.BusAppDir))
            {
                Directory.CreateDirectory(mContext.BusAppDir);
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
            mContext.RunTimeSettingsStorageComponent = new RuntimeSettingsStorage(mContext, mLogger);
            mContext.ImagesStorageComponent = new ImagesStorage(mContext, mLogger);
            mContext.LoaderFromSourceCodeComponent = new LoaderFromSourceCode(mContext, mLogger);
            mContext.CommonScriptExecutorComponent = new CommonScriptExecutor(mContext, mLogger);
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
        public Image CurentImage
        {
            get
            {
                return mContext.ImagesStorageComponent.CurentImage;
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
        public void Start()
        {
#if DEBUG
            mLogger.Info("Begin");
#endif

            switch(mState)
            {
                case StateOfEngine.Created:
                    NLoad();
                    NStart();
                    break;

                case StateOfEngine.Loaded:
                    NStart();
                    break;

                case StateOfEngine.Started:
                case StateOfEngine.Starting:
                case StateOfEngine.Stopping:
                case StateOfEngine.Stopped:
                case StateOfEngine.Destroyed:
                case StateOfEngine.Compiling:
                case StateOfEngine.Compiled:
                    return;

                default:
                    throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
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
        /// This image will be stopped before saving.
        /// </summary>
        // TODO: fix me!
        public void Save()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves state of the bus and its hosts to target image called on image name.
        /// If target image doesn't exist it will be created otherwise existing image will be rewritten.
        /// This image will be stopped before saving.
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
        /// Clears all information into current image without its deleting.
        /// This image will be stopped before cleaning.
        /// After starting this image will be initialized from source files.
        /// </summary>
        // TODO: fix me!
        public void ClearImage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears all information into target image called on image name without its deleting.
        /// This image will be stopped before cleaning.
        /// After starting this image will be initialized from source files.
        /// </summary>
        /// <param name="imageName">Name of target image.</param>
        // TODO: fix me!
        public void ClearImage(string imageName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes current image.
        /// This image will be stopped before cleaning.
        /// </summary>
        // TODO: fix me!
        public void RemoveImage()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes target image called on image name.
        /// </summary>
        /// <param name="imageName">Name of target image.</param>
        // TODO: fix me!
        public void RemoveImage(string imageName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all available images on the base directory.
        /// </summary>
        /// <returns>List of all available images on the base directory.</returns>
        public IList<Image> GetAllImages()
        {
            return mContext.ImagesStorageComponent.GetAllImages();
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
        ~BusOfHosts()
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
                lock (mStateLockObj)
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
            mContext?.Dispose();
        }

        #region private members
        private void NLoad()
        {
            mContext.ImagesStorageComponent.InitFromOptions();

            var nameOfCurrentImage = mContext.CurrentImageName;

#if DEBUG
            mLogger.Debug($"nameOfCurrentImage = {nameOfCurrentImage}");
#endif

            var needCompiling = false;

            if (string.IsNullOrWhiteSpace(nameOfCurrentImage))
            {
                mContext.ImagesStorageComponent.CreateNewImageAndSetAsCurrent();
                needCompiling = true;
            }
            else
            {
                mContext.ImagesStorageComponent.InitDirectoriesOfImages();
            }

            mContext.OnInitedImageDirs();

#if DEBUG
            mLogger.Debug($"needCompiling = {needCompiling}");
#endif

            if(needCompiling)
            {
                mContext.LoaderFromSourceCodeComponent.Load();
            }
            else
            {
                mContext.OnLoading();
                mContext.OnLoaded();
            }

            mContext.RegistryOfHostComponent.Load();
        }

        private void NStart()
        {
            mContext.RegistryOfHostComponent.PrepareForStarting();
            mContext.CommonScriptExecutorComponent.Start();
        }
        #endregion
    }
}
