using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal
{
    /// <summary>
    /// Represents a base component of the engine. 
    /// </summary>
    public abstract class BaseEngineComponent: IDisposable
    {
        /// <summary>
        /// Construct an instance of the class.
        /// </summary>
        /// <param name="context">Common context of the engine.</param>
        protected BaseEngineComponent(CommonContext context)
        {
            Context = context;
            context.AddComponent(this);
        }

        /// <summary>
        /// Common context of the engine.
        /// </summary>
        protected readonly CommonContext Context;

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
        ~BaseEngineComponent()
        {
            Dispose(false);
        }

        /// <summary>
        /// Returns true if the instance was released, owerthise returns false.
        /// </summary>
        public bool IsDisposed { get; protected set; }

        /// <summary>
        /// Reference to object for locking field `IsDisposed`.
        /// </summary>
        protected readonly object IsDisposedLockObj = new object();

        /// <summary>
        ///  Dispose this instance.
        /// </summary>
        /// <param name="disposing">Is the instance released not in finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
