using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.LoggingHelpers
{
    public static class LogHelper
    {
        public static string BuildLogString(string className, string methodName, string message)
        {
            return $"{className}|{methodName}|{message}";
        }

        public static string BuildLogString(DateTime dateTime, string levelName, ulong messageId, int threadId, uint depth, string message)
        {
            return $"{dateTime}|{levelName}|>>{messageId}|{threadId}|{depth}<<|{message}";
        }
    }
}
