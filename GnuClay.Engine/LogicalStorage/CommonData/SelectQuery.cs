using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    public class SelectQuery : IToStringData
    {
        public ExpressionNode SelectedTree = null;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ObjectHelper._ToString(SelectedTree, nameof(SelectedTree)));

            return tmpSb.ToString();
        }
    }
}
