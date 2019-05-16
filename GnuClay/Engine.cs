using GnuClay.Internal;
using GnuClay.Internal.CompillingSystem;
using GnuClay.Internal.EntitiesStorageSystem;
using GnuClay.Internal.IdsStorageSystem;
using GnuClay.Internal.LoggingSystem;
using GnuClay.Internal.LogicalStorageSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay
{
    /// <summary>
    /// The class of instance of GnuClayEngine.
    /// Represents an NPC.
    /// </summary>
    public class Engine: IEngineInternalRef, IDisposable
    {
        /// <summary>
        /// Construct an instance of the class.
        /// </summary>
        /// <param name="options">Options of the engine.</param>
        public Engine(EngineOptions options)
        {
            OptionsChecker(options);

            mContext = new CommonContext();
            mContext.Options = options;
            
            var host = options.Host;
            var internalHostRef = host as IHostControllingRef;
            mContext.HostControllingRef = internalHostRef;
            internalHostRef.SetEngine(this);

            mContext.LoggerComponent = new Logger(mContext);
            mLogger = mContext.LoggerComponent;

            CreateComponents();
            InitComponents();
        }

        private readonly CommonContext mContext;
        private readonly ILog mLogger;

        private readonly object mStateLockObj = new object();
        private StateOfEngine mState = StateOfEngine.Created;

        /// <summary>
        /// Gets state of the engine.
        /// </summary>
        public StateOfEngine State
        {
            get
            {
                lock (mStateLockObj)
                {
                    return mState;
                }
            }
        }

        private void OptionsChecker(EngineOptions options)
        {
            if(options == null)
            {
                throw new NullReferenceException($"Options of the engine is null.");
            }

            if(options.Host == null)
            {
                throw new NullReferenceException($"Host of the engine is null.");
            }

            //if (string.IsNullOrWhiteSpace(options.AppFileName))
            //{
            //    throw new NullReferenceException($"File name of application of the engine is null or empty.");
            //}
        }

        private void CreateComponents()
        {           
            mContext.CompilerComponent = new Compiler(mContext, mLogger);
            mContext.IdsStorageComponent = new IdsStorage(mContext, mLogger);
            mContext.EntitiesStorageComponent = new EntitiesStorage(mContext, mLogger);
            mContext.LogicalStorageComponent = new LogicalStorage(mContext, mLogger);
        }

        private void InitComponents()
        {
            mContext.InitRefs();
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
        ~Engine()
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
    }
}
