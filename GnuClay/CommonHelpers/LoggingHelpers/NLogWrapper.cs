using NLog;
using NLog.Config;
using NLog.Targets;
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

            var config = new LoggingConfiguration();

            if(options.UseLoggingToConsole)
            {
                var consoleTarget = new ConsoleTarget();
                consoleTarget.Name = "console";
                consoleTarget.Layout = "${message}";

                config.AddTarget(consoleTarget);
                config.AddRuleForAllLevels(consoleTarget);
            }

            if(options.UseLoggingToFile)
            {
                var fileTarget = new FileTarget();
                fileTarget.Name = "logfile";
                fileTarget.Layout = "${message}";
                fileTarget.FileName = options.FileName;
                fileTarget.DeleteOldFileOnStartup = options.DeleteOldFileOnStartup;
                fileTarget.Encoding = Encoding.UTF8;

                config.AddTarget(fileTarget);
                config.AddRuleForAllLevels(fileTarget);
            }

            var logFactory = new LogFactory(config);

            mNlogLogger = logFactory.GetCurrentClassLogger();
        }

        private void OptionsChecker(NLogWrapperOptions options)
        {

        }

        private readonly Logger mNlogLogger;

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        public void Debug(DateTime dateTime, ulong messageId, int threadId, uint depth, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        public void Log(DateTime dateTime, ulong messageId, int threadId, uint depth, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        public void Info(DateTime dateTime, ulong messageId, int threadId, uint depth, string message)
        {
            message = LogHelper.BuildLogString(dateTime, KindOfLogLevel.INFO.ToString(), messageId, threadId, depth, message);

            mNlogLogger.Info(message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="message">A string containing description of a warning.</param>
        [MethodForLoggingSupport]
        public void Warn(DateTime dateTime, ulong messageId, int threadId, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="message">A string containing description of error.</param>
        [MethodForLoggingSupport]
        public void Error(DateTime dateTime, ulong messageId, int threadId, string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="message">A string containing description of fatal error.</param>
        [MethodForLoggingSupport]
        public void Fatal(DateTime dateTime, ulong messageId, int threadId, string message)
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
