using GnuClay;
using GnuClay.CommonHelpers.LoggingHelpers;
using GnuClayUnity3DHost.CommonHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace TmpSandBox
{
    public class LogImplForNLog: ILog
    {
        public LogImplForNLog(ILoggingMessagesInRemoteLogger remoteLogger = null)
        {
            mRemoteLogger = remoteLogger;
            mNlogLogger = LogManager.GetCurrentClassLogger();
        }

        private ILoggingMessagesInRemoteLogger mRemoteLogger;
        private readonly Logger mNlogLogger;

        private bool mEnable;
        private readonly object mEnableLockObj = new object();

        public bool Enable
        {
            get
            {
                lock (mEnableLockObj)
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
            lock (mCurrentMessageIdLockObj)
            {
                if (mCurrentMessageId == ulong.MaxValue)
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

            //Task.Run(() => {
                message = LogHelper.BuildLogString(now, KindOfLogLevel.DEBUG.ToString(), messageId, threadId, depth, message);
                mNlogLogger.Debug(message);

                mRemoteLogger?.Debug(now, messageId, threadId, depth, message);
            //});
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

            //Task.Run(() => {
                message = LogHelper.BuildLogString(now, KindOfLogLevel.LOG.ToString(), messageId, threadId, depth, message);
                mNlogLogger.Info(message);
                mRemoteLogger?.Log(now, messageId, threadId, depth, message);
            //});
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

            //Task.Run(() => {
                message = LogHelper.BuildLogString(now, KindOfLogLevel.INFO.ToString(), messageId, threadId, depth, message);
                mNlogLogger.Info(message);
                mRemoteLogger?.Info(now, messageId, threadId, depth, message);
            //});
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

            //Task.Run(() => {
                message = LogHelper.BuildLogString(now, KindOfLogLevel.WARNING.ToString(), messageId, threadId, ConstantsForLogging.DEFAULT_DEPTH, message);
                mNlogLogger.Warn(message);
                mRemoteLogger?.Warn(now, messageId, threadId, message);
            //});
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

            //Task.Run(() => {
                message = LogHelper.BuildLogString(now, KindOfLogLevel.ERROR.ToString(), messageId, threadId, ConstantsForLogging.DEFAULT_DEPTH, message);
                mNlogLogger.Error(message);
                mRemoteLogger?.Error(now, messageId, threadId, message);
            //});
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

            //Task.Run(() => {
                message = LogHelper.BuildLogString(now, KindOfLogLevel.FATAL.ToString(), messageId, threadId, ConstantsForLogging.DEFAULT_DEPTH, message);
                mNlogLogger.Fatal(message);
                mRemoteLogger?.Fatal(now, messageId, threadId, message);
            //});
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
    }
}
