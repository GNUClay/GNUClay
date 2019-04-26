using GnuClay.Internal.CompillingSystem;
using GnuClay.Internal.EntitiesStorageSystem;
using GnuClay.Internal.IdsStorageSystem;
using GnuClay.Internal.LoggingSystem;
using GnuClay.Internal.LogicalStorageSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal
{
    /// <summary>
    /// Common context of the engine.
    /// </summary>
    public sealed class CommonContext: IDisposable
    {
        /// <summary>
        /// Options of the engine.
        /// </summary>
        public EngineOptions Options { get; set; }

        /// <summary>
        /// Adds a component of GnuClay engine to the context for initialization and releasing.
        /// </summary>
        /// <param name="component">Reference to added component.</param>
        public void AddComponent(BaseEngineComponent component)
        {
            mComponentList.Add(component);
        }

        private readonly List<BaseEngineComponent> mComponentList = new List<BaseEngineComponent>();

        /// <summary>
        /// Reference to component for logging.
        /// </summary>
        public Logger LoggerComponent { get; set; }

        /// <summary>
        /// Reference to component for compiller.
        /// </summary>
        public Compiler CompilerComponent { get; set; }
        public IdsStorage IdsStorageComponent { get; set; }
        public EntitiesStorage EntitiesStorageComponent { get; set; }
        public LogicalStorage LogicalStorageComponent { get; set; }

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
        ~CommonContext()
        {
            lock (IsDisposedLockObj)
            {
                if (IsDisposed)
                {
                    return;
                }
            }

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
