using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public class LogicalProcessOptions
    {
        public StartupMode StartupMode { get; set; } = StartupMode.OnDemand;
        public string Name { get; set; } = string.Empty;
        public bool IsAutoCanceled { get; set; } = true;
        public string ExclusiveGroup { get; set; } = string.Empty;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }
}
