using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresWorkBench.CommonEngine
{
    [Serializable]
    public class EntityInfo : IToStringData
    {
        public string TypeName = string.Empty;

        public double CurrAngle = 0;

        public Point CurrPos = new Point(0, 0);

        public Point RelativePos = new Point(0, 0);

        public EntityInfo CurrPlatform = null;

        public List<SecondaryPropertyInfo> SecondaryProps = new List<SecondaryPropertyInfo>();

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append("TypeName = ");
            tmpSb.AppendLine(TypeName);

            tmpSb.Append("CurrAngle = ");
            tmpSb.AppendLine(CurrAngle.ToString());

            tmpSb.Append("CurrPos = ");
            tmpSb.AppendLine(CurrPos.ToString());

            tmpSb.Append("RelativePos = ");
            tmpSb.AppendLine(RelativePos.ToString());

            tmpSb.AppendLine(_ObjectHelper._ToString(CurrPlatform, "CurrPlatform"));

            tmpSb.AppendLine(_ListHelper._ToString(SecondaryProps, "SecondaryProps"));

            return tmpSb.ToString();
        }
    }
}
