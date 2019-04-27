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
    }
}
