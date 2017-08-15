using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class BooleanValue : BaseValueType
    {
        public BooleanValue(ulong typeKey, object value)
            : base(typeKey, value)
        {
            OriginalValue = (bool)(Value);
        }

        public bool OriginalValue = false;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"BooleanValue {nameof(TypeKey)} = {TypeKey}; {nameof(Value)} = {Value}";
        }
    }
}
