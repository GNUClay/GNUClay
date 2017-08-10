using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.CommonData
{
    /// <summary>
    /// Represents an insert query.
    /// </summary>
    public class InsertQuery : IToStringData
    {
        /// <summary>
        /// Rewrite facts is true, otherwise write another fact.
        /// The facts is same if its root relations and left operands is same.
        /// </summary>
        public bool Rewrite = false;

        /// <summary>
        /// Inserted rules or facts.
        /// </summary>
        public List<RuleInstance> Items = new List<RuleInstance>();

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

            tmpSb.AppendLine($"{nameof(Rewrite)} = {Rewrite}");
            tmpSb.AppendLine(_ListHelper._ToString(Items, nameof(Items)));

            return tmpSb.ToString();
        }
    }
}
