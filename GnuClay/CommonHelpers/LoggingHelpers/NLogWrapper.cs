using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.LoggingHelpers
{
    public sealed class NLogWrapper: IDisposable
    {
        public NLogWrapper(NLogWrapperOptions options)
        {
            OptionsChecker(options);
        }

        private void OptionsChecker(NLogWrapperOptions options)
        {

        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        public void Debug(uint depth, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        public void Log(uint depth, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        public void Info(uint depth, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">A string containing description of a warning.</param>
        [MethodForLoggingSupport]
        public void Warn(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">A string containing description of error.</param>
        [MethodForLoggingSupport]
        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">A string containing description of fatal error.</param>
        [MethodForLoggingSupport]
        public void Fatal(string message)
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
        ~NLogWrapper()
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
        private void Dispose(bool disposing)
        {
        }
    }
}
