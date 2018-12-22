using MyNPCLib.Logical;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public class PositionInfo: IPositionInfo
    {
        public KindOfPoint KindOfPoint { get; set; }
        public KindOfLocation KindOfLocation { get; set; }
        public Vector3? Point { get; set; }
        public BaseAbstractLogicalObject PlaneOfThePoint { get; set; }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append($"{spaces}{nameof(KindOfPoint)} = {KindOfPoint}");
            sb.Append($"{spaces}{nameof(KindOfLocation)} = {KindOfLocation}");
            sb.Append($"{spaces}{nameof(Point)} = {Point}");
            if (PlaneOfThePoint == null)
            {
                sb.AppendLine($"{spaces}{nameof(PlaneOfThePoint)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(PlaneOfThePoint)}");
                sb.Append(PlaneOfThePoint.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(PlaneOfThePoint)}");
            }
            return sb.ToString();
        }
    }
}
