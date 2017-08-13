using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class DirectFactValue: BaseFactValue
    {
        public DirectFactValue(ulong typeKey, GnuClayEngineComponentContext context)
            : base(typeKey, context)
        {
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"DirectFactValue {nameof(TypeKey)} = {TypeKey}; {nameof(Kind)}= {Kind};";
        }
    }
}
