using GnuClayUnity3DHost.BusSystem.Internal.CommonScriptExecutingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.IdsStorageSystem;
using GnuClayUnity3DHost.BusSystem.Internal.ImagesStorageSystem;
using GnuClayUnity3DHost.BusSystem.Internal.LoadingFromSourceCode;
using GnuClayUnity3DHost.BusSystem.Internal.LoggingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RegistryOfHostSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RemoteLoggingSystem;
using GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal
{
    public sealed class CommonContextOfBusOfHosts: IDisposable
    {
        public BusOfHostsOptions Options { get; set; }

        public string BaseDir { get; set; }
        public string SharedPackagesDir { get; set; }
        public string DevSharedPackagesDir { get; set; }
        public string AppsDir { get; set; }
        public string BusAppDir { get; set; }
        public string ImagesDir { get; set; }
        public string CurrentImageName { get; set; }
        public string CurrentImageDir { get; set; }
        public string CurrentImageBusDir { get; set; }
        public string CurrentImageBusParsedFilesDir { get; set; }
        public string CurrentImageBusIndexFilesDir { get; set; }

        public LoggingSettings LoggingSettings { get; set; } = new LoggingSettings();

        public IBusOfHostsControllingRef BusOfHostsControllingRef { get; set; }

        /// <summary>
        /// Adds a component of bus to the context for initialization and releasing.
        /// </summary>
        /// <param name="component">Reference to added component.</param>
        public void AddComponent(BaseBusOfHostsComponent component)
        {
            mComponentList.Add(component);
        }

        private readonly List<BaseBusOfHostsComponent> mComponentList = new List<BaseBusOfHostsComponent>();

        /// <summary>
        /// Reference to component for logging.
        /// </summary>
        public Logger LoggerComponent { get; set; }
        public RemoteLogger RemoteLoggerComponent { get; set; }
        public ImagesStorage ImagesStorageComponent { get; set; }
        public RegistryOfHost RegistryOfHostComponent { get; set; }
        public IdsStorage IdsStorageComponent { get; set; }
        public RuntimeSettingsStorage RunTimeSettingsStorageComponent { get; set; }
        public LoaderFromSourceCode LoaderFromSourceCodeComponent { get; set; }
        public CommonScriptExecutor CommonScriptExecutorComponent { get; set; }

        /// <summary>
        /// Gets references to other components. 
        /// </summary>
        public void InitStep1()
        {
            foreach(var component in mComponentList)
            {
                component.InitStep1();
            }
        }

        public void OnInitedImageDirs()
        {
            foreach (var component in mComponentList)
            {
                component.OnInitedImageDirs();
            }
        }

        public void OnLoading()
        {
            foreach (var component in mComponentList)
            {
                component.OnLoading();
            }
        }

        public void OnLoaded()
        {
            foreach (var component in mComponentList)
            {
                component.OnLoaded();
            }
        }

        public void OnSaving()
        {
            foreach (var component in mComponentList)
            {
                component.OnSaving();
            }
        }

        public void OnSaved()
        {
            foreach (var component in mComponentList)
            {
                component.OnSaved();
            }
        }

        public void OnClearing()
        {
            foreach (var component in mComponentList)
            {
                component.OnClearing();
            }
        }

        public void OnCleared()
        {
            foreach (var component in mComponentList)
            {
                component.OnCleared();
            }
        }

        public void OnStarting()
        {
            foreach (var component in mComponentList)
            {
                component.OnStarting();
            }
        }

        public void OnStarted()
        {
            foreach (var component in mComponentList)
            {
                component.OnStarted();
            }
        }

        public void OnStopping()
        {
            foreach (var component in mComponentList)
            {
                component.OnStopping();
            }
        }

        public void OnStopped()
        {
            foreach (var component in mComponentList)
            {
                component.OnStopped();
            }
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for this instance.
        /// </summary>
        ~CommonContextOfBusOfHosts()
        {
            Dispose(false);
        }

        /// <summary>
        /// Returns true if the instance was released, owerthise returns false.
        /// </summary>
        public bool IsDisposed { get; private set; }

        private readonly object IsDisposedLockObj = new object();

        private void Dispose(bool disposing)
        {
            foreach (var item in mComponentList)
            {
                item.Dispose();
            }
        }
    }
}
