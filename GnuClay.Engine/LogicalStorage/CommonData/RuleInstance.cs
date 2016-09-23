using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    public class RuleInstance : IToStringData
    {
        public RulePart Part_1 = null;
        public RulePart Part_2 = null;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ObjectHelper._ToString(Part_1, nameof(Part_1)));
            tmpSb.AppendLine(_ObjectHelper._ToString(Part_2, nameof(Part_2)));

            return tmpSb.ToString();
        }
    }
}
