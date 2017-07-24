using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public delegate void PropertyHandler(PropertyAction action);

    public class PropertyFilter: CommandFilterParam
    {
        public ulong HolderKey { get; set; }
        public bool WithOutClause { get; set; } = true;

        public PropertyHandler SetMethod { get; set; }
        public PropertyHandler GetMathod { get; set; }

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
