using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class PropertyCommand: ILongHashableObject
    {
        public IValue Holder { get; set; }
        public ulong PropertyKey { get; set; }
        public IValue Value { get; set; }
        public bool IsGet { get; set; }

        public ulong GetLongHashCode()
        {
            var result = Holder.GetLongHashCode() ^ PropertyKey;
            
            if(Value != null)
            {
                result ^= Value.GetLongHashCode();
            }

            return result;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Holder)} = {Holder}");
            tmpSb.AppendLine($"{nameof(PropertyKey)} = {PropertyKey}");
            tmpSb.AppendLine($"{nameof(Value)} = {Value}");
            tmpSb.AppendLine($"{nameof(IsGet)} = {IsGet}");

            return tmpSb.ToString();
        }
    }
}
