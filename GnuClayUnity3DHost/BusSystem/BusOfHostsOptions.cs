using GnuClay.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem
{
    public class BusOfHostsOptions: IObjectToString
    {
        public string BaseDir { get; set; }
        public BusOfHostsLoggingOptions Logging { get; set; } = new BusOfHostsLoggingOptions();

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>A string that represents the current instance.</returns>
        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(BaseDir)} = {BaseDir}");
            
            if(Logging == null)
            {
                sb.AppendLine($"{spaces}{nameof(Logging)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin{nameof(Logging)}");
                sb.Append(Logging.ToString(nextN));
                sb.AppendLine($"{spaces}End{nameof(Logging)}");
            }

            return sb.ToString();
        }
    }
}
