using GnuClay.CommonClientTypes.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class ExternalValue : IExternalValue
    {
        public ExternalValueKind Kind { get; set; } = ExternalValueKind.Entity;
        public ulong TypeKey { get; set; }
        public object Value { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("Begin ExternalValue");
            tmpSb.AppendLine($"{nameof(Kind)} = {Kind}");
            tmpSb.AppendLine($"{nameof(TypeKey)} = {TypeKey}");
            tmpSb.AppendLine($"{nameof(Value)} = {Value}");
            tmpSb.AppendLine("End ExternalValue");
            return tmpSb.ToString();
        }
    }
}
