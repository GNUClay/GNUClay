using GnuClay.Internal;
using GnuClay.Internal.Compilling;
using GnuClay.Internal.EntitiesStorages;
using GnuClay.Internal.IdsStorages;
using GnuClay.Internal.Logging;
using GnuClay.Internal.LogicalStorages;
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
            mOptions = options;

            OptionsChecker();

            mContext = new CommonContext();
            mContext.EngineOptions = options;
            mContext.LoggerComponent = new Logger(mContext);
            mLogger = mContext.LoggerComponent;

            CreateComponents();
            InitComponents();
        }

        private readonly EngineOptions mOptions;
        private readonly CommonContext mContext;
        private readonly ILog mLogger;

        private void OptionsChecker()
        {
            if(mOptions == null)
            {
                throw new NullReferenceException($"Options of the engine is null.");
            }

            if(mOptions.Host == null)
            {
                throw new NullReferenceException($"Host of the engine is null.");
            }

            if (string.IsNullOrWhiteSpace(mOptions.AppFileName))
            {
                throw new NullReferenceException($"File name of application of the engine is null or empty.");
            }
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

        }

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
        ~Engine()
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
            if(disposing)
            {
                mContext?.Dispose();
            }
        }
    }
}
