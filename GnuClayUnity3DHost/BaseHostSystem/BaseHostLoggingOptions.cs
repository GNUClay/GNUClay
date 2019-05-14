using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BaseHostSystem
{
    public class BaseHostLoggingOptions: IObjectToString
    {
        public bool EnableLogging { get; set; }
        public bool UseLoggingToFile { get; set; }
        public bool UseRemoteLogging { get; set; }
        public string ContractName { get; set; }
        public bool UseLoggingToConsole { get; set; }
        public bool UseLoggingToHostConsole { get; set; }

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>A string that represents the current instance.</returns>
        public override string ToString()
        {
            return ToString(0u);
        }

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance.</returns>
        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        /// <summary>
        /// Internal method which returns a string that represents the current instance without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance without additional information, only pair name of property - value.</returns>
        public string PropertiesToString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(EnableLogging)} = {EnableLogging}");
            sb.AppendLine($"{spaces}{nameof(UseLoggingToFile)} = {UseLoggingToFile}");
            sb.AppendLine($"{spaces}{nameof(UseRemoteLogging)} = {UseRemoteLogging}");
            sb.AppendLine($"{spaces}{nameof(ContractName)} = {ContractName}");
            sb.AppendLine($"{spaces}{nameof(UseLoggingToConsole)} = {UseLoggingToConsole}");
            sb.AppendLine($"{spaces}{nameof(UseLoggingToHostConsole)} = {UseLoggingToHostConsole}");
            return sb.ToString();
        }
    }
}
