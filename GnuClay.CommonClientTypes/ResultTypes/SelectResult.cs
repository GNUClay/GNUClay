using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.ResultTypes
{
    public class VarResultItem : IToStringData
    {
        public ulong ParamKey = 0;
        public ulong EntityKey = 0;
        /// <summary>
        /// Kind of node in the result.
        /// </summary>
        public ExpressionNodeKind Kind = ExpressionNodeKind.Unknown;
        public object Value;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(ParamKey)} = {ParamKey}");
            tmpSb.AppendLine($"{nameof(EntityKey)} = {EntityKey}");
            tmpSb.AppendLine($"{nameof(Kind)} = {Kind}");
            tmpSb.AppendLine($"{nameof(Value)} = {Value}");

            return tmpSb.ToString();
        }
    }

    public class SelectResultItem : IToStringData
    {
        public List<VarResultItem> Params = new List<VarResultItem>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ListHelper._ToString(Params, nameof(Params)));

            return tmpSb.ToString();
        }
    }

    public class SelectResult : IToStringData
    {
        public string ErrorText = string.Empty;
        public bool Success = true;

        public bool HaveBeenFound = false;
        
        public List<SelectResultItem> Items = new List<SelectResultItem>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(HaveBeenFound));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(HaveBeenFound.ToString());

            tmpSb.AppendLine(_ListHelper._ToString(Items, nameof(Items)));

            return tmpSb.ToString();
        }
    }
}
