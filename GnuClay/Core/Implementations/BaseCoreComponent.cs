using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations
{
    public abstract class BaseCoreComponent : ICoreComponent
    {
        protected BaseCoreComponent(ICoreContext context, KindOfCoreComponent kindOfComponent)
        {
            KindOfComponent = kindOfComponent;
            Context = context;

            var internalRefOfContext = context as ICoreContextInternalRef;
            internalRefOfContext.AddComponent(this);

            Logger = context.Logger;
            RemoteDebugger = context.RemoteDebugger;
        }

        protected ICoreContext Context { get; private set; }
        public KindOfCoreComponent KindOfComponent { get; private set; }

        protected ICoreLogicalStorageComponent CoreLogicalStorage { get; private set; }
        protected ICoreExecutingSystemComponent CoreExecutingSystem { get; private set; }
        protected ICoreObjectsRegistryComponent CoreObjectsRegistry { get; private set; }
        protected ICoreScopesRegistryComponent CoreScopesRegistry { get; private set; }
        protected ICoreFunctionsRegistryComponent CoreFunctionsRegistry { get; private set; }
        protected ICoreTriggersRegistryComponent CoreTriggersRegistry { get; private set; }
        protected ICoreProcessesRegistryComponent CoreProcessesRegistry { get; private set; }
        protected ICoreExternalResourcesComponent CoreExternalResources { get; private set; }
        protected ICoreCompilerComponent CoreCompiler { get; private set; }

        protected ILog Logger { get; private set; }
        protected IRemoteDebug RemoteDebugger { get; private set; }

        public virtual void InitRefsToOtherComponents()
        {
            CoreLogicalStorage = Context.CoreLogicalStorage;
            CoreExecutingSystem = Context.CoreExecutingSystem;
            CoreObjectsRegistry = Context.CoreObjectsRegistry;
            CoreScopesRegistry = Context.CoreScopesRegistry;
            CoreFunctionsRegistry = Context.CoreFunctionsRegistry;
            CoreTriggersRegistry = Context.CoreTriggersRegistry;
            CoreProcessesRegistry = Context.CoreProcessesRegistry;
            CoreExternalResources = Context.CoreExternalResources;
            CoreCompiler = Context.CoreCompiler;
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
        ~BaseCoreComponent()
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
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
