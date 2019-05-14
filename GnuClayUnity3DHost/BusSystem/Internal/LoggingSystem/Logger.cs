using GnuClay;
using GnuClay.CommonHelpers.FileHelpers;
using GnuClay.CommonHelpers.LoggingHelpers;
using GnuClayUnity3DHost.CommonHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GnuClayUnity3DHost.BusSystem.Internal.LoggingSystem
{
    public class Logger : BaseBusOfHostsComponent, ILog
    {
        public Logger(CommonContextOfBusOfHosts context)
            : base(context, null)
        {
            Logger = this;

            var loggingOptions = Context.Options.Logging;

            if (loggingOptions != null)
            {
                OptionsChecker();

                mEnable = loggingOptions.EnableLogging;

                var logWrapperOptions = new NLogWrapperOptions();

                if(loggingOptions.UseLoggingToFile)
                {
                    logWrapperOptions.UseLoggingToFile = Context.Options.Logging.UseLoggingToFile;

                    var rewritingModeOnStartup = loggingOptions.RewritingModeOnStartup;

                    var pathResolver = new PathResolver();

                    var loggingDir = pathResolver.Resolve(Context.Options.Logging.LoggingDir, Context.BaseDir);

                    if(!Directory.Exists(loggingDir))
                    {
                        Directory.CreateDirectory(loggingDir);
                    }

                    switch (rewritingModeOnStartup)
                    {
                        case RewritingModeOfLoggingToFileOnStartup.RewriteExistingFile:
                            Context.LoggingSettings.FullLoggingDir = Path.Combine(loggingDir, "Default");
                            logWrapperOptions.DeleteOldFileOnStartup = true;
                            logWrapperOptions.FileName = Path.Combine(Context.LoggingSettings.FullLoggingDir, $"bus.log");
                            break;

                        case RewritingModeOfLoggingToFileOnStartup.WritingToNewDirMarkedByDate:
                            var now = DateTime.Now;

                            Context.LoggingSettings.FilePostfix = now.ToString("yyyy-MM-dd HH_mm_ss_fffffff");
                            Context.LoggingSettings.FullLoggingDir = Path.Combine(loggingDir, Context.LoggingSettings.FilePostfix);
                            logWrapperOptions.DeleteOldFileOnStartup = false;
                            logWrapperOptions.FileName = Path.Combine(Context.LoggingSettings.FullLoggingDir, $"bus_{Context.LoggingSettings.FilePostfix}.log");
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(rewritingModeOnStartup), rewritingModeOnStartup, null);
                    }
                    
                    if(!Directory.Exists(Context.LoggingSettings.FullLoggingDir))
                    {
                        Directory.CreateDirectory(Context.LoggingSettings.FullLoggingDir);
                    }
                }

                logWrapperOptions.UseLoggingToConsole = loggingOptions.UseLoggingToConsole;
                logWrapperOptions.UseLoggingToHostConsole = loggingOptions.UseLoggingToHostConsole;

                mLogWrapper = new NLogWrapper(logWrapperOptions);
            }
        }

        private void OptionsChecker()
        {
            var loggingOptions = Context.Options.Logging;

            if(loggingOptions.UseLoggingToFile)
            {
                if(string.IsNullOrWhiteSpace(loggingOptions.LoggingDir))
                {
                    throw new NullReferenceException($"Logging directory of bus is null or empty.");
                }
            }

            if(loggingOptions.UseRemoteLogging)
            {
                if(string.IsNullOrWhiteSpace(loggingOptions.ContractName))
                {
                    throw new NullReferenceException("Contract name for remote logging of bus is null or empty.");
                }
            }
        }

        public override void InitStep1()
        {
            base.InitStep1();

            mRemoteLogger = Context.RemoteLoggerComponent as ILoggingMessagesInRemoteLogger;
        }

        private readonly NLogWrapper mLogWrapper;
        private ILoggingMessagesInRemoteLogger mRemoteLogger;

        private bool mEnable;
        private readonly object mEnableLockObj = new object();

        public bool Enable
        {
            get
            {
                lock(mEnableLockObj)
                {
                    return mEnable;
                }
            }

            set
            {
                lock (mEnableLockObj)
                {
                    mEnable = value;
                }
            }
        }

        private ulong mCurrentMessageId;
        private readonly object mCurrentMessageIdLockObj = new object();

        private ulong GetCurrentMessageId()
        {
            lock(mCurrentMessageIdLockObj)
            {
                if(mCurrentMessageId == ulong.MaxValue)
                {
                    mCurrentMessageId = 1;
                    return mCurrentMessageId;
                }

                mCurrentMessageId++;
                return mCurrentMessageId;
            }
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        public void Debug(string message)
        {
            Debug(ConstantsForLogging.DEFAULT_DEPTH, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        [MethodForLoggingSupport]
        public void Debug(uint depth, string message)
        {
            lock (mEnableLockObj)
            {
                if (!mEnable)
                {
                    return;
                }
            }

            var threadId = Thread.CurrentThread.ManagedThreadId;
            var messageId = GetCurrentMessageId();
            var now = DateTime.Now;

            var callInfo = DiagnosticsHelper.GetNotLoggingSupportCallInfo();
            message = LogHelper.BuildLogString(callInfo.FullClassName, callInfo.MethodName, message);

            Task.Run(() => {
                mLogWrapper.Debug(now, messageId, threadId, depth, message);
                mRemoteLogger?.Debug(now, messageId, threadId, depth, message);
            });
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Debug(Exception exception)
        {
            Debug(ConstantsForLogging.DEFAULT_DEPTH, exception.ToString());
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">A string containing debug message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Debug(string message, Exception exception)
        {
            Debug(ConstantsForLogging.DEFAULT_DEPTH, $"{message} {exception}");
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Debug(uint depth, Exception exception)
        {
            Debug(depth, exception.ToString());
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
            Debug(depth, $"{message} {exception}");
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        public void Log(string message)
        {
            Log(ConstantsForLogging.DEFAULT_DEPTH, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        [MethodForLoggingSupport]
        public void Log(uint depth, string message)
        {
            lock (mEnableLockObj)
            {
                if (!mEnable)
                {
                    return;
                }
            }

            var threadId = Thread.CurrentThread.ManagedThreadId;
            var messageId = GetCurrentMessageId();
            var now = DateTime.Now;

            var callInfo = DiagnosticsHelper.GetNotLoggingSupportCallInfo();
            message = LogHelper.BuildLogString(callInfo.FullClassName, callInfo.MethodName, message);

            Task.Run(() => {
                mLogWrapper.Log(now, messageId, threadId, depth, message);
                mRemoteLogger?.Log(now, messageId, threadId, depth, message);
            });
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Log(Exception exception)
        {
            Log(ConstantsForLogging.DEFAULT_DEPTH, exception.ToString());
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="message">A string containing log message.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Log(string message, Exception exception)
        {
            Log(ConstantsForLogging.DEFAULT_DEPTH, $"{message} {exception}");
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Log(uint depth, Exception exception)
        {
            Log(depth, exception.ToString());
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
            Log(depth, $"{message} {exception}");
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        public void Info(string message)
        {
            Info(ConstantsForLogging.DEFAULT_DEPTH, message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        [MethodForLoggingSupport]
        public void Info(uint depth, string message)
        {
            lock(mEnableLockObj)
            {
                if (!mEnable)
                {
                    return;
                }
            }

            var threadId = Thread.CurrentThread.ManagedThreadId;
            var messageId = GetCurrentMessageId();
            var now = DateTime.Now;

            var callInfo = DiagnosticsHelper.GetNotLoggingSupportCallInfo();
            message = LogHelper.BuildLogString(callInfo.FullClassName, callInfo.MethodName, message);

            Task.Run(() => {
                mLogWrapper.Info(now, messageId, threadId, depth, message);
                mRemoteLogger?.Info(now, messageId, threadId, depth, message);
            });
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="exception"></param>
        [MethodForLoggingSupport]
        public void Info(Exception exception)
        {
            Info(ConstantsForLogging.DEFAULT_DEPTH, exception.ToString());
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">A string containing description of .</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Info(string message, Exception exception)
        {
            Info(ConstantsForLogging.DEFAULT_DEPTH, $"{message} {exception}");
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Info(uint depth, Exception exception)
        {
            Info(depth, exception.ToString());
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
            Info(depth, $"{message} {exception}");
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="message">A string containing description of a warning.</param>
        [MethodForLoggingSupport]
        public void Warn(string message)
        {
            lock (mEnableLockObj)
            {
                if (!mEnable)
                {
                    return;
                }
            }

            var threadId = Thread.CurrentThread.ManagedThreadId;
            var messageId = GetCurrentMessageId();
            var now = DateTime.Now;

            var callInfo = DiagnosticsHelper.GetNotLoggingSupportCallInfo();
            message = LogHelper.BuildLogString(callInfo.FullClassName, callInfo.MethodName, message);

            Task.Run(() => {
                mLogWrapper.Warn(now, messageId, threadId, message);
                mRemoteLogger?.Warn(now, messageId, threadId, message);
            });
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Warn(Exception exception)
        {
            Warn(exception.ToString());
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">A string containing description of error.</param>
        [MethodForLoggingSupport]
        public void Error(string message)
        {
            lock (mEnableLockObj)
            {
                if (!mEnable)
                {
                    return;
                }
            }

            var threadId = Thread.CurrentThread.ManagedThreadId;
            var messageId = GetCurrentMessageId();
            var now = DateTime.Now;

            var callInfo = DiagnosticsHelper.GetNotLoggingSupportCallInfo();
            message = LogHelper.BuildLogString(callInfo.FullClassName, callInfo.MethodName, message);

            Task.Run(() => {
                mLogWrapper.Error(now, messageId, threadId, message);
                mRemoteLogger?.Error(now, messageId, threadId, message);
            });
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Error(Exception exception)
        {
            Error(exception.ToString());
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">A string containing description of fatal error.</param>
        [MethodForLoggingSupport]
        public void Fatal(string message)
        {
            lock (mEnableLockObj)
            {
                if (!mEnable)
                {
                    return;
                }
            }

            var threadId = Thread.CurrentThread.ManagedThreadId;
            var messageId = GetCurrentMessageId();
            var now = DateTime.Now;

            var callInfo = DiagnosticsHelper.GetNotLoggingSupportCallInfo();
            message = LogHelper.BuildLogString(callInfo.FullClassName, callInfo.MethodName, message);

            Task.Run(() => {
                mLogWrapper.Fatal(now, messageId, threadId, message);
                mRemoteLogger?.Fatal(now, messageId, threadId, message);
            });
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="exception">An exception to be logged.</param>
        [MethodForLoggingSupport]
        public void Fatal(Exception exception)
        {
            Fatal(exception.ToString());
        }

        /// <summary>
        ///  Dispose this instance.
        /// </summary>
        /// <param name="disposing">Is the instance released not in finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            mLogWrapper?.Dispose();
        }
    }
}
