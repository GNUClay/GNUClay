using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    [Serializable]
    public class ViewerInfo : IToStringData
    {
        public double Height = 0;
        public double Width = 0;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append("Height = ");
            tmpSb.AppendLine(Height.ToString());

            tmpSb.Append("Width = ");
            tmpSb.AppendLine(Width.ToString());

            return tmpSb.ToString();
        }
    }
}
