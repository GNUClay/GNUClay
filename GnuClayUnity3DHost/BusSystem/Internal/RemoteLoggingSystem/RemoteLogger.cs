using GnuClay;
using GnuClayUnity3DHost.CommonHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RemoteLoggingSystem
{
    public class RemoteLogger: BaseBusOfHostsLoggedComponent, ILoggingMessagesInRemoteLogger
    {
        public RemoteLogger(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="depth">Depth of Debug level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing debug message.</param>
        // TODO: fix me!
        void ILoggingMessagesInRemoteLogger.Debug(DateTime dateTime, ulong messageId, int threadId, uint depth, string message)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Log level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="depth">Depth of Log level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing log message.</param>
        // TODO: fix me!
        void ILoggingMessagesInRemoteLogger.Log(DateTime dateTime, ulong messageId, int threadId, uint depth, string message)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="depth">Depth of Info level. It needs for controlling level of detailing for more comfortable showing and debugging.</param>
        /// <param name="message">A string containing an information message.</param>
        // TODO: fix me!
        void ILoggingMessagesInRemoteLogger.Info(DateTime dateTime, ulong messageId, int threadId, uint depth, string message)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Warn level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="message">A string containing description of a warning.</param>
        // TODO: fix me!
        void ILoggingMessagesInRemoteLogger.Warn(DateTime dateTime, ulong messageId, int threadId, string message)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="message">A string containing description of error.</param>
        // TODO: fix me!
        void ILoggingMessagesInRemoteLogger.Error(DateTime dateTime, ulong messageId, int threadId, string message)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="dateTime">Date and time of the message.</param>
        /// <param name="messageId">Unique id of the message.</param>
        /// <param name="threadId">Id of the thread in which was generated the message.</param>
        /// <param name="message">A string containing description of fatal error.</param>
        // TODO: fix me!
        void ILoggingMessagesInRemoteLogger.Fatal(DateTime dateTime, ulong messageId, int threadId, string message)
        {
            //throw new NotImplementedException();
        }
    }
}
