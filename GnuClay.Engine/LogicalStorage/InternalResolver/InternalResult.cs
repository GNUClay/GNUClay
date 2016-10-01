using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InternalResultItem : IToStringData
    {
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            return tmpSb.ToString();
        }
    }

    public class InternalResult : IToStringData
    {
        public List<InternalResultItem> Items = new List<InternalResultItem>();

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ListHelper._ToString(Items, nameof(Items)));

            return tmpSb.ToString();
        }
    }
}
