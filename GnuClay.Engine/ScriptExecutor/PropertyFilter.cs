using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class PropertyFilter: CommandFilterParam
    {
        public ulong HolderKey { get; set; }
        public ulong PropertyKey { get; set; }
        public bool WithOutClause { get; set; } = true;

        public MethodInfo SetMethod { get; set; }
        public MethodInfo GetMethod { get; set; }

        public override ulong GetLongHashCode()
        {
            var result = base.GetLongHashCode() ^ HolderKey;

            return result;
        }

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
