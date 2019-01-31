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
        /// Adds a component of GnuClay engine to the context for initialization and releasing.
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(BaseEngineComponent component)
        {
            mComponentList.Add(component);
        }

        private readonly List<BaseEngineComponent> mComponentList = new List<BaseEngineComponent>();

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
        ~CommonContext()
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
            lock(IsDisposedLockObj)
            {
                if(IsDisposed)
                {
                    return;
                }

                IsDisposed = true;
            }

            if(disposing)
            {
                foreach(var item in mComponentList)
                {
                    item.Dispose();
                }
            }
        }
    }
}
