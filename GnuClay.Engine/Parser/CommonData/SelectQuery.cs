using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.CommonData
{
    /// <summary>
    /// Represents an select query.
    /// </summary>
    public class SelectQuery : IToStringData
    {
        /// <summary>
        /// Represents an selecting expression
        /// </summary>
        public ExpressionNode SelectedTree = null;

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

            tmpSb.AppendLine(_ObjectHelper._ToString(SelectedTree, nameof(SelectedTree)));

            return tmpSb.ToString();
        }
    }
}
