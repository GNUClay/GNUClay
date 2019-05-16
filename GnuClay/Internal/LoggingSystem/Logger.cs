using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal.LoggingSystem
{
    public class Logger: BaseEngineComponent, ILog
    {
        public Logger(CommonContext context)
            : base(context, null)
        {
            Logger = this;
            mHostLogger = context.HostControllingRef.Logger;
        }

        private ILog mHostLogger;

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        public void Debug(string message)
        {
            mHostLogger.Debug(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        public void Debug(uint depth, string message)
        {
            mHostLogger.Debug(depth, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Debug(Exception exception)
        {
            mHostLogger.Debug(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">A string containing debug message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Debug(string message, Exception exception)
        {
            mHostLogger.Debug(message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Debug(uint depth, Exception exception)
        {
            mHostLogger.Debug(depth, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Debug(uint depth, string message, Exception exception)
        {
            mHostLogger.Debug(depth, message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        public void Log(string message)
        {
            mHostLogger.Log(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        public void Log(uint depth, string message)
        {
            mHostLogger.Log(depth, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Log(Exception exception)
        {
            mHostLogger.Log(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="message">A string containing log message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Log(string message, Exception exception)
        {
            mHostLogger.Log(message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Log(uint depth, Exception exception)
        {
            mHostLogger.Log(depth, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Log(uint depth, string message, Exception exception)
        {
            mHostLogger.Log(depth, message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        public void Info(string message)
        {
            mHostLogger.Info(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        public void Info(uint depth, string message)
        {
            mHostLogger.Info(depth, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="exception"></param>
        [MethodForLoggingSupport]
        public void Info(Exception exception)
        {
            mHostLogger.Info(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">A string containing description of .</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Info(string message, Exception exception)
        {
            mHostLogger.Info(message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Info(uint depth, Exception exception)
        {
            mHostLogger.Info(depth, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Info(uint depth, string message, Exception exception)
        {
            mHostLogger.Info(depth, message, exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">A string containing description of a warning.</param>
        [MethodForLoggingSupport]
        public void Warn(string message)
        {
            mHostLogger.Warn(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Warn(Exception exception)
        {
            mHostLogger.Warn(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">A string containing description of error.</param>
        [MethodForLoggingSupport]
        public void Error(string message)
        {
            mHostLogger.Error(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Error(Exception exception)
        {
            mHostLogger.Error(exception);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">A string containing description of fatal error.</param>
        [MethodForLoggingSupport]
        public void Fatal(string message)
        {
            mHostLogger.Fatal(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Fatal(Exception exception)
        {
            mHostLogger.Fatal(exception);
        }
    }
}
