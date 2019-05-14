﻿using GnuClay.CommonHelpers.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem
{
    public class BusOfHostsOptions: IObjectToString
    {
        public string BaseDir { get; set; }
        public string SharedPackagesDir { get; set; } = "SharedPackages";
        public string DevSharedPackagesDir { get; set; } = "DevSharedPackagesDir";
        public string AppsDir { get; set; } = "Apps";
        public string ImagesDir { get; set; } = "Images";
        public string CurrentImage { get; set; }
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
            sb.AppendLine($"{spaces}{nameof(SharedPackagesDir)} = {SharedPackagesDir}");
            sb.AppendLine($"{spaces}{nameof(AppsDir)} = {AppsDir}");
            sb.AppendLine($"{spaces}{nameof(ImagesDir)} = {ImagesDir}");
            sb.AppendLine($"{spaces}{nameof(CurrentImage)} = {CurrentImage}");

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
