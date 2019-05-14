﻿using GnuClay.CommonHelpers.DebugHelpers;
using GnuClayUnity3DHost.BusSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BaseHostSystem
{
    public class BaseHostOptions: IObjectToString
    {
        public string Name { get; set; }
        public BusOfHosts Bus { get; set; }
        public BaseHostLoggingOptions Logging { get; set; } = new BaseHostLoggingOptions();

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
        public virtual string PropertiesToString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Name)} = {Name}");

            if (Logging == null)
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
