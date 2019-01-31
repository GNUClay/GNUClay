using GnuClay.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay
{
    /// <summary>
    /// The class of instance of GnuClayEngine.
    /// Represents an NPC.
    /// </summary>
    public class Engine: IDisposable
    {
        /// <summary>
        /// Construct an instance of the class.
        /// </summary>
        /// <param name="options">Options of the engine.</param>
        public Engine(EngineOptions options)
        {
            mContext = new CommonContext();
        }

        private readonly CommonContext mContext;

        /// <summary>
        /// Start code execution in the NPC.
        /// </summary>
        public void Start()
        {
            throw new NotImplementedException();
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
        ~Engine()
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
            lock (IsDisposedLockObj)
            {
                if (IsDisposed)
                {
                    return;
                }

                IsDisposed = true;
            }

            if(disposing)
            {
                mContext?.Dispose();
            }
        }
    }
}
