using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    [Serializable]
    public class SecondaryPropertyInfo : IToStringData
    {
        public SecondaryPropertyInfo()
        {
        }

        public SecondaryPropertyInfo(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name = string.Empty;
        public object Value = null;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append("Name = ");
            tmpSb.AppendLine(Name);

            tmpSb.AppendLine(_ObjectHelper._ToString(Value, "Value"));

            return tmpSb.ToString();
        }
    }
}
