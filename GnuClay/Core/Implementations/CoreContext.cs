using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations
{
    public sealed class CoreContext: ICoreContextInternalRef, ICoreContext
    {
        public CoreContext(ILog logger, IRemoteDebug remoteDebug)
        {
            Logger = logger;
            RemoteDebugger = remoteDebug;
        }

        void ICoreContextInternalRef.AddComponent(ICoreComponent component)
        {
            if(mComponentsList.Contains(component))
            {
                return;
            }

            mComponentsList.Add(component);

            var kindOfComponent = component.KindOfComponent;

            switch (kindOfComponent)
            {
                case KindOfCoreComponent.CoreLogicalStorage:
                    mCoreLogicalStorage = component as ICoreLogicalStorageComponent;
                    break;

                case KindOfCoreComponent.CoreExecutingSystem:
                    mCoreExecutingSystem = component as ICoreExecutingSystemComponent;
                    break;

                case KindOfCoreComponent.CoreObjectsRegistry:
                    mCoreObjectsRegistry = component as ICoreObjectsRegistryComponent;
                    break;

                case KindOfCoreComponent.CoreScopesRegistry:
                    mCoreScopesRegistry = component as ICoreScopesRegistryComponent;
                    break;

                case KindOfCoreComponent.CoreFunctionsRegistry:
                    mCoreFunctionsRegistry = component as ICoreFunctionsRegistryComponent;
                    break;

                case KindOfCoreComponent.CoreTriggersRegistry:
                    mCoreTriggersRegistry = component as ICoreTriggersRegistryComponent;
                    break;

                case KindOfCoreComponent.CoreProcessesRegistry:
                    mCoreProcessesRegistry = component as ICoreProcessesRegistryComponent;
                    break;

                case KindOfCoreComponent.CoreExternalResources:
                    mCoreExternalResources = component as ICoreExternalResourcesComponent;
                    break;

                case KindOfCoreComponent.CoreCompiler:
                    mCoreCompiler = component as ICoreCompilerComponent;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(kindOfComponent), kindOfComponent, null);
            }
        }
        
        private List<ICoreComponent> mComponentsList = new List<ICoreComponent>();

        private ICoreLogicalStorageComponent mCoreLogicalStorage;

        public ICoreLogicalStorageComponent CoreLogicalStorage
        {
            get
            {
                return mCoreLogicalStorage;
            }
        }

        private ICoreExecutingSystemComponent mCoreExecutingSystem;
        public ICoreExecutingSystemComponent CoreExecutingSystem
        {
            get
            {
                return mCoreExecutingSystem;
            }
        }

        private ICoreObjectsRegistryComponent mCoreObjectsRegistry;
        public ICoreObjectsRegistryComponent CoreObjectsRegistry
        {
            get
            {
                return mCoreObjectsRegistry;
            }
        }

        private ICoreScopesRegistryComponent mCoreScopesRegistry;
        public ICoreScopesRegistryComponent CoreScopesRegistry
        {
            get
            {
                return mCoreScopesRegistry;
            }
        }

        private ICoreFunctionsRegistryComponent mCoreFunctionsRegistry;
        public ICoreFunctionsRegistryComponent CoreFunctionsRegistry
        {
            get
            {
                return mCoreFunctionsRegistry;
            }
        }

        private ICoreTriggersRegistryComponent mCoreTriggersRegistry;
        public ICoreTriggersRegistryComponent CoreTriggersRegistry
        {
            get
            {
                return mCoreTriggersRegistry;
            }
        }

        private ICoreProcessesRegistryComponent mCoreProcessesRegistry;
        public ICoreProcessesRegistryComponent CoreProcessesRegistry
        {
            get
            {
                return mCoreProcessesRegistry;
            }
        }

        private ICoreExternalResourcesComponent mCoreExternalResources;
        public ICoreExternalResourcesComponent CoreExternalResources
        {
            get
            {
                return mCoreExternalResources;
            }
        }

        private ICoreCompilerComponent mCoreCompiler;
        public ICoreCompilerComponent CoreCompiler
        {
            get
            {
                return mCoreCompiler;
            }
        }

        public ILog Logger { get; private set; }
        public IRemoteDebug RemoteDebugger { get; private set; }

        public void InitRefsToOtherComponents()
        {
            CheckExistingOfAllRequiredComponents();

            foreach (var component in mComponentsList)
            {
                component.InitRefsToOtherComponents();
            }
        }

        private void CheckExistingOfAllRequiredComponents()
        {
            CheckExistingOfRequiredComponent(mCoreLogicalStorage, KindOfCoreComponent.CoreLogicalStorage);
            CheckExistingOfRequiredComponent(mCoreExecutingSystem, KindOfCoreComponent.CoreExecutingSystem);
            CheckExistingOfRequiredComponent(mCoreObjectsRegistry, KindOfCoreComponent.CoreObjectsRegistry);
            CheckExistingOfRequiredComponent(mCoreScopesRegistry, KindOfCoreComponent.CoreScopesRegistry);
            CheckExistingOfRequiredComponent(mCoreFunctionsRegistry, KindOfCoreComponent.CoreFunctionsRegistry);
            CheckExistingOfRequiredComponent(mCoreTriggersRegistry, KindOfCoreComponent.CoreTriggersRegistry);
            CheckExistingOfRequiredComponent(mCoreProcessesRegistry, KindOfCoreComponent.CoreProcessesRegistry);
            CheckExistingOfRequiredComponent(mCoreExternalResources, KindOfCoreComponent.CoreExternalResources);
            CheckExistingOfRequiredComponent(mCoreCompiler, KindOfCoreComponent.CoreCompiler);

            if(Logger == null)
            {
                throw new NullReferenceException("Core component Logger is null.");
            }

            if(RemoteDebugger == null)
            {
                throw new NullReferenceException("Core component RemoteDebugger is null.");
            }
        }

        private void CheckExistingOfRequiredComponent(ICoreComponent component, KindOfCoreComponent kindOfComponent)
        {
            if(component == null)
            {
                throw new NullReferenceException($"Core component {kindOfComponent} is null.");
            }
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Dispose()
        {
            lock (IsDisposedLockObj)
            {
                if (mIsDisposed)
                {
                    return;
                }

                mIsDisposed = true;
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for this instance.
        /// </summary>
        ~CoreContext()
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
        public bool IsDisposed
        {
            get
            {
                lock (IsDisposedLockObj)
                {
                    return mIsDisposed;
                }
            }
        }

        private bool mIsDisposed;
        private readonly object IsDisposedLockObj = new object();

        /// <summary>
        ///  Dispose this instance.
        /// </summary>
        /// <param name="disposing">Is the instance released not in finalizer.</param>
        private void Dispose(bool disposing)
        {
            foreach (var component in mComponentsList)
            {
                component.Dispose();
            }
        }
    }
}
