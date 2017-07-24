using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class PropertyAction
    {
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();

            //tmpSb.AppendLine($"{nameof(Name)} = {Name }");
            //tmpSb.AppendLine($"{nameof(Key)} = {Key}");
            //tmpSb.AppendLine($"{nameof(Command)} = {Command}");
            //tmpSb.AppendLine($"{nameof(State)} = {State}");
            //tmpSb.AppendLine($"{nameof(Result)} = {Result}");
            //tmpSb.AppendLine($"{nameof(Error)} = {Error}");
            //tmpSb.AppendLine($"{nameof(Initiator)} = {Initiator}");
            //tmpSb.AppendLine($"{nameof(InitiatedActions)} = {_ListHelper._ToString(InitiatedActions)}");

            return tmpSb.ToString();
        }
    }
}
