using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public class ExternalCommandFilterParam: IExternalCommandFilterParam
    {
        public bool IsAnyType { get; set; } = true;
        public ulong TypeKey { get; set; }

        public virtual ulong GetLongHashCode()
        {
            ulong result = (ulong)IsAnyType.GetHashCode();
            result ^= TypeKey;
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
