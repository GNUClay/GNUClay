using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class ErrorValue : IValue
    {
        public ErrorValue(ulong typeKey)
        {
            mTypeKey = typeKey;
        }

        private ulong mTypeKey = 0;

        public ulong TypeKey
        {
            get
            {
                return mTypeKey;
            }
        }

        public ulong GetLongHashCode()
        {
            return mTypeKey;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"Error {nameof(TypeKey)} = {TypeKey}";
        }
    }
}
