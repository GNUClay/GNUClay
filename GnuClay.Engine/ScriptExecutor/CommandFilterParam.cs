using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class CommandFilterParam: ILongHashableObject
    {
        public CommandFilterParam()
        {
        }

        public CommandFilterParam(CommandFilterParam source)
        {
            IsAnyType = source.IsAnyType;
            TypeKey = source.TypeKey;
            IsAnyValue = source.IsAnyValue;
            Value = Value;
        }

        public bool IsAnyType { get; set; } = true;
        public ulong TypeKey { get; set; }
        public bool IsAnyValue { get; set; } = true;
        public IValue Value { get; set; }

        public virtual ulong GetLongHashCode()
        {
            ulong result = (ulong)IsAnyType.GetHashCode();

            result ^= TypeKey;

            result ^= (ulong)IsAnyValue.GetHashCode();

            if (Value != null)
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
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }
}
