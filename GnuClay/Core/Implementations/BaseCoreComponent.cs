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
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        protected void Debug(string message)
        {
            Logger?.Debug(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        protected void Debug(uint depth, string message)
        {
            Logger?.Debug(depth, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Debug(Exception exception)
        {
            Logger?.Debug(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">A string containing debug message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Debug(string message, Exception exception)
        {
            Logger?.Debug(message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Debug(uint depth, Exception exception)
        {
            Logger?.Debug(depth, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Debug(uint depth, string message, Exception exception)
        {
            Logger?.Debug(depth, message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        protected void Log(string message)
        {
            Logger?.Log(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        protected void Log(uint depth, string message)
        {
            Logger?.Log(depth, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Log(Exception exception)
        {
            Logger?.Log(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="message">A string containing log message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Log(string message, Exception exception)
        {
            Logger?.Log(message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Log(uint depth, Exception exception)
        {
            Logger?.Log(depth, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Log(uint depth, string message, Exception exception)
        {
            Logger?.Log(depth, message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        protected void Info(string message)
        {
            Logger?.Info(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        protected void Info(uint depth, string message)
        {
            Logger?.Info(depth, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="exception"></param>
        [MethodForLoggingSupport]
        protected void Info(Exception exception)
        {
            Logger?.Info(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">A string containing description of .</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Info(string message, Exception exception)
        {
            Logger?.Info(message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Info(uint depth, Exception exception)
        {
            Logger?.Info(depth, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Info(uint depth, string message, Exception exception)
        {
            Logger?.Info(depth, message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">A string containing description of a warning.</param>
        [MethodForLoggingSupport]
        protected void Warn(string message)
        {
            Logger?.Warn(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Warn(Exception exception)
        {
            Logger?.Warn(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">A string containing description of error.</param>
        [MethodForLoggingSupport]
        protected void Error(string message)
        {
            Logger?.Error(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Error(Exception exception)
        {
            Logger?.Error(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">A string containing description of fatal error.</param>
        [MethodForLoggingSupport]
        protected void Fatal(string message)
        {
            Logger?.Fatal(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        protected void Fatal(Exception exception)
        {
            Logger?.Fatal(exception);
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
