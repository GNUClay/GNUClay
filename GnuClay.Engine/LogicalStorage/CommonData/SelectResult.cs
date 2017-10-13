using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    /// <summary>
    /// Represents the value of the variable for the tuple in the query.
    /// </summary>
    public class VarResultItem : IToStringData
    {
        /// <summary>
        /// Gets or sets the key of the variable.
        /// </summary>
        public ulong ParamKey { get; set; }

        /// <summary>
        /// Gets or sets the key of type of the value.
        /// </summary>
        public ulong EntityKey { get; set; }

        /// <summary>
        /// Gets or sets the kind of node in the result.
        /// </summary>
        public ExpressionNodeKind Kind { get; set; } = ExpressionNodeKind.Unknown;

        /// <summary>
        /// Gets or sets the system value which represents on C#.
        /// </summary>
        public object Value { get; set; }

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

    /// <summary>
    /// The tuple of found values.
    /// </summary>
    public class SelectResultItem : IToStringData
    {
        /// <summary>
        /// Gets or sets the key to used fact.
        /// </summary>
        public ulong Key { get; set; }

        /// <summary>
        /// Gets or sets the list of values of the variables for the tuple in the query.
        /// </summary>
        public List<VarResultItem> Params { get; set; } = new List<VarResultItem>();

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

            tmpSb.AppendLine($"{nameof(Key)} = {Key}");
            tmpSb.AppendLine(_ListHelper._ToString(Params, nameof(Params)));

            return tmpSb.ToString();
        }
    }

    /// <summary>
    /// Contains information about result of executing query.
    /// </summary>
    public class SelectResult : IToStringData
    {
        /// <summary>
        /// Gets or sets a text of the error of executing. It is always empty if 'Success' = true.
        /// </summary>
        public string ErrorText { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets flag about successful of executing query.
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Gets or sets flag about result of searching anything by SELECT query. It is always equals false after non select query.
        /// </summary>
        public bool HaveBeenFound { get; set; }

        /// <summary>
        /// Gets or sets the list of tuples of found values.
        /// </summary>
        public List<SelectResultItem> Items { get; set; } = new List<SelectResultItem>();

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

            tmpSb.AppendLine($"{nameof(ErrorText)} = {ErrorText}");
            tmpSb.AppendLine($"{nameof(Success)} = {Success}");
            tmpSb.AppendLine($"{nameof(HaveBeenFound)} = {HaveBeenFound}");

            tmpSb.AppendLine(_ListHelper._ToString(Items, nameof(Items)));

            return tmpSb.ToString();
        }
    }
}
