using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    public class VarResultItem: IToStringData
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

    public class SelectResultItem : IToStringData
    {
        public List<VarResultItem> Params = new List<VarResultItem>();

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ListHelper._ToString(Params, nameof(Params)));

            return tmpSb.ToString();
        }
    }

    public class SelectResult : IToStringData
    {
        public List<SelectResultItem> Items = new List<SelectResultItem>();

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
