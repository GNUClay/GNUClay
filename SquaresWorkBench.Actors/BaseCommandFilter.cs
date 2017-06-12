using GnuClay.CommonUtils.Actors;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public class CommandFilterParam : ICommandFilterParam
    {
        public bool IsAnyType { get; set; } = true;
        public ulong TypeKey { get; set; } = 0;
        public bool IsAnyValue { get; set; } = true;
        public object Value { get; set; } = null;

        public override int GetHashCode()
        {
            var result = IsAnyType.GetHashCode();

            result ^= TypeKey.GetHashCode();

            result ^= IsAnyValue.GetHashCode();

            if (Value != null)
            {
                result ^= Value.GetHashCode();
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

    public class BaseCommandFilter
    {
        public string CommandName { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public Dictionary<string, CommandFilterParam> Params { get; set; } = new Dictionary<string, CommandFilterParam>();

        public override int GetHashCode()
        {
            var result = 0;

            foreach (var item in Params)
            {
                result ^= item.Value.GetHashCode();
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
