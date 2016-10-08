using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    public class RulePart : IToStringData
    {
        public RuleInstance Parent = null;

        public RulePart Next = null;

        public ExpressionNode Tree = null;

        public long GetLongHashCode()
        {
            return Tree.GetLongHashCode();
        }

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ObjectHelper._ToString(Tree, nameof(Tree)));

            return tmpSb.ToString();
        }
    }
}
