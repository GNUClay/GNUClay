using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.LoggingHelpers
{
    public class DiagnosticsCallInfo : IObjectToString
    {
        public string FullClassName { get; set; }
        public string MethodName { get; set; }

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
            sb.AppendLine($"{spaces}{nameof(FullClassName)} = {FullClassName}");
            sb.AppendLine($"{spaces}{nameof(MethodName)} = {MethodName}");
            return sb.ToString();
        }
    }
}
